using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour
{

    public enum Cell { EMPTY, CROSS, NOUGHT };
    public GameObject Cross, Nought, Empty, TurnPic;
    public Cell winner;
    public Cell turn;
    public Cell[] board;
    public GameObject[] cellsGameObjects;
    int[][] winnerCombinations = new int[8][];
    public Text crossWinsText;
    public Text noughtWinsText;
    public int crossWins;
    public int noughtWins;
    System.Random rnd = new System.Random();
    public AudioClip TouchSoundClip;
    public AudioSource TouchSoundSource;
    public AudioClip WinSoundClip;
    public AudioSource WinSoundSource;

    void Start()
    {
        TouchSoundSource.clip = TouchSoundClip;
        WinSoundSource.clip = WinSoundClip;

        board = new Cell[9];
        cellsGameObjects = new GameObject[9];
        for (int i = 0; i < 9; i++)
        {
            board[i] = Cell.EMPTY;
        }

        winnerCombinations[0] = new int[3] { 0, 1, 2 };
        winnerCombinations[1] = new int[3] { 3, 4, 5 };
        winnerCombinations[2] = new int[3] { 6, 7, 8 };
        winnerCombinations[3] = new int[3] { 0, 3, 6 };
        winnerCombinations[4] = new int[3] { 1, 4, 7 };
        winnerCombinations[5] = new int[3] { 2, 5, 8 };
        winnerCombinations[6] = new int[3] { 0, 4, 8 };
        winnerCombinations[7] = new int[3] { 2, 4, 6 };

        int x = rnd.Next(0, 2);
        if (x == 0)
            turn = Cell.CROSS;
        else
            turn = Cell.NOUGHT;

        winner = Cell.EMPTY;

        crossWinsText.text = "0";
        noughtWinsText.text = "0";
        crossWins = 0;
        noughtWins = 0;

        TurnPic.GetComponent<SpriteRenderer>().sprite = (turn == Cell.CROSS ? Cross.GetComponent<SpriteRenderer>().sprite : Nought.GetComponent<SpriteRenderer>().sprite);
    }

    public void drawCell(GameObject emptyCell, int id)
    {
        if (board[id] != Cell.EMPTY || winner != Cell.EMPTY) return;
        board[id] = turn;
        cellsGameObjects[id] = emptyCell;
        emptyCell.GetComponent<SpriteRenderer>().sprite = (turn == Cell.CROSS ? Cross.GetComponent<SpriteRenderer>().sprite : Nought.GetComponent<SpriteRenderer>().sprite);
        //Instantiate(turn == Cell.CROSS ? Cross : Nought, emptyCell.transform.position, Quaternion.identity);
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
        TurnPic.GetComponent<SpriteRenderer>().sprite = (turn == Cell.CROSS ? Cross.GetComponent<SpriteRenderer>().sprite : Nought.GetComponent<SpriteRenderer>().sprite);
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
        for (int i = 0; i < 9; i++)
        {
            board[i] = Cell.EMPTY;
        }

        int x = rnd.Next(0, 2);
        if (x == 0)
            turn = Cell.CROSS;
        else
            turn = Cell.NOUGHT;

        winner = Cell.EMPTY;

        TurnPic.GetComponent<SpriteRenderer>().sprite = (turn == Cell.CROSS ? Cross.GetComponent<SpriteRenderer>().sprite : Nought.GetComponent<SpriteRenderer>().sprite);

        for (int i = 0; i < cellsGameObjects.Length; i++)
        {

            if (cellsGameObjects[i]) cellsGameObjects[i].GetComponent<SpriteRenderer>().sprite = Empty.GetComponent<SpriteRenderer>().sprite;
            //if (cellsGameObjects[i]) Instantiate(Empty, cellsGameObjects[i].transform.position, Quaternion.identity);
        }
        
    }
}
