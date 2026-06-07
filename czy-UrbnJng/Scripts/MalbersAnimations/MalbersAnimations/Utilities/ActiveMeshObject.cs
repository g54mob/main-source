using System.Collections.Generic;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[CreateAssetMenu(menuName = "Malbers Animations/Tools/ActiveMesh Object")]
	public class ActiveMeshObject : ScriptableObject
	{
		[Tooltip("When this ActiveMesh is Added. Set it as the Current Active Mesh")]
		public bool Activate = true;

		[Tooltip("Actual Static or Skinned Mesh to add to the Animal Controller")]
		public Renderer Mesh;

		[Tooltip("New Set of Materials to add")]
		public Material[] materials;

		[Header("Data")]
		[Tooltip("Name of the Item that will be used to locate it on the set (Optional)")]
		public StringReference ItemName = new StringReference();

		[Tooltip("Set on which the new Mesh Item will be added")]
		public StringReference SetName = new StringReference();

		[Tooltip("Parent of the new Item Mesh")]
		public StringReference Parent = new StringReference();

		[Header("Reactions")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction OnActive;

		[SerializeReference]
		[SubclassSelector]
		public Reaction OnDeactive;

		public void AddMesh(ActiveMeshes ACM)
		{
			ActiveSMesh activeSMesh = ACM.Meshes.Find((ActiveSMesh activeSMesh2) => activeSMesh2.Name == SetName);
			if (activeSMesh == null)
			{
				activeSMesh = new ActiveSMesh
				{
					Name = SetName,
					name = SetName,
					Onwer = ACM,
					MeshItems = new List<MeshItem>()
				};
				ACM.Meshes.Add(activeSMesh);
				if (ACM.debug)
				{
					Debug.Log("<B>Active Mesh</B> Set <B>" + SetName.Value + "</B> Added to the list", this);
				}
			}
			Transform parent = (ACM.Owner.FindGrandChild(Parent.Value) ?? null) ?? ACM.RootBone.FindGrandChild(Parent.Value) ?? ACM.transform;
			if (activeSMesh.MeshItems.Find((MeshItem meshItem2) => meshItem2.Mesh != null && meshItem2.Mesh.name == base.name) != null)
			{
				return;
			}
			MeshItem meshItem = null;
			Renderer renderer = null;
			Transform transform = null;
			foreach (MeshItem meshItem2 in activeSMesh.MeshItems)
			{
				if (meshItem2.MainRenderer is SkinnedMeshRenderer skinnedMeshRenderer && Mesh is SkinnedMeshRenderer skinnedMeshRenderer2)
				{
					if (skinnedMeshRenderer.sharedMesh == skinnedMeshRenderer2.sharedMesh)
					{
						meshItem = meshItem2;
						transform = meshItem2.Mesh;
						renderer = meshItem2.MainRenderer;
						if (ACM.debug)
						{
							Debug.Log("Found Equal Skinned Mesh Renderer (Using same Object)... " + transform.name);
						}
						break;
					}
				}
				else if (meshItem2.MainRenderer is MeshRenderer meshRenderer && Mesh is MeshRenderer meshRenderer2 && meshRenderer.GetComponent<MeshFilter>().sharedMesh == meshRenderer2.GetComponent<MeshFilter>().sharedMesh)
				{
					meshItem = meshItem2;
					transform = meshItem2.Mesh;
					renderer = meshItem2.MainRenderer;
					if (ACM.debug)
					{
						Debug.Log("Found Equal  Mesh Renderer (Using same Object)..." + transform.name);
					}
					break;
				}
			}
			if (meshItem == null)
			{
				renderer = Object.Instantiate(Mesh);
				renderer.gameObject.name = base.name;
				renderer.transform.SetParent(parent);
				renderer.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				transform = renderer.transform;
				if (renderer is SkinnedMeshRenderer skinnedMeshRenderer3 && MTools.ReboneSkinnedMesh(ACM.RootBone, skinnedMeshRenderer3) && ACM.debug)
				{
					Debug.Log("<B>[Active Mesh]</B> - Bone Transfer Completed: [" + skinnedMeshRenderer3.gameObject.name + "]");
				}
			}
			if (materials != null && materials.Length != 0)
			{
				renderer.materials = materials;
			}
			MeshItem item = new MeshItem
			{
				Mesh = transform,
				Parent = parent,
				MeshOn = OnActive,
				MeshOff = OnDeactive,
				ItemName = ItemName,
				materials = materials,
				MainRenderer = renderer
			};
			activeSMesh.MeshItems.Add(item);
			if (Activate)
			{
				activeSMesh.ChangeMesh(activeSMesh.MeshItems.Count - 1);
			}
		}

		public void AddMesh(GameObject MESH)
		{
			ActiveMeshes activeMeshes = MESH.FindComponent<ActiveMeshes>();
			if ((bool)activeMeshes)
			{
				AddMesh(activeMeshes);
			}
		}

		public void AddMesh(Component MESH)
		{
			ActiveMeshes activeMeshes = MESH.FindComponent<ActiveMeshes>();
			if ((bool)activeMeshes)
			{
				AddMesh(activeMeshes);
			}
		}
	}
}
