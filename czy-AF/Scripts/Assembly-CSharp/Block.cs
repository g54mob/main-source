using System;
using UnityEngine;

[Serializable]
public class Block
{
	public string collection;

	public string type;

	public string group = "";

	public string name = "";

	public Texture2D thumbnail;

	public bool locked;

	public bool hidden;

	public bool select;

	public string path;

	public float scale = 1f;

	public Vector3 rotation = Vector3.zero;

	public GameObject model;

	public Block()
	{
	}

	public Block(string _type, string _collection, GameObject _model)
	{
		collection = _collection;
		type = _type;
		model = _model;
	}

	public Block(string _type, string _collection, string _path)
	{
		collection = _collection;
		type = _type;
		path = _path;
	}

	public Block Copy()
	{
		return new Block
		{
			collection = collection,
			type = type,
			group = ""
		};
	}
}
