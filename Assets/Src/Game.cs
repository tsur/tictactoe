using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour
{

    public enum Cell { EMPTY, CROSS, NOUGHT };
    public GameObject Cross, Nought, Empty, TurnPic;
    Cell winner;
    Cell turn;
    Cell[] board;
    GameObject[] cellsGameObjects = new GameObject[9];
    int[][] winnerCombinations = new int[8][];
    public Text crossWinsText;
    public Text noughtWinsText;
    int crossWins;
    int noughtWins;
    System.Random rnd = new System.Random();
    public AudioClip TouchSoundClip;
    public AudioSource TouchSoundSource;
    public AudioClip WinSoundClip;
    public AudioSource WinSoundSource;

    void InitSound()
    {
        TouchSoundSource.clip = TouchSoundClip;
        WinSoundSource.clip = WinSoundClip;
    }

    void InitBoard()
    {
        board = new Cell[9];
        for (int i = 0; i < 9; i++)
        {
            board[i] = Cell.EMPTY;
        }
        
        for (int i = 0; i < cellsGameObjects.Length; i++)
        {

            if (cellsGameObjects[i]) cellsGameObjects[i].GetComponent<SpriteRenderer>().sprite = Empty.GetComponent<SpriteRenderer>().sprite;
            //if (cellsGameObjects[i]) Instantiate(Empty, cellsGameObjects[i].transform.position, Quaternion.identity);
        }
    }

    void InitWinner()
    {
        winnerCombinations[0] = new int[3] { 0, 1, 2 };
        winnerCombinations[1] = new int[3] { 3, 4, 5 };
        winnerCombinations[2] = new int[3] { 6, 7, 8 };
        winnerCombinations[3] = new int[3] { 0, 3, 6 };
        winnerCombinations[4] = new int[3] { 1, 4, 7 };
        winnerCombinations[5] = new int[3] { 2, 5, 8 };
        winnerCombinations[6] = new int[3] { 0, 4, 8 };
        winnerCombinations[7] = new int[3] { 2, 4, 6 };

        crossWins = 0;
        noughtWins = 0;
    }

    void InitPlayerTurn()
    {
        int x = rnd.Next(0, 2);
        if (x == 0)
        {
            turn = Cell.CROSS;
        }
        else
        {
            turn = Cell.NOUGHT;
        }
            
        winner = Cell.EMPTY;
        paintCellSprite(TurnPic);
    }

    void InitUI()
    {
        crossWinsText.text = "0";
        noughtWinsText.text = "0";
    }

    void paintCellSprite(GameObject cell)
    {
        cell.GetComponent<SpriteRenderer>().sprite = (turn == Cell.CROSS ? Cross.GetComponent<SpriteRenderer>().sprite : Nought.GetComponent<SpriteRenderer>().sprite);
    }


    void Start()
    {

        InitSound();

        InitBoard();

        InitWinner();

        InitPlayerTurn();

        InitUI();
    }

    public void drawCell(GameObject emptyCell, int id)
    {
        if (board[id] != Cell.EMPTY || winner != Cell.EMPTY) return;
        board[id] = turn;
        cellsGameObjects[id] = emptyCell;
        paintCellSprite(emptyCell);
        if (doWeHaveAWinner())
        {
            if (winner == Cell.CROSS) crossWins++;
            else noughtWins++;

            crossWinsText.text = crossWins.ToString();
            noughtWinsText.text = noughtWins.ToString();

            WinSoundSource.Play();
            return;
        }
        turn = (turn == Cell.CROSS) ? Cell.NOUGHT : Cell.CROSS;
        paintCellSprite(TurnPic);
        TouchSoundSource.Play();
    }

    bool doWeHaveAWinner()
    {

        for(int i=0; i < 8; i++)
        {
            if(board[winnerCombinations[i][0]] == turn && board[winnerCombinations[i][1]] == turn && board[winnerCombinations[i][2]] == turn)
            {
                winner = turn;
                return true;
            }
        }

        return false;
    }

    public void reset()
    {
        InitBoard();

        InitPlayerTurn();
    }
}
