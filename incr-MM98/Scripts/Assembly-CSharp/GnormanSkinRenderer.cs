using R3;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class GnormanSkinRenderer : MonoBehaviour
{
	private void Awake()
	{
		Database.State.Customization.Gnorman.Subscribe(GetComponent<SkinnedMeshRenderer>(), delegate(GnormanSkin x, SkinnedMeshRenderer r)
		{
			r.material.mainTexture = x.Value().texture;
		}).AddTo(this);
	}
}
