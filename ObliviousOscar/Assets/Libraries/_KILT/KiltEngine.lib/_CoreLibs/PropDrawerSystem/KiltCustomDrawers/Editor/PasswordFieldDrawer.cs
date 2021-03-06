﻿using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(PasswordFieldAttribute))]
public class PasswordFieldDrawer : SpecificFieldDrawer 
{
	protected override void DrawComponent(Rect position, SerializedProperty property, GUIContent label, System.Type p_type)
	{
		if(property.propertyType == SerializedPropertyType.String)
		{
			property.stringValue = EditorGUI.PasswordField(position, label, property.stringValue);
		}
		else
			EditorGUI.PropertyField(position, property, label, true);
	}
}
