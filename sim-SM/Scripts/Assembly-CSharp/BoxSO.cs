using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Box", menuName = "Scriptable Objects/Box")]
public class BoxSO : ScriptableObject
{
	public int ID;

	public Box BoxPrefab;

	public BoxSize BoxSize;

	[Header("Carrying Settings")]
	public Vector3 PositionOffset;

	[Header("Grid Layout")]
	public BoxGridLayout3D.GridLayout GridLayout;
}
