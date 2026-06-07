using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Props
	{
		[NonSerialized]
		private Dictionary<int, List<IProp>> m_Props;

		[NonSerialized]
		private Character m_Character;

		[field: NonSerialized]
		public static GameObject LastPropAttachedInstance { get; private set; }

		[field: NonSerialized]
		public static GameObject LastPropAttachedPrefab { get; private set; }

		[field: NonSerialized]
		public static GameObject LastPropDetachedInstance { get; private set; }

		[field: NonSerialized]
		public static GameObject LastPropDetachedPrefab { get; private set; }

		public event Action<Transform, GameObject> EventAdd;

		public event Action<Transform> EventRemove;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitializeOnLoad()
		{
			LastPropAttachedInstance = null;
			LastPropAttachedPrefab = null;
			LastPropDetachedInstance = null;
			LastPropDetachedPrefab = null;
		}

		public Props()
		{
			m_Props = new Dictionary<int, List<IProp>>();
		}

		internal void OnStartup(Character character)
		{
			m_Character = character;
			m_Character.EventAfterChangeModel += OnChangeModel;
		}

		internal void AfterStartup(Character character)
		{
		}

		internal void OnDispose(Character character)
		{
			m_Character = character;
			m_Character.EventAfterChangeModel -= OnChangeModel;
		}

		internal void OnEnable()
		{
		}

		internal void OnDisable()
		{
		}

		public bool HasInstance(GameObject instance)
		{
			if (instance == null)
			{
				return false;
			}
			int instanceID = instance.GetInstanceID();
			foreach (KeyValuePair<int, List<IProp>> prop in m_Props)
			{
				foreach (IProp item in prop.Value)
				{
					if (!(item.Instance == null) && item.Instance.GetInstanceID() == instanceID)
					{
						return true;
					}
				}
			}
			return false;
		}

		public GameObject AttachPrefab(IBone bone, GameObject prefab, Vector3 position, Quaternion rotation)
		{
			if (prefab == null)
			{
				return null;
			}
			int instanceID = prefab.GetInstanceID();
			if (!m_Props.TryGetValue(instanceID, out var value))
			{
				value = new List<IProp>();
				m_Props.Add(instanceID, value);
			}
			PropPrefab propPrefab = new PropPrefab(bone, prefab, position, rotation);
			propPrefab.Create(m_Character.Animim.Animator);
			value.Add(propPrefab);
			LastPropAttachedInstance = propPrefab.Instance;
			LastPropAttachedPrefab = prefab;
			this.EventAdd?.Invoke(propPrefab.Bone, propPrefab.Instance);
			return propPrefab.Instance;
		}

		public GameObject AttachInstance(IBone bone, GameObject instance, Vector3 position, Quaternion rotation)
		{
			if (instance == null)
			{
				return null;
			}
			int instanceID = instance.GetInstanceID();
			if (!m_Props.TryGetValue(instanceID, out var value))
			{
				value = new List<IProp>();
				m_Props.Add(instanceID, value);
			}
			PropInstance propInstance = new PropInstance(bone, instance, position, rotation);
			propInstance.Create(m_Character.Animim.Animator);
			value.Add(propInstance);
			LastPropAttachedInstance = propInstance.Instance;
			LastPropAttachedPrefab = null;
			this.EventAdd?.Invoke(propInstance.Bone, propInstance.Instance);
			return propInstance.Instance;
		}

		public void RemovePrefab(GameObject prefab)
		{
			if (!(prefab == null))
			{
				int instanceID = prefab.GetInstanceID();
				if (m_Props.TryGetValue(instanceID, out var value) && value.Count > 0)
				{
					int index = value.Count - 1;
					Transform bone = value[index].Bone;
					value[index].Destroy();
					value.RemoveAt(index);
					LastPropDetachedInstance = null;
					LastPropDetachedPrefab = prefab;
					this.EventRemove?.Invoke(bone);
				}
			}
		}

		public void RemovePrefab(GameObject prefab, int instanceID)
		{
			if (prefab == null)
			{
				return;
			}
			int instanceID2 = prefab.GetInstanceID();
			if (!m_Props.TryGetValue(instanceID2, out var value) || value.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < value.Count; i++)
			{
				IProp prop = value[i];
				if (!(prop.Instance == null) && prop.Instance.GetInstanceID() == instanceID)
				{
					Transform bone = prop.Bone;
					prop.Destroy();
					value.RemoveAt(i);
					LastPropDetachedInstance = null;
					LastPropDetachedPrefab = prefab;
					this.EventRemove?.Invoke(bone);
					break;
				}
			}
		}

		public void RemoveInstance(GameObject instance)
		{
			if (!(instance == null))
			{
				int instanceID = instance.GetInstanceID();
				if (m_Props.TryGetValue(instanceID, out var value) && value.Count > 0)
				{
					int index = value.Count - 1;
					Transform bone = value[index].Bone;
					value[index].Destroy();
					value.RemoveAt(index);
					LastPropDetachedInstance = null;
					LastPropDetachedPrefab = null;
					this.EventRemove?.Invoke(bone);
				}
			}
		}

		public GameObject DropPrefab(GameObject prefab)
		{
			if (prefab == null)
			{
				return null;
			}
			int instanceID = prefab.GetInstanceID();
			if (!m_Props.TryGetValue(instanceID, out var value))
			{
				return null;
			}
			if (value.Count <= 0)
			{
				return null;
			}
			int index = value.Count - 1;
			Transform bone = value[index].Bone;
			GameObject instance = value[index].Instance;
			value[index].Drop();
			value.RemoveAt(index);
			LastPropDetachedInstance = instance;
			LastPropDetachedPrefab = prefab;
			Action<Transform> action = this.EventRemove;
			if (action != null)
			{
				action(bone);
				return instance;
			}
			return instance;
		}

		public GameObject DropPrefab(GameObject prefab, int instanceID)
		{
			if (prefab == null)
			{
				return null;
			}
			int instanceID2 = prefab.GetInstanceID();
			if (!m_Props.TryGetValue(instanceID2, out var value))
			{
				return null;
			}
			if (value.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < value.Count; i++)
			{
				IProp prop = value[i];
				if (!(prop.Instance == null) && prop.Instance.GetInstanceID() == instanceID)
				{
					Transform bone = prop.Bone;
					GameObject instance = prop.Instance;
					prop.Drop();
					value.RemoveAt(i);
					LastPropDetachedInstance = instance;
					LastPropDetachedPrefab = prefab;
					this.EventRemove?.Invoke(bone);
					return instance;
				}
			}
			return null;
		}

		public void DropInstance(GameObject instance)
		{
			if (!(instance == null))
			{
				int instanceID = instance.GetInstanceID();
				if (m_Props.TryGetValue(instanceID, out var value) && value.Count > 0)
				{
					int index = value.Count - 1;
					Transform bone = value[index].Bone;
					value[index].Drop();
					value.RemoveAt(index);
					LastPropDetachedInstance = instance;
					LastPropDetachedPrefab = null;
					this.EventRemove?.Invoke(bone);
				}
			}
		}

		public void RemoveAtBone(IBone bone)
		{
			Transform transform = bone.GetTransform(m_Character.Animim.Animator);
			if (transform == null)
			{
				return;
			}
			foreach (KeyValuePair<int, List<IProp>> prop2 in m_Props)
			{
				for (int num = prop2.Value.Count - 1; num >= 0; num--)
				{
					IProp prop = prop2.Value[num];
					if (!(prop.Bone != transform))
					{
						prop.Destroy();
						prop2.Value.RemoveAt(num);
						LastPropDetachedInstance = null;
						LastPropDetachedPrefab = null;
						this.EventRemove?.Invoke(transform);
					}
				}
			}
		}

		public void DropAtBone(IBone bone)
		{
			Transform transform = bone.GetTransform(m_Character.Animim.Animator);
			if (transform == null)
			{
				return;
			}
			foreach (KeyValuePair<int, List<IProp>> prop2 in m_Props)
			{
				for (int num = prop2.Value.Count - 1; num >= 0; num--)
				{
					IProp prop = prop2.Value[num];
					if (!(prop.Bone != transform))
					{
						prop.Drop();
						prop2.Value.RemoveAt(num);
						LastPropDetachedInstance = prop.Instance;
						LastPropDetachedPrefab = null;
						this.EventRemove?.Invoke(transform);
					}
				}
			}
		}

		public void RemoveAll()
		{
			foreach (KeyValuePair<int, List<IProp>> prop in m_Props)
			{
				foreach (IProp item in prop.Value)
				{
					item.Destroy();
					LastPropDetachedInstance = null;
					LastPropDetachedPrefab = null;
					this.EventRemove?.Invoke(item.Bone);
				}
			}
			m_Props.Clear();
		}

		public void DropAll()
		{
			foreach (KeyValuePair<int, List<IProp>> prop in m_Props)
			{
				foreach (IProp item in prop.Value)
				{
					item.Drop();
					LastPropDetachedInstance = item.Instance;
					LastPropDetachedPrefab = null;
					this.EventRemove?.Invoke(item.Bone);
				}
			}
			m_Props.Clear();
		}

		public bool HasAtBone(IBone bone)
		{
			Transform transform = bone.GetTransform(m_Character.Animim.Animator);
			if (transform == null)
			{
				return false;
			}
			foreach (KeyValuePair<int, List<IProp>> prop in m_Props)
			{
				for (int num = prop.Value.Count - 1; num >= 0; num--)
				{
					if (!(prop.Value[num]?.Bone != transform))
					{
						return true;
					}
				}
			}
			return false;
		}

		public GameObject AttachSkinMesh(GameObject prefab)
		{
			if (prefab == null)
			{
				return null;
			}
			int instanceID = prefab.GetInstanceID();
			if (!m_Props.TryGetValue(instanceID, out var value))
			{
				value = new List<IProp>();
				m_Props.Add(instanceID, value);
			}
			PropSkin propSkin = new PropSkin(prefab);
			propSkin.Create(m_Character.Animim.Animator);
			value.Add(propSkin);
			LastPropAttachedInstance = propSkin.Instance;
			LastPropAttachedPrefab = prefab;
			this.EventAdd?.Invoke(null, propSkin.Instance);
			return propSkin.Instance;
		}

		public void RemoveSkinMesh(GameObject prefab)
		{
			if (!(prefab == null))
			{
				int instanceID = prefab.GetInstanceID();
				if (m_Props.TryGetValue(instanceID, out var value) && value.Count > 0)
				{
					int index = value.Count - 1;
					value[index].Destroy();
					value.RemoveAt(index);
					LastPropDetachedPrefab = prefab;
					LastPropDetachedInstance = null;
					this.EventRemove?.Invoke(null);
				}
			}
		}

		private void OnChangeModel()
		{
			foreach (KeyValuePair<int, List<IProp>> prop in m_Props)
			{
				foreach (IProp item in prop.Value)
				{
					item.Destroy();
					this.EventRemove?.Invoke(item.Bone);
					item.Create(m_Character.Animim.Animator);
					this.EventAdd?.Invoke(item.Bone, item.Instance);
				}
			}
		}
	}
}
