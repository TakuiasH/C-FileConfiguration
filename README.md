# C# FileConfiguration
A simple system to define and obtain values in a file

It was created to try to simulate the Java Yaml configuration system

it is very easy and intuitive to use

You can use arguments in **String, Int, Float and Double**

`
    FileManager fm;

    void Start () {
        fm = new FileManager("files/testdir","testfile.txt"); //set the directory and the file name.
        Set();
        Get();
    }
    void Set()
    {
        fm.set("test.String", "Hello World"); //Set a string
        fm.set("test.Int", 1234);             //Set a int
        fm.set("test.Float", 1234.5f);        //Set a float
    }
    void Get()
    {
        Debug.Log(fm.getString("test.String"));//Output: Hello World
        Debug.Log(fm.getInt("test.Int"));      //Output: 1234
        Debug.Log(fm.getFloat("test.Float"));  //Output: 1234.5
    }  
`
