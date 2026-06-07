using System;
using UnityEngine;

[ExecuteInEditMode]
public class SceneAnnotation : MonoBehaviour, IComparable<SceneAnnotation>
{
	public string headline = "Headline Goes Here";

	public TextAsset textAsset;

	public int id;

	public void OnDrawGizmos()
	{
	}

	public int CompareTo(SceneAnnotation other)
	{
		int num = id.CompareTo(other.id);
		if (num == 0)
		{
			num = string.Compare(headline, other.headline, StringComparison.Ordinal);
		}
		return num;
	}
}
