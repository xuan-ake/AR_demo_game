using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Medicine
{
    public int count;
    public string name;
}
public class MedicineList//存入json必须封装一遍
{
    public List<Medicine> medicinelist = new List<Medicine>();
}
public class DataSave : MonoBehaviour
{
    
    public Text redText;
    public Text blueText;
    public Text yellowText;
    public MedicineList medicines = new MedicineList();
    public Medicine red;
    public Medicine blue;
    public Medicine yellow;
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateData()
    {
        red = new Medicine();
        red.count = 0;
        red.name = "red";
        blue = new Medicine();
        blue.count = 0;
        blue.name = "blue";
        yellow = new Medicine();
        yellow.count = 0;
        yellow.name = "yellow";
        medicines.medicinelist.Add(red);
        medicines.medicinelist.Add(blue);
        medicines.medicinelist.Add(yellow);
    }

    public void OnClickButton(string name)
    {
        
        if (name.Equals("red"))
        {
            red.count++;
            redText.text = red.count.ToString();
        }
        if (name.Equals("blue"))
        {
            blue.count++;
            blueText.text = blue.count.ToString();
        }
        if (name.Equals("yellow"))
        {
            yellow.count++;
            yellowText.text = yellow.count.ToString();
        }
    }

    void SaveData()
    {
        string json = JsonUtility.ToJson(medicines, true);//unity自带，将列表保存成json，改成适合阅读
        string filepath = Application.streamingAssetsPath + "/Medicines.json";
        using (StreamWriter sw=new StreamWriter(filepath))//filepath记录文件的存储路径
        {
            sw.WriteLine(json);
            sw.Close();
            sw.Dispose();
        }
    }

    public void OnQuitButton()
    {
        SaveData();
        Application.Quit();
    }

    void LoadData()
    {
        string json;
        string filepath = Application.streamingAssetsPath + "/Medicines.json";
        if (File.Exists(filepath))
        {
            using (StreamReader sr =new StreamReader(filepath))
            {
                json = sr.ReadToEnd();
                sr.Close();
            }

            medicines = JsonUtility.FromJson<MedicineList>(json);//MedicineList须封装一次
            //反操作
            red = medicines.medicinelist[0];
            blue = medicines.medicinelist[1];
            yellow = medicines.medicinelist[2];
            redText.text = red.count.ToString();
            blueText.text = blue.count.ToString();
            yellowText.text = yellow.count.ToString();
        }
        else
        {
            GenerateData();
        }
    }
}
