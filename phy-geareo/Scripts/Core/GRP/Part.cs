using System;
using Newtonsoft.Json.Linq;
using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine;

namespace GRP
{
	public abstract class Part : Entity, ISelectable, IExpositorEdit
	{
		private Vector3 _position;

		private Quaternion _rotation;

		public bool isStatic;

		public bool isLocked;

		public Project project;

		public StateSelector<bool> selected;

		public StateSelector<bool> lastSelected;

		public StateSelector<bool> handles;

		public State<int> transform;

		public JObject metadata;

		public bool isCreating;

		public bool isDragging;

		public Vector3 position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public float minSize => 0f;

		public float maxSize => 0f;

		public float changeStep => 0f;

		public new PartConfig config => null;

		public override void OnContext()
		{
		}

		public override void OnExpositorUI(ImUIBuilder ui)
		{
		}

		public string BeautifyName(string value)
		{
			return null;
		}

		public T GetMetadata<T>(string key, T defaultValue = default(T))
		{
			return default(T);
		}

		public bool TryGetMetadata<T>(string key, out T value)
		{
			value = default(T);
			return false;
		}

		public T Field<T>(ImUIBuilder ui, string key, Func<ViewParam[], T> render, string tooltip)
		{
			return default(T);
		}

		public T Field<T>(ImUIBuilder ui, string key, Func<ViewParam[], T> render, Action<Part, T> setter = null, string tooltip = "", float height = 50f)
		{
			return default(T);
		}

		public PartViewable CreateViewable()
		{
			return null;
		}

		protected abstract PartViewable DoCreateViewable();

		public void TransformChanged()
		{
		}

		protected override void Save(JsonData data)
		{
		}

		protected override void Load(JsonData data)
		{
		}

		public void DeserializeDiff(EntityData data)
		{
		}

		protected virtual void LoadDiff(JsonData data)
		{
		}

		public void Adv(Action action, Action notAction)
		{
		}

		public void Adv(Action action)
		{
		}

		public void NotAdv(Action action)
		{
		}

		public float ChangeSizeClampHalf(float startValue, float change)
		{
			return 0f;
		}

		public float ChangeSizeClamp(float startValue, float change)
		{
			return 0f;
		}

		public float ChangeSizeClamp(float startValue, float change, float minSize, float maxSize)
		{
			return 0f;
		}

		public float ChangeSizeClamp(float startValue, float change, float grid, float minSize, float maxSize)
		{
			return 0f;
		}

		public virtual void BuildExhibit(ExhibitBuilder builder)
		{
		}

		public virtual void OnExpositorEditStart()
		{
		}

		public virtual UndoStep OnExpositorEditEnd()
		{
			return null;
		}
	}
	public abstract class Part<TConfig> : Part where TConfig : PartConfig
	{
		public new TConfig config => null;
	}
}
