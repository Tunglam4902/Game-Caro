using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class Cell : MonoBehaviour
    {
        public GameObject gameOverWindow;
        
        private Transform canvas; // Tham chieu canvas

        // Khai bao toa do
        public int row;
        public int column;
        
        private Board board; // Tham chieu den board cua Class board
        
        // Khai bao Sprite X, O
        public Sprite xSprite;
        public Sprite oSprite;

        // Khai bao thanh phan image va button cua cell
        private Image image;
        private Button button;

        // Khai bao thanh phan audio
        private AudioSource audioSource;

        // Tham chieu cac gia tri image va button
        private void Awake(){
            image = GetComponent<Image>();
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
            audioSource = GetComponent<AudioSource>();
        }

        // Lay tham chieu cua board tu lop Board vao 
        private void Start(){
            board = FindObjectOfType<Board>();
            canvas = FindObjectOfType<Canvas>().transform;
        }

        // Thay doi image duoc chon cua cell 
        public void ChangeImage(string s){
            if (s == "x"){
                image.sprite = xSprite;
            }
            else{
                image.sprite = oSprite;
            }
        }
        public void OnClick(){
            ChangeImage(board.currentTurn);
            audioSource.Play(); // Phát âm thanh khi click
            // Hien thi cua so GameOver
            if (board.Check(row, column)){
                GameObject window = Instantiate(gameOverWindow, canvas);
                window.GetComponent<GameOver>().SetName(board.currentTurn);
            }
            if (board.currentTurn == "x"){
                board.currentTurn = "o";
            }
            else{
                board.currentTurn = "x";
            }
        }
    }