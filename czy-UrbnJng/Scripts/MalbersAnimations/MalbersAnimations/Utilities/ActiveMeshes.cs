using System.Collections.Generic;
using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Mesh/Active Meshes")]
	public class ActiveMeshes : MonoBehaviour
	{
		[Tooltip("Root Bone for any skinned mesh. See Mesh Avatar")]
		public Transform RootBone;

		[Tooltip("Main Object owner of the Active Mesh Component")]
		public Transform Owner;

		public List<ActiveSMesh> Meshes = new List<ActiveSMesh>();

		public bool showMeshesList = true;

		public bool debug;

		public ActiveSMesh Pinned;

		public Int2Event OnMeshChanged = new Int2Event();

		[SerializeField]
		private bool MeshItemUpdated;

		[SerializeField]
		private int selectedMeshIndex;

		public bool random;

		public ActiveSMesh this[int index]
		{
			get
			{
				return Meshes[index];
			}
			set
			{
				Meshes[index] = value;
			}
		}

		public int Count => Meshes.Count;

		public string AllIndex
		{
			get
			{
				string text = "";
				for (int i = 0; i < Count; i++)
				{
					text = text + Meshes[i].Current + " ";
				}
				text.Remove(text.Length - 1);
				return text;
			}
			set
			{
				string[] array = value.Split(' ');
				for (int i = 0; i < Count; i++)
				{
					if (array.Length > i && int.TryParse(array[i], out var result) && result != -1)
					{
						Meshes[i].ChangeMesh(result);
					}
				}
			}
		}

		public bool SyncMeshItem()
		{
			if (MeshItemUpdated)
			{
				return false;
			}
			bool flag = false;
			foreach (ActiveSMesh mesh in Meshes)
			{
				flag = mesh.SyncMesh() || flag;
				Debug.Log("<B>[Active Mesh]</B> Syncing Mesh Items on <B>" + mesh.Name + "</B>", this);
			}
			if (!Application.isPlaying)
			{
				MeshItemUpdated = true;
				Debug.Log("[" + base.name + "] <b>[Active Mesh]</b> Updated. Save the Prefab", this);
				MTools.SetDirty(this);
			}
			return true;
		}

		public bool ReviewNames()
		{
			bool flag = false;
			foreach (ActiveSMesh mesh in Meshes)
			{
				if (mesh.MeshItems == null)
				{
					continue;
				}
				foreach (MeshItem meshItem in mesh.MeshItems)
				{
					flag = meshItem.SetParameters() || flag;
				}
			}
			if (flag)
			{
				MTools.SetDirty(this);
			}
			return flag;
		}

		[ContextMenu("Reset Sync")]
		private void ResetSync()
		{
			MeshItemUpdated = false;
			SyncMeshItem();
			MTools.SetDirty(this);
		}

		[ContextMenu("Fill Extra Parameters")]
		public void SetExtraParameters()
		{
			foreach (ActiveSMesh mesh in Meshes)
			{
				foreach (MeshItem meshItem in mesh.MeshItems)
				{
					if (string.IsNullOrEmpty(meshItem.ItemName))
					{
						meshItem.ItemName = ((meshItem.Mesh != null) ? meshItem.Mesh.name : ("No " + mesh.Name));
					}
					if ((bool)meshItem.Mesh && (meshItem.Renderers == null || meshItem.Renderers.Length == 0))
					{
						meshItem.Renderers = meshItem.Mesh.GetComponentsInChildren<Renderer>();
					}
				}
			}
			Debug.Log("Extra Parameters Completed. Names and LODs", this);
			if (RootBone == null)
			{
				Animator componentInParent = GetComponentInParent<Animator>();
				if ((bool)componentInParent)
				{
					RootBone = componentInParent.avatarRoot;
				}
			}
			if (Owner == null)
			{
				Owner = GetComponentInParent<IObjectCore>().transform;
			}
			MTools.SetDirty(this);
		}

		private void Start()
		{
			SyncMeshItem();
			Initialize();
			if (random)
			{
				Randomize();
			}
		}

		private void Initialize()
		{
			if (Owner == null)
			{
				Owner = base.transform;
			}
			foreach (ActiveSMesh mesh in Meshes)
			{
				mesh.Initialize(this);
			}
		}

		public void Randomize()
		{
			for (int i = 0; i < Meshes.Count; i++)
			{
				ActiveSMesh activeSMesh = Meshes[i];
				if (activeSMesh.MeshItems != null && activeSMesh.MeshItems.Count != 0)
				{
					int index = Random.Range(0, activeSMesh.MeshItems.Count);
					activeSMesh.ChangeMesh(index);
					OnMeshChanged.Invoke(i, activeSMesh.Current);
				}
			}
		}

		public void SetActiveMeshesIndex(int[] MeshesIndex)
		{
			if (MeshesIndex.Length != Count)
			{
				Debug.LogError("Meshes Index array Lenghts don't match");
				return;
			}
			for (int i = 0; i < MeshesIndex.Length; i++)
			{
				Meshes[i].ChangeMesh(MeshesIndex[i]);
				OnMeshChanged.Invoke(i, Meshes[i].Current);
			}
		}

		public virtual void ChangeMesh(int index)
		{
			ActiveSMesh activeSMesh = Meshes[index % Count];
			activeSMesh.ChangeMesh();
			OnMeshChanged.Invoke(index % Count, activeSMesh.Current);
		}

		public virtual void ChangeMesh(int index, int IndexMesh)
		{
			ActiveSMesh activeSMesh = Meshes[index % Count];
			activeSMesh.ChangeMesh(IndexMesh - 1);
			OnMeshChanged.Invoke(index % Count, activeSMesh.Current);
		}

		public virtual void ChangeMesh(string name, bool next)
		{
			int num = Meshes.FindIndex((ActiveSMesh item) => item.Name == name);
			if (num != -1)
			{
				Meshes[num].ChangeMesh(next);
				OnMeshChanged.Invoke(num, Meshes[num].Current);
			}
		}

		public virtual void ChangeMesh(string name)
		{
			ChangeMesh(name, next: true);
		}

		public virtual void ChangeMesh(string name, int CurrentIndex)
		{
			int num = Meshes.FindIndex((ActiveSMesh item) => item.Name == name);
			if (num != -1)
			{
				Meshes[num].ChangeMesh(CurrentIndex);
				OnMeshChanged.Invoke(num, Meshes[num].Current);
			}
		}

		public virtual void ChangeMesh(int index, bool next)
		{
			Meshes[index].ChangeMesh(next);
			OnMeshChanged.Invoke(index, Meshes[index].Current);
		}

		public virtual void ChangeMesh(bool next = true)
		{
			for (int i = 0; i < Meshes.Count; i++)
			{
				Meshes[i].ChangeMesh(next);
				OnMeshChanged.Invoke(i, Meshes[i].Current);
			}
		}

		public virtual ActiveSMesh GetActiveMesh(string name)
		{
			if (Count == 0)
			{
				return null;
			}
			return Meshes.Find((ActiveSMesh item) => item.Name == name);
		}

		public virtual ActiveSMesh GetActiveMesh(int index)
		{
			index = Mathf.Clamp(index, 0, Count - 1);
			return Meshes[index];
		}

		public virtual void Pin_Mesh(int index)
		{
			Pinned = GetActiveMesh(index);
		}

		public virtual void Pin_Mesh(string name)
		{
			Pinned = GetActiveMesh(name);
		}

		public virtual void Pin_SetMesh(int index)
		{
			Pinned.ChangeMesh(index - 1);
		}
	}
}
