using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DV.JObjectExtstensions;
using DV.Logic.Job;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization
{
	public abstract class Customization : MonoBehaviour
	{
		public abstract class CustomizerBase : MonoBehaviour
		{
			protected readonly JObject serializationData = new JObject();

			public Customization Custom { get; private set; }

			public int Index { get; private set; } = -1;

			public bool IsLinked
			{
				get
				{
					if (Custom != null)
					{
						return Index >= 0;
					}
					return false;
				}
			}

			public bool IsLODLoaded { get; private set; } = true;

			public ReadOnlyCollection<CustomizerLODObject> LODObjects { get; private set; }

			public bool ArePlacementRequirementsMet { get; private set; }

			protected event Action BeforeLinked;

			public event Action<CustomizerBase, Customization> AfterLinked;

			public event Action<CustomizerBase, Customization> BeforeUnlinked;

			public event Action<CustomizerBase, Customization> AfterUnlinked;

			protected virtual void OnBeforeLinked()
			{
				ArePlacementRequirementsMet = IsValidTarget(Custom, null);
			}

			protected virtual void OnAfterLinked()
			{
			}

			protected virtual void OnBeforeUnlinked()
			{
			}

			protected virtual void OnAfterUnlinked()
			{
			}

			protected virtual void Awake()
			{
				LODObjects = new ReadOnlyCollection<CustomizerLODObject>(GetComponentsInChildren<CustomizerLODObject>());
				foreach (CustomizerLODObject lODObject in LODObjects)
				{
					lODObject.SetBase(this);
				}
			}

			public void Link(Customization custom)
			{
				if (custom == null)
				{
					Unlink();
					return;
				}
				if (Custom != null)
				{
					throw new InvalidOperationException("[CUSTOMIZATION] This Modification is already assigned to a loco!");
				}
				Custom = custom;
				try
				{
					this.BeforeLinked?.Invoke();
					OnBeforeLinked();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception, this);
				}
				Index = custom.customizerList.Count;
				custom.customizerList.Add(this);
				OnAfterLinked();
				this.AfterLinked?.Invoke(this, custom);
				custom.ModLinked?.Invoke(this);
				Debug.Log("[CUSTOMIZATION] Linked " + base.gameObject.name, this);
				SetLODState(custom.ShouldLODBeLoaded(this));
			}

			public void Unlink()
			{
				if (!(Custom == null))
				{
					SetLODState(loaded: false);
					Customization custom = Custom;
					custom.BeforeModUnlinked?.Invoke(this);
					this.BeforeUnlinked?.Invoke(this, custom);
					OnBeforeUnlinked();
					custom.customizerList.Remove(this);
					Index = -1;
					try
					{
						OnAfterUnlinked();
						this.AfterUnlinked?.Invoke(this, custom);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception, this);
					}
					Custom = null;
					custom.AfterModUnlinked?.Invoke(this);
					Debug.Log("[CUSTOMIZATION] Unlinked " + base.gameObject.name);
				}
			}

			protected virtual void LODStateChanged(bool newLODState)
			{
			}

			public virtual void SaveDataRequested(JObject dst)
			{
			}

			public virtual void SaveDataLoaded(JObject src)
			{
			}

			public virtual void AfterSaveDataLoaded(JObject src)
			{
			}

			public virtual bool IsValidTarget(Customization target, Collider hitCollider)
			{
				return true;
			}

			public void SetLODState(bool loaded)
			{
				if (IsLODLoaded == loaded)
				{
					return;
				}
				IsLODLoaded = loaded;
				foreach (CustomizerLODObject lODObject in LODObjects)
				{
					lODObject.gameObject.SetActive(loaded);
				}
				LODStateChanged(loaded);
			}
		}

		private const string KEY_HOLES = "holes";

		private const string KEY_HOLE_POSITION = "pos";

		private const string KEY_HOLE_DIRECTION = "dir";

		private const string PREFAB_NAME_HOLE = "drilled_hole";

		public const float HOLE_RADIUS = 0.01f;

		private readonly List<CustomizerBase> customizerList = new List<CustomizerBase>();

		private readonly HashSet<Collider> holes = new HashSet<Collider>();

		private JObject data;

		private GameObject holePrefab;

		public ReadOnlyCollection<CustomizerBase> Customizers { get; private set; }

		public int HoleCount => holes.Count;

		public IReadOnlyCollection<Collider> Holes => holes;

		public event Action<CustomizerBase> ModLinked;

		public event Action<CustomizerBase> BeforeModUnlinked;

		public event Action<CustomizerBase> AfterModUnlinked;

		public abstract string GetIdentificationKey();

		public static bool TryGetFromIdentificationKey(string key, out Customization result)
		{
			result = GetFromIdentificationKey(key);
			return result != null;
		}

		public static Customization GetFromIdentificationKey(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return null;
			}
			switch (key)
			{
			case ":global:":
				return SingletonCustomization<WorldCustomization>.I;
			case ":storage:":
				return SingletonCustomization<StorageShedCustomization>.I;
			case ":player_house:":
				return SingletonCustomization<PlayerHouseCustomization>.I;
			case ":paint_station:":
				return SingletonCustomization<PaintStationCustomization>.I;
			default:
			{
				if (SingletonBehaviour<IdGenerator>.Instance.carGuidToCar.TryGetValue(key, out var value) && SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar.TryGetValue(value, out var value2))
				{
					return value2.Customization;
				}
				return null;
			}
			}
		}

		public static Customization Resolve(GameObject go)
		{
			Customization componentInParentIncludingInactive = go.GetComponentInParentIncludingInactive<Customization>();
			if (componentInParentIncludingInactive != null)
			{
				return componentInParentIncludingInactive;
			}
			TrainCar trainCar = TrainCar.Resolve(go);
			if (trainCar != null)
			{
				return trainCar.GetComponent<Customization>();
			}
			ItemStaticParent componentInParentIncludingInactive2 = go.GetComponentInParentIncludingInactive<ItemStaticParent>();
			if (componentInParentIncludingInactive2 != null)
			{
				if (componentInParentIncludingInactive2 is StorageStaticParent)
				{
					return SingletonCustomization<StorageShedCustomization>.I;
				}
				if (componentInParentIncludingInactive2 is ItemStaticParentPaintStation)
				{
					return SingletonCustomization<PaintStationCustomization>.I;
				}
				return SingletonCustomization<PlayerHouseCustomization>.I;
			}
			if (go.GetComponentInParentIncludingInactive<Rigidbody>() == null)
			{
				return SingletonCustomization<WorldCustomization>.I;
			}
			return null;
		}

		protected virtual void Awake()
		{
			Customizers = customizerList.AsReadOnly();
			holePrefab = Resources.Load<GameObject>("drilled_hole");
		}

		protected virtual void OnDestroy()
		{
		}

		public virtual Transform GetParentingTransform()
		{
			return base.transform;
		}

		public void Add(CustomizerBase mod)
		{
			mod.Link(this);
		}

		public void Remove(CustomizerBase mod)
		{
			if (mod.Custom == this)
			{
				mod.Unlink();
			}
		}

		public CustomizerBase Remove(int index)
		{
			CustomizerBase customizerBase = customizerList[index];
			customizerBase.Unlink();
			return customizerBase;
		}

		public bool TryGetCustomizerByUID(int uid, out TrainCarCustomization.TrainCarCustomizerBase customizer)
		{
			customizer = null;
			foreach (CustomizerBase customizer2 in Customizers)
			{
				if (customizer2 is TrainCarCustomization.TrainCarCustomizerBase trainCarCustomizerBase && trainCarCustomizerBase.UID == uid)
				{
					customizer = trainCarCustomizerBase;
					return true;
				}
			}
			return false;
		}

		public Collider AddHole(Vector3 localPosition, Vector3 localNormal)
		{
			Collider component = UnityEngine.Object.Instantiate(holePrefab, base.transform.position, Quaternion.identity, GetParentingTransform()).GetComponent<Collider>();
			holes.Add(component);
			component.transform.localPosition = localPosition;
			component.transform.localRotation = Quaternion.LookRotation(localNormal);
			return component;
		}

		public bool RemoveHole(Collider holeCollider)
		{
			if (holes.Remove(holeCollider))
			{
				UnityEngine.Object.Destroy(holeCollider.gameObject);
				return true;
			}
			return false;
		}

		public void ClearHoles()
		{
			foreach (Collider hole in holes)
			{
				UnityEngine.Object.Destroy(hole.gameObject);
			}
			holes.Clear();
		}

		public bool IsHole(Collider holeCollider)
		{
			return holes.Contains(holeCollider);
		}

		public bool FindHole(Vector3 localPosition, float radius, out Collider holeCollider)
		{
			holeCollider = FindHole(localPosition, radius);
			return holeCollider != null;
		}

		public bool FindHole(Vector3 localPosition, out Collider holeCollider)
		{
			holeCollider = FindHole(localPosition);
			return holeCollider != null;
		}

		public Collider FindHole(Vector3 localPosition, float radius = 0.01f)
		{
			radius *= radius;
			foreach (Collider hole in holes)
			{
				if ((hole.transform.localPosition - localPosition).sqrMagnitude < radius)
				{
					return hole;
				}
			}
			return null;
		}

		public void MoveHole(Collider hole, Vector3 localPosition, Vector3 localNormal)
		{
			if (holes.Contains(hole))
			{
				hole.transform.localPosition = localPosition;
				hole.transform.localRotation = Quaternion.LookRotation(localNormal);
			}
		}

		public void RecheckAllLODStates()
		{
			foreach (CustomizerBase customizer in Customizers)
			{
				customizer.SetLODState(ShouldLODBeLoaded(customizer));
			}
		}

		protected abstract bool ShouldLODBeLoaded(CustomizerBase customizer);

		public JObject Serialize()
		{
			if (data == null)
			{
				data = new JObject();
			}
			JObject[] array = new JObject[holes.Count];
			int num = 0;
			foreach (Collider hole in holes)
			{
				JObject jObject = new JObject();
				array[num++] = jObject;
				jObject.SetVector3("pos", hole.transform.localPosition);
				jObject.SetVector3("dir", hole.transform.localRotation * Vector3.forward);
			}
			data.SetJObjectArray("holes", array);
			return data;
		}

		public void Deserialize(JObject data)
		{
			ClearHoles();
			JObject[] array = data?.GetJObjectArray("holes");
			if (array == null)
			{
				Debug.LogError("[CUSTOMIZATION] There was no data for deserialization of " + base.gameObject.name + "! This can happen when loading old saves.");
				return;
			}
			JObject[] array2 = array;
			foreach (JObject dataObject in array2)
			{
				Vector3? vector = dataObject.GetVector3("pos");
				Vector3? vector2 = dataObject.GetVector3("dir");
				if (vector.HasValue && vector2.HasValue)
				{
					AddHole(vector.Value, vector2.Value);
				}
			}
		}
	}
}
