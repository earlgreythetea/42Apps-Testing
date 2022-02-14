using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private string _logMessage = "";
    private void Start()
    {
        AddLog(0);
    }
    public IEnumerator GameEnding()
    {
        yield return new WaitForSeconds(2f);
        SaveLogs();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void SaveLogs()
    {
        string filename = "log.txt";
        //FileStream sw = File.Open(filename, FileMode.OpenOrCreate);
        StreamWriter sw = new StreamWriter(filename,true);
        sw.Write(_logMessage);
        sw.Close();
    }
    void OnApplicationQuit()
    {
        SaveLogs();
    }
    public void AddLog(int state)
    {
        string message = "";
        switch(state)
        {
            case 0:
                {
                    message = "Старт игры.";
                    break;
                }
            case 1:
                {
                    message = "Выстрел произведен.";
                    break;
                }
            case 2:
                {
                    message = "Попадание во врага.";
                    break;
                }
            case 3:
                {
                    message = "Промах(попадание в ландшафт).";
                    break;
                }
            case 4:
                {
                    message = "Промах(истекло время жизни).";
                    break;
                }
            case 5:
                {
                    message = "Победа.";
                    break;
                }

        }
        _logMessage += message + "\n";
    }
}
