using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    public GameObject cellPrefabs; // Khai bao GameObject cellPrefabs
    public Transform board; // Khai bao thanh phan board
    public GridLayoutGroup gridLayout; // Khai bao gridLayout
    private Vector2 lastMove;
    private Vector2Int lastMoveInt;
    private static int xWinsCount = 0; // So lan win cua O va X
    private static int oWinsCount = 0;




    public int boardSize;

    // Khai bao currenTurn ban dau la "x"
    public string currentTurn = "x";

    // Hien thi so lan thang
    public Text xWinsText;
    public Text oWinsText;


    // Khoi tao matrix de luu giu toa do
    private string[,] matrix;

    public void Awake(){

    }
    public void Start(){
        matrix = new string[boardSize + 1, boardSize + 1]; //Khoi tao ma tran
        gridLayout.constraintCount = boardSize; // Gan gia tri boardSize duoc nhap cho gridLayout
        CreateBoard();
        InitializeWinsCount();
    }

    // Khoi tao ma tran boardSize x boardSize 
    private void CreateBoard(){
        for (int i=1; i<=boardSize; i++){
            for (int j=1; j<=boardSize; j++){
                // Tao cell va GetComponent
                GameObject cellTransform = Instantiate(cellPrefabs, board); // cellPrefabs duoc tao la tap con cua board
                Cell cell = cellTransform.GetComponent<Cell>();
                // Set toa do
                cell.row = j;
                cell.column = i;
                matrix[i, j] = "";
            }
        }
    }

    // Ham cap nhat so lan thang
    private void UpdateWinsText(){
        if (xWinsText != null && oWinsText != null){
            xWinsText.text = "X Wins: " + xWinsCount;
            oWinsText.text = "O Wins: " + oWinsCount;
        }
    }

    private void InitializeWinsCount()
    {
        xWinsCount = 0 + xWinsCount;
        oWinsCount = 0 + oWinsCount;
        UpdateWinsText();
    }


    // Check dieu kien thang
    public bool Check(int row, int column){
        matrix[row, column] = currentTurn;
        lastMove = new Vector2(row, column); // Vi tri dang danh
        lastMoveInt = new Vector2Int(Mathf.RoundToInt(lastMove.x), Mathf.RoundToInt(lastMove.y));

        bool result = false;
        
        // Check theo hang doc
        int count = 0;
        // Check len phia tren
        for (int i = lastMoveInt.x - 1; i>=1; i-- ){ 
            if (matrix[i, lastMoveInt.y] == currentTurn){
                count++;
            }
            else{
                break;
            }
        }
        // Check xuong phia duoi
        for (int i = lastMoveInt.x + 1; i<=boardSize; i++ ){ 
            if (matrix[i, lastMoveInt.y] == currentTurn){
                count++;
            }
            else{
                break;
            }
        }
        if (count + 1 >= 5) {
            result = true;
            if (currentTurn == "x") {
                xWinsCount++;
            } else if (currentTurn == "o") {
                oWinsCount++;
            }
            UpdateWinsText(); // Gọi hàm cập nhật số lần thắng trên UI
        }


        // Check theo hang ngang
        count = 0;
        //Check sang ben phai
        for (int i = lastMoveInt.y + 1; i <= boardSize; i++ ){ 
            if (matrix[lastMoveInt.x, i] == currentTurn){
                count++;
            }
            else{
                break;
            }
        }
        //Check sang ben trai
        for (int i = lastMoveInt.y - 1; i >= 1; i-- ){ 
            if (matrix[lastMoveInt.x, i] == currentTurn){
                count++;
            }
            else{
                break;
            }
        }
        if (count + 1 >= 5) {
            result = true;
            if (currentTurn == "x") {
                xWinsCount++;
            } else if (currentTurn == "o") {
                oWinsCount++;
            }
            UpdateWinsText(); // Gọi hàm cập nhật số lần thắng trên UI
        }


        // Check hang cheo 1
        count = 0;
        // Check len tren
        for (int i = lastMoveInt.y - 1; i >=1; i--){
            if (matrix[lastMoveInt.x - (lastMoveInt.y-i), i] == currentTurn){
                count++;
            }
            else {
                break;
            }
        }
        // Check xuong duoi
        for (int i = lastMoveInt.y + 1; i <= boardSize; i++){
            if (matrix[lastMoveInt.x + (i-lastMoveInt.y), i] == currentTurn){
                count++;
            }
            else {
                break;
            }
        }
        if (count + 1 >= 5) {
            result = true;
            if (currentTurn == "x") {
                xWinsCount++;
            } else if (currentTurn == "o") {
                oWinsCount++;
            }
            UpdateWinsText(); // Gọi hàm cập nhật số lần thắng trên UI
        }

        // Check hang cheo 2
        count = 0;
        // Check len tren
        for (int i = lastMoveInt.y + 1; i <= boardSize; i++){
            if (matrix[lastMoveInt.x - (i-lastMoveInt.y), i] == currentTurn){
                count++;
            }
            else {
                break;
            }
        }
        // Check xuong duoi
        for (int i = lastMoveInt.y - 1; i >= 1; i--){
            if (matrix[lastMoveInt.x + (lastMoveInt.y - i), i] == currentTurn){
                count++;
            }
            else {
                break;
            }
        }
        if (count + 1 >= 5) {
            result = true;
            if (currentTurn == "x") {
                xWinsCount++;
            } else if (currentTurn == "o") {
                oWinsCount++;
            }
            UpdateWinsText(); // Gọi hàm cập nhật số lần thắng trên UI
        }

        return result;
    }
}