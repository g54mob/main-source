using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	public class EntityObjectSync : MonoBehaviour
	{
		private Transform _syncPositionParent;

		private Dictionary<EntityObject, Transform> _syncedEntityObjects;

		private Vector3 _scale;

		private Vector3 _pivotPosition;

		private Quaternion _pivotRotation;

		private bool _canRefresh;

		private Transform SyncPositionParent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 Scale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 PivotPosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion PivotRotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public event EventHandler<EventArgs> SyncedEntitiesChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public IEnumerable<EntityObject> GetEntityObjects()
		{
			return null;
		}

		public IEnumerable<EntityObject> GetFlattenedEntityObjects(bool excludeGroupObjects = false)
		{
			return null;
		}

		public void Select(params EntityObject[] entityObjects)
		{
		}

		public void Add(EntityObject obj, bool addSilently = false)
		{
		}

		public void Remove(EntityObject obj, bool removeSilently = false)
		{
		}

		private void OnDestroy()
		{
		}

		public void ResetRotations()
		{
		}

		public void ResetScale()
		{
		}

		public void Refresh(float duration = 0f)
		{
		}

		private void Update()
		{
		}

		public void OnHandlePressedChanged(bool isPressed)
		{
		}

		public void ShowOutlines(bool show = true)
		{
		}

		public void Clear(bool clearSilently = false)
		{
		}

		public bool HasEntities()
		{
			return false;
		}

		public void OnEntitiesChanged()
		{
		}
	}
}
