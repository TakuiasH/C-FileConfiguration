using UnityEngine;
using System.IO;
using System;

public class FileManager : MonoBehaviour {

    string fileName;

    public FileManager(string file)
    {
        this.fileName = file;
        if (!File.Exists(@Application.dataPath + @"/" + @fileName))
        {
            StreamWriter sw = new StreamWriter(@Application.dataPath + @"/" + @fileName);
            sw.Close();
        }
    }
    public FileManager(string directoryPath, string file)
    {
        this.fileName = @directoryPath + @"/" + @file;

        if (!File.Exists(@Application.dataPath + @"/" + @fileName))
        {
            Directory.CreateDirectory(@Application.dataPath + @"/" + @directoryPath);
            StreamWriter sw = new StreamWriter(@Application.dataPath + @"/" + @fileName);
            sw.Close();
        }
    }

    public string getString(string path) {
        StreamReader sr = new StreamReader(@Application.dataPath + @"/" + @fileName);
        string line = "";
        while (!sr.EndOfStream)
        {
            string tt = sr.ReadLine();
            if (tt.StartsWith(path)) { line = tt; }
        }
        sr.Close();
        string[] getReturn = line.Split(':');
        if (getReturn[0] != "")
        {
            if (getReturn[1].StartsWith(" ")) return getReturn[1].Remove(0, 1);
            else return getReturn[1];
        }
        return null;
    }
    public int getInt(string path) {
        StreamReader sr = new StreamReader(@Application.dataPath + @"/" + @fileName);
        string line = "";
        while (!sr.EndOfStream)
        {
            string tt = sr.ReadLine();
            if (tt.StartsWith(path)) { line = tt; }
        }
        sr.Close();
        string[] getReturn = line.Split(':');
        if (getReturn[0] != "")
        {
            try { return int.Parse(getReturn[1]); }
            catch (Exception) { Debug.LogError("O resultado é diferente de uma int"); return 0; }
        }
        return 0;
    }
    public float getFloat(string path)
    {
        StreamReader sr = new StreamReader(@Application.dataPath + @"/" + @fileName);
        string line = "";
        while (!sr.EndOfStream)
        {
            string tt = sr.ReadLine();
            if (tt.StartsWith(path)) { line = tt; }
        }
        sr.Close();
        string[] getReturn = line.Split(':');
        if (getReturn[0] != "")
        {
            try { return float.Parse(getReturn[1]); }
            catch (Exception) { Debug.LogError("O resultado é diferente de uma float"); return 0; }
        }
        return 0;
    }
    public double getDouble(string path)
    {
        StreamReader sr = new StreamReader(@Application.dataPath + @"/" + @fileName);
        string line = "";
        while (!sr.EndOfStream)
        {
            string tt = sr.ReadLine();
            if (tt.StartsWith(path)) { line = tt; }
        }
        sr.Close();
        string[] getReturn = line.Split(':');
        if (getReturn[0] != "")
        {
            try { return double.Parse(getReturn[1]); }
            catch (Exception) { Debug.LogError("O resultado é diferente de um double"); return 0; }
        }
        return 0;
    }

    public bool contains(string path){return getString(path) != null;}

    public void set(string path, object argument) {
        if(argument == null){
            if (contains(path)){
                string[] lines = File.ReadAllLines(@Application.dataPath + @"/" + @fileName);
                for (int i = 0; i < lines.Length; i++){if (lines[i].StartsWith(path + ":")){
                        lines[i] = null;
                    } }
                File.WriteAllLines(@Application.dataPath + @"/" + @fileName, lines);
            }
            return;
        }

        if (contains(path)){
            string[] lines = File.ReadAllLines(@Application.dataPath + @"/" + @fileName);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(path + ":")){lines[i] = path + ": " + argument;}
            }
            File.WriteAllLines(@Application.dataPath + @"/" + @fileName, lines);
        }else{
            string[] lines = File.ReadAllLines(@Application.dataPath + @"/" + @fileName);
            string[] t = new string[lines.Length + 1];
            int value = lines.Length;
            for (int i = 0; i < lines.Length; i++) {
                if (lines[i] == "" || lines[i] == @"\n")
                {
                    value = i;
                }
                t[i] = lines[i];
            }
            t[value] = path + ": " + argument;
            File.WriteAllLines(@Application.dataPath + @"/" + @fileName, t);
        }
    }

}
