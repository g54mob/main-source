using System;
using UnityEngine;

[Serializable]
public class SaveableObjectData
{
	public string objName;

	public int id;

	public int objectType;

	public int parentId;

	public Vector3 position;

	public Quaternion rotation;

	public Vector3 scale;

	public Item item = Item.Empty();

	public bool isSelfStorageComponent;

	public bool isSelfSocketPackageComponent;

	public bool isChildOfNotSavableItemSocket;

	public bool isChildOfStorageComponent;

	public bool isChildOfSocketPackageComponent;

	public Product product;

	public bool dirty;

	public Color color;

	public string socketName;

	public int socketIndex = -1;
}
