using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Mesh/Bone Scaler")]
	public class BoneScaler : MonoBehaviour
	{
		[CreateScriptableAsset]
		public BonePreset preset;

		[ContextMenuItem("Refresh Bones", "SetBones")]
		public Transform Root;

		[Delayed]
		public string[] Filter = new string[21]
		{
			"Pivot", "Attack", "Track", "Trigger", "Camera", "Target", "Fire", "Debug", "AI", "Look",
			"Appearance", "Interaction", "Internal", "Mesh", "Rotator", "Effect", "Stamina", "Sound", "Cinemachine", "Audio",
			"Particle"
		};

		public List<Transform> Bones = new List<Transform>();

		[ContextMenu("Refresh Bones")]
		public void SetBones()
		{
			if ((bool)Root)
			{
				Bones = Root.GetComponentsInChildren<Transform>().ToList();
			}
			List<Transform> list = new List<Transform>();
			foreach (Transform bone in Bones)
			{
				bool flag = false;
				if ((bool)bone.GetComponent<SkinnedMeshRenderer>() || !bone.gameObject.activeSelf)
				{
					continue;
				}
				for (int i = 0; i < Filter.Length; i++)
				{
					if (bone.name.ToLower().Contains(Filter[i].ToLower()))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(bone);
				}
			}
			Bones = list;
		}

		public void SavePreset()
		{
			if ((bool)preset)
			{
				preset.Bones = new List<MiniTransform>();
				for (int i = 0; i < Bones.Count; i++)
				{
					preset.Bones.Add(new MiniTransform(Bones[i].name, Bones[i].localPosition, Bones[i].localScale));
				}
				if (base.transform.name == Bones[0].name)
				{
					preset.Bones[0].name = "Root";
				}
				MTools.SetDirty(this);
				Debug.Log("Preset: " + preset.name + " Saved from " + base.name);
			}
			else
			{
				Debug.LogWarning("There's no Preset Asset to save the bones");
			}
		}

		private void Reset()
		{
			Root = base.transform;
			SetBones();
		}

		public void LoadPreset()
		{
			if ((bool)preset)
			{
				Bones = base.transform.GetComponentsInChildren<Transform>().ToList();
				List<Transform> list = new List<Transform>();
				if (preset.Bones[0].name == "Root")
				{
					if (preset.scales)
					{
						base.transform.localScale = preset.Bones[0].Scale;
					}
					Root = base.transform;
					list.Add(base.transform);
				}
				foreach (MiniTransform bone in preset.Bones)
				{
					Transform transform = Bones.Find((Transform item) => item.name == bone.name);
					if ((bool)transform)
					{
						if (preset.positions)
						{
							transform.localPosition = bone.Position;
						}
						if (preset.scales)
						{
							transform.localScale = bone.Scale;
						}
						list.Add(transform);
					}
				}
				Bones = list;
				Debug.Log("Preset: " + preset.name + " Loaded on " + base.name);
			}
			else
			{
				Debug.LogWarning("There's no Preset to Load from");
			}
		}
	}
}
