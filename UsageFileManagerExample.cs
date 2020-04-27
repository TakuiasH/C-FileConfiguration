using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsageFileManagerExample : MonoBehaviour {
    FileManager fm;

    void Start () {
        fm = new FileManager("files/testdir","testfile.txt");
        Set();
        Get();
    }
    void Set()
    {
        fm.set("test.String", "Hello World");
        fm.set("test.Int", 1234);
        fm.set("test.Float", 1234.5f);
    }
    void Get()
    {
        Debug.Log(fm.getString("test.String"));
        Debug.Log(fm.getInt("test.Int"));
        Debug.Log(fm.getFloat("test.Float"));
    }


}
