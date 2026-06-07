using System;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class ActiveSMesh
	{
		[HideInInspector]
		public string Name = "NameHere";

		public StringReference name = new StringReference();

		[HideInInspector]
		public bool Active = true;

		[HideInInspector]
		[SerializeField]
		public Transform[] meshes;

		public List<MeshItem> MeshItems;

		[HideInInspector]
		[SerializeField]
		public int Current;

		[SerializeField]
		[HideInInspector]
		private int CurrentMeshItemIndex;

		public TransformEvent OnSetMeshChange = new TransformEvent();

		public MeshItem CurrentItem { get; set; }

		public ActiveMeshes Onwer { get; set; }

		public bool SyncMesh()
		{
			bool result = false;
			if (MeshItems == null || MeshItems.Count != meshes.Length)
			{
				MeshItems = new List<MeshItem>();
				Transform[] array = meshes;
				foreach (Transform mesh in array)
				{
					MeshItems.Add(new MeshItem
					{
						Mesh = mesh
					});
				}
				result = true;
			}
			return result;
		}

		public virtual void ChangeMesh(bool next = true)
		{
			if (!Active)
			{
				return;
			}
			if (next)
			{
				Current++;
			}
			else
			{
				Current--;
			}
			if (Current >= MeshItems.Count)
			{
				Current = 0;
			}
			if (Current < 0)
			{
				Current = MeshItems.Count - 1;
			}
			for (int i = 0; i < MeshItems.Count; i++)
			{
				MeshItem meshItem = MeshItems[i];
				if (i == Current)
				{
					continue;
				}
				if ((bool)meshItem.Mesh)
				{
					if (meshItem.Mesh.gameObject.IsPrefab())
					{
						Debug.LogWarning("<B>[Active Mesh]</B> Mesh <B>" + meshItem.ItemName + "</B> is a Prefab. It will not be deactivated", Onwer);
						continue;
					}
					if (meshItem.Mesh.gameObject.activeSelf)
					{
						meshItem.Mesh.gameObject.SetActive(value: false);
						if (Application.isPlaying)
						{
							meshItem.MeshOff?.React(Onwer);
							ActiveSMesh hideSet = GetHideSet(meshItem);
							Unhide_Set(hideSet);
						}
					}
				}
				MeshItem meshItem2 = MeshItems[Current];
				if ((bool)meshItem2.Mesh)
				{
					if (meshItem2.Mesh.gameObject.IsPrefab())
					{
						Debug.LogWarning("<B>[Active Mesh]</B> Mesh <B>" + meshItem2.ItemName + "</B> is a Prefab. It will not be activated", Onwer);
						continue;
					}
					meshItem2.Mesh.gameObject.SetActive(value: true);
					meshItem2.UpdateMaterials();
					if (Application.isPlaying)
					{
						ActiveSMesh hideSet2 = GetHideSet(meshItem2);
						Hide_Set(hideSet2);
					}
				}
				if (Application.isPlaying)
				{
					meshItem2.MeshOn?.React(Onwer);
					OnSetMeshChange.Invoke(meshItem2.Mesh);
				}
				CurrentItem = meshItem2;
			}
		}

		internal ActiveSMesh GetHideSet(MeshItem NewItem)
		{
			if (!string.IsNullOrEmpty(NewItem.HideSet))
			{
				return Onwer.Meshes.Find((ActiveSMesh item) => item.Name == NewItem.HideSet);
			}
			return null;
		}

		internal void Hide_Set(ActiveSMesh HideSetMesh)
		{
			if (HideSetMesh == null)
			{
				return;
			}
			foreach (MeshItem meshItem in HideSetMesh.MeshItems)
			{
				meshItem.Mesh.gameObject.SetActive(value: false);
			}
		}

		internal void Unhide_Set(ActiveSMesh HideSetMesh)
		{
			HideSetMesh?.ChangeMesh(HideSetMesh.Current);
		}

		public virtual void ChangeMesh(int Index)
		{
			if (Active)
			{
				Current = Index - 1;
				ChangeMesh();
			}
		}

		public void Set_by_BinaryIndex(int binaryCurrent)
		{
			int index = 0;
			for (int i = 0; i < MeshItems.Count; i++)
			{
				if (MTools.IsBitActive(binaryCurrent, i))
				{
					index = i;
					break;
				}
			}
			ChangeMesh(index);
		}

		internal void Initialize(ActiveMeshes owner)
		{
			foreach (MeshItem meshItem in MeshItems)
			{
				if (meshItem.Mesh != null && meshItem.Mesh.gameObject.IsPrefab())
				{
					meshItem.Mesh = UnityEngine.Object.Instantiate(meshItem.Mesh);
					meshItem.Renderers = meshItem.Mesh.GetComponentsInChildren<Renderer>();
					Renderer[] renderers = meshItem.Renderers;
					for (int i = 0; i < renderers.Length; i++)
					{
						if (renderers[i] is SkinnedMeshRenderer skinnedMeshRenderer && MTools.ReboneSkinnedMesh(owner.RootBone, skinnedMeshRenderer) && owner.debug)
						{
							Debug.Log("<B>[Active Mesh]</B> - Bone Transfer Completed: [" + skinnedMeshRenderer.gameObject.name + "]", skinnedMeshRenderer);
						}
					}
				}
				meshItem.SetParameters();
				if ((bool)meshItem.Mesh)
				{
					if (meshItem.MainRenderer == null)
					{
						meshItem.MainRenderer = meshItem.Mesh.GetComponentInChildren<Renderer>();
					}
					if ((bool)meshItem.MainRenderer && (meshItem.materials == null || meshItem.materials.Length == 0))
					{
						meshItem.materials = meshItem.MainRenderer.sharedMaterials;
					}
					meshItem.UpdateMaterials();
				}
				meshItem.SetParent();
			}
			Onwer = owner;
			if (MeshItems != null && MeshItems.Count > 0)
			{
				Current = Mathf.Clamp(Current, 0, MeshItems.Count - 1);
				CurrentItem = MeshItems[Current];
			}
		}
	}
}
