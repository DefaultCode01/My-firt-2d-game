using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CreateAssetMenu(fileName ="New Dialogue", menuName ="New Dialogue/Dialogue")] // esta criando uma nova aba  menu dentro das opções de menu da unity
public class DialogueSettings : ScriptableObject //
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprites;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>(); // criando uma lista para inserir novos dialogos

}


[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile; // para poder mudar o sprite do personagem de acordo com a sua fala
    public Languages sentence;// para adicionar a fala em linguagens difrentes


}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string espanish;

}

#if UNITY_EDITOR


    [CustomEditor(typeof(DialogueSettings))]
    public class BuilderEditor : Editor
    {
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();// modifica- redesenha o inspector
        DialogueSettings ds = (DialogueSettings)target;

        Languages l = new Languages();
        l.portuguese = ds.sentence;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprites;
        s.sentence = l;

        if (GUILayout.Button("Create Dialogue"))
        {
            if (ds.sentence != "")
            {
                ds.dialogues.Add(s);

                ds.speakerSprites = null;
                ds.sentence = "";
            }
        }


        }
    }




#endif