using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

[MoonSharpUserData]
public class Forge : MonoBehaviour
{
	public void print(string s)
	{
		Global.ShowMessage(s);
		Debug.Log(s);
	}

	public void build(string type, float[] position, float[] rotation, float[] scale)
	{
		string[] array = Procedural.ParseBlock(type);
		GameObject gameObject = Collections.CreateBlock(array[0], array[1], addComponent: true);
		if (!(gameObject == null))
		{
			gameObject.transform.SetParent(Global.elements["workbench"], worldPositionStays: false);
			gameObject.transform.position = Procedural.ParseVector(position);
			gameObject.transform.eulerAngles = Procedural.ParseVector(rotation);
			gameObject.transform.localScale = Procedural.ParseVector(scale);
			Collections.PrepareBlock(gameObject);
		}
	}

	public void build(string type, Vector3 position, Vector3 rotation, Vector3 scale)
	{
		build(type, Procedural.UnparseVector(position), Procedural.UnparseVector(rotation), Procedural.UnparseVector(scale));
	}

	public void build(string type, float[] position, float[] rotation)
	{
		build(type, position, rotation, new float[3] { 1f, 1f, 1f });
	}

	public void build(string type, float[] position)
	{
		build(type, position, new float[3], new float[3] { 1f, 1f, 1f });
	}

	public void invertSelection()
	{
		Transform[] array = Selection.list.ToArray();
		Selection.Clear();
		foreach (Transform item in Global.SceneBlocks())
		{
			if (Array.IndexOf(array, item) == -1)
			{
				Selection.Add(item);
			}
		}
	}

	public void replaceSelection(string replace)
	{
		Transform[] array = Selection.list.ToArray();
		Selection.Clear();
		Transform[] array2 = array;
		foreach (Transform obj in array2)
		{
			Vector3 position = obj.position;
			Vector3 eulerAngles = obj.eulerAngles;
			Vector3 localScale = obj.localScale;
			build(replace, position, eulerAngles, localScale);
			UnityEngine.Object.DestroyImmediate(obj.gameObject);
		}
	}

	public void physicsSelection()
	{
		foreach (Transform item in Selection.list)
		{
			if (!item.gameObject.GetComponent<PhysicsBlock>())
			{
				item.gameObject.AddComponent<PhysicsBlock>();
			}
		}
	}

	public void moveSelection(float[] position)
	{
		Vector3 vector = Procedural.ParseVector(position);
		foreach (Transform item in Selection.list)
		{
			item.position += vector;
		}
	}

	public void rotateSelection(float[] rotation)
	{
		Vector3 vector = Procedural.ParseVector(rotation);
		foreach (Transform item in Selection.list)
		{
			item.eulerAngles += vector;
		}
	}

	public void scaleSelection(float[] scale)
	{
		Vector3 vector = Procedural.ParseVector(scale);
		foreach (Transform item in Selection.list)
		{
			item.localScale += vector;
		}
	}

	public void selectAll()
	{
		Selection.SelectAll();
	}

	public void selectAll(string type)
	{
		Selection.Clear();
		string[] array = Procedural.ParseBlock(type);
		foreach (Transform item in Global.SceneBlocks())
		{
			if (!(item.GetComponent<BlockComponent>() == null))
			{
				BlockComponent component = item.GetComponent<BlockComponent>();
				if (component.data.collection == array[0] && component.data.type == array[1])
				{
					Selection.Add(item);
				}
			}
		}
	}

	public void selectNone()
	{
		Selection.Clear();
	}

	public bool selectRandom(string block)
	{
		string[] array = Procedural.ParseBlock(block);
		List<Transform> list = Global.SceneBlocks();
		List<Transform> list2 = new List<Transform>();
		foreach (Transform item in list)
		{
			if (!(item.GetComponent<BlockComponent>() == null))
			{
				BlockComponent component = item.GetComponent<BlockComponent>();
				if (component.data.collection == array[0] && component.data.type == array[1])
				{
					list2.Add(item);
				}
			}
		}
		if (list2.Count == 0)
		{
			return false;
		}
		Selection.Add(list2[UnityEngine.Random.Range(0, list2.Count)]);
		return true;
	}

	public void selectRandom()
	{
		if (Global.SceneBlocks().Count > 0)
		{
			Selection.Add(Global.SceneBlocks()[UnityEngine.Random.Range(0, Global.SceneBlocks().Count)]);
		}
	}

	public void showSelection()
	{
		foreach (Transform item in Selection.list)
		{
			item.GetComponent<BlockComponent>().data.hidden = false;
			item.gameObject.layer = 0;
		}
	}

	public void hideSelection()
	{
		foreach (Transform item in Selection.list)
		{
			item.GetComponent<BlockComponent>().data.hidden = true;
			item.gameObject.layer = LayerMask.NameToLayer("Hidden");
		}
	}

	public void deleteSelection()
	{
		List<Transform> list = new List<Transform>();
		foreach (Transform item in Selection.list)
		{
			list.Add(item);
		}
		Selection.Clear();
		foreach (Transform item2 in list)
		{
			UnityEngine.Object.Destroy(item2.gameObject);
		}
	}

	public void groupSelection()
	{
		Groups.CreateGroup(Selection.list);
	}

	public void groupSelection(string name)
	{
		Groups.CreateGroup(Selection.list, name);
	}

	public void ungroupSelection()
	{
		foreach (Transform item in Selection.list)
		{
			item.GetComponent<BlockComponent>().data.group = "";
		}
	}

	public string getBlockType()
	{
		if (Selection.list.Count > 0)
		{
			string collection = Selection.list[0].GetComponent<BlockComponent>().data.collection;
			string type = Selection.list[0].GetComponent<BlockComponent>().data.type;
			return collection + "/" + type;
		}
		return "";
	}

	public float getSelectionX()
	{
		return Global.elements["selection"].transform.position.x;
	}

	public float getSelectionY()
	{
		return Global.elements["selection"].transform.position.y;
	}

	public float getSelectionZ()
	{
		return Global.elements["selection"].transform.position.z;
	}

	public float getNoise(int x, int y)
	{
		return Mathf.PerlinNoise((float)x + 0.1f, (float)y + 0.1f);
	}

	public void clear()
	{
		Project.instance.ClearIEnumerator();
	}

	public void materialColor(string material, string hex)
	{
		foreach (Material datum in Swatches.data)
		{
			if (datum.name == material)
			{
				datum.color = Global.Hex(hex);
				break;
			}
		}
	}

	public void exportSprite(int size, string path)
	{
		Export.ExportSprite(size, path);
	}

	public void load(string path)
	{
		Project.LoadFile(path);
	}

	public void save(string path)
	{
		Project.SaveFile($"{path}.model");
	}
}
