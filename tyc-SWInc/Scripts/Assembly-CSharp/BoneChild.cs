using System.Linq;
using UnityEngine;

public class BoneChild : MonoBehaviour
{
	private Transform[] Bones;

	public GameObject BoneParent;

	private void Start()
	{
		InitBones();
		if (BoneParent != null)
		{
			SetParent(BoneParent);
		}
	}

	private void InitBones()
	{
		if (Bones == null)
		{
			Bones = (from x in GetComponentsInChildren<Transform>()
				where x != base.transform && x.GetComponent<SkinnedMeshRenderer>() == null
				select x).ToArray();
		}
	}

	private void OnDestroy()
	{
		foreach (Transform item in Bones.Where((Transform x) => x != null))
		{
			Object.Destroy(item.gameObject);
		}
	}

	public void SetParent(GameObject parent)
	{
		InitBones();
		Transform[] componentsInChildren = parent.GetComponentsInChildren<Transform>();
		BoneParent = parent;
		base.transform.parent = parent.transform;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		base.transform.localScale = Vector3.one;
		Transform[] bones = Bones;
		foreach (Transform bone in bones)
		{
			Transform transform = componentsInChildren.FirstOrDefault((Transform x) => x.name.Equals(bone.name));
			if (transform != null)
			{
				bone.parent = transform;
			}
			bone.localPosition = Vector3.zero;
			bone.localRotation = Quaternion.identity;
			bone.name = "Rigged" + bone.name;
		}
	}
}
