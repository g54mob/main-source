using System;
using UnityEngine;

public class UserImageFrame : MonoBehaviour, IFurnitureSerialization
{
	public Furniture Parent;

	public Renderer Image;

	public Transform Left;

	public Transform Right;

	public Transform Top;

	public Transform Bottom;

	public Transform FrameHolder;

	public float Scale = 1f;

	public float FrameThickness = 0.1f;

	[NonSerialized]
	private string _imageName;

	public string ImageName
	{
		get
		{
			return _imageName;
		}
	}

	public void Init()
	{
		SetImage(_imageName);
	}

	public static void ApplyTo(Material mat, float fullScale, float frameThickness, Renderer image, Transform left, Transform right, Transform top, Transform bottom, Transform holder)
	{
		image.sharedMaterial = mat;
		float num = (float)mat.mainTexture.width / (float)mat.mainTexture.height;
		float num2 = fullScale / 2f + frameThickness / 2f;
		float num3 = frameThickness * 2f + fullScale;
		float num4 = 1f / (1f + frameThickness * 2f);
		holder.localScale = new Vector3(num4, num4, 1f);
		bool flag = left != null;
		if (num > 1f)
		{
			float num5 = 1f / num * fullScale;
			float num6 = num5 / 2f + frameThickness / 2f;
			image.transform.localScale = new Vector3(fullScale * num4, num5 * num4, 1f);
			if (flag)
			{
				left.localPosition = new Vector3(num2, 0f, left.localPosition.z);
				left.localScale = new Vector3(frameThickness, num5, frameThickness);
				right.localPosition = new Vector3(0f - num2, 0f, right.localPosition.z);
				right.localScale = new Vector3(frameThickness, num5, frameThickness);
				top.localPosition = new Vector3(0f, num6, top.localPosition.z);
				top.localScale = new Vector3(num3, frameThickness, frameThickness);
				bottom.localPosition = new Vector3(0f, 0f - num6, bottom.localPosition.z);
				bottom.localScale = new Vector3(num3, frameThickness, frameThickness);
			}
		}
		else
		{
			float num7 = num * fullScale;
			float num8 = num7 / 2f + frameThickness / 2f;
			image.transform.localScale = new Vector3(num7 * num4, fullScale * num4, 1f);
			if (flag)
			{
				left.localPosition = new Vector3(num8, 0f, left.localPosition.z);
				left.localScale = new Vector3(frameThickness, num3, frameThickness);
				right.localPosition = new Vector3(0f - num8, 0f, right.localPosition.z);
				right.localScale = new Vector3(frameThickness, num3, frameThickness);
				top.localPosition = new Vector3(0f, num2, top.localPosition.z);
				top.localScale = new Vector3(num7, frameThickness, frameThickness);
				bottom.localPosition = new Vector3(0f, 0f - num2, bottom.localPosition.z);
				bottom.localScale = new Vector3(num7, frameThickness, frameThickness);
			}
		}
	}

	public void SetImage(string imageFile)
	{
		Material value;
		if (imageFile != null && GameData.UserImages.TryGetValue(imageFile, out value))
		{
			_imageName = imageFile;
		}
		else
		{
			if (_imageName != null)
			{
				_imageName = null;
			}
			value = GameData.UserImages["defaultuserimage"];
		}
		ApplyTo(value, Scale, FrameThickness, Image, Left, Right, Top, Bottom, FrameHolder);
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["imageFile"] = _imageName;
	}

	public void Deserialize(WriteDictionary dict, bool loading)
	{
		_imageName = dict.Get<string>("imageFile", null);
		Init();
	}

	public void PostDeserialize()
	{
	}
}
