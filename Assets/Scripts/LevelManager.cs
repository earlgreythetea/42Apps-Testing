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
                    message = "����� ����.";
                    break;
                }
            case 1:
                {
                    message = "������� ����������.";
                    break;
                }
            case 2:
                {
                    message = "��������� �� �����.";
                    break;
                }
            case 3:
                {
                    message = "������(��������� � ��������).";
                    break;
                }
            case 4:
                {
                    message = "������(������� ����� �����).";
                    break;
                }
            case 5:
                {
                    message = "������.";
                    break;
                }

        }
        _logMessage += message + "\n";
    }
}
