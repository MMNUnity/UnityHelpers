using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By sarahnorthway
// Use this to set properties in the editor.
// Add this to Assets/Scripts/Editor

public class GetSetAttribute : PropertyAttribute
{
    public readonly string name;
    public bool dirty;
    public GetSetAttribute(string name)
    {
        this.name = name;
    }
}
