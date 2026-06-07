using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Dhs5.Utility.Debuggers;
using TMPro;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ObjectStack : MonoBehaviour, IEnumerable<IStackable>, IEnumerable
	{
		[Header("Stack")]
		[SerializeField]
		protected Transform m_container;

		[SerializeField]
		protected Bounds m_bounds;

		[Header("Parameters")]
		[SerializeField]
		protected bool m_spacing;

		[SerializeField]
		protected EnabledValue<int> m_limit;

		[SerializeField]
		protected bool m_acceptUnfit;

		[Header("Clipping")]
		[SerializeField]
		protected ClippingObjectBehaviour.ELayerType m_defaultClippingLayer;

		[SerializeField]
		protected bool m_delayClippingLayerSet;

		protected ClippingObjectBehaviour.ELayerType m_currentClippingLayer;

		[Header("Counter")]
		[SerializeField]
		protected bool m_enableCounter;

		[SerializeField]
		[Show("m_enableCounter", false)]
		protected TextMeshPro m_counterText;

		protected IStackable[] m_stack;

		protected ProductData m_productData;

		protected TrashData m_trashData;

		protected bool m_currentFitIn;

		protected Vector3Int m_layout;

		protected Vector3 m_actualSpacing;

		protected int m_stackingCount;

		protected readonly HashSet<int> m_reservedIndexes = new HashSet<int>();

		public int Size => m_stack.Length;

		public int Count { get; protected set; }

		public virtual int ActualCount => Count + m_stackingCount;

		public Bounds Bounds => m_bounds;

		public ClippingObjectBehaviour.ELayerType ClippingLayer
		{
			get
			{
				return m_currentClippingLayer;
			}
			set
			{
				if (m_currentClippingLayer != value)
				{
					m_currentClippingLayer = value;
					SetContentClippingObjectLayer(m_currentClippingLayer);
				}
			}
		}

		public event Action PreStacked;

		public event Action Stacked;

		public event Action Poped;

		public event Action<ProductData> StackedNewProduct;

		public event Action StackEmpty;

		protected virtual void Awake()
		{
			UpdateCounter();
			ClippingLayer = m_defaultClippingLayer;
		}

		public bool HasStackable()
		{
			return Count > 0;
		}

		public bool CanWelcome(IStackableData data)
		{
			if (data == null)
			{
				return false;
			}
			IStackable.EType currentType = GetCurrentType();
			if (currentType != IStackable.EType.NONE && data.StackableType != currentType)
			{
				return false;
			}
			int currentUID = GetCurrentUID();
			if (currentType == IStackable.EType.PRODUCT && currentUID != 0 && currentUID != data.UID)
			{
				return false;
			}
			if (DoesStackableFitInBounds(data.Bounds) || m_acceptUnfit)
			{
				return true;
			}
			Debugger<EDebugCategory>.LogError(EDebugCategory.PRODUCT, $"{data} does not fit in bounds", onScreen: true, this);
			return false;
		}

		public IStackable.EType GetCurrentType()
		{
			if (CanPeak())
			{
				return Peak().StackableData.StackableType;
			}
			if (ActualCount > 0)
			{
				if (m_productData != null)
				{
					return IStackable.EType.PRODUCT;
				}
				if (m_trashData != null)
				{
					return IStackable.EType.TRASH;
				}
			}
			return IStackable.EType.NONE;
		}

		public int GetCurrentUID()
		{
			if (CanPeak())
			{
				return Peak().StackableData.UID;
			}
			if (ActualCount > 0)
			{
				if (m_productData != null)
				{
					return m_productData.UID;
				}
				if (m_trashData != null)
				{
					return m_trashData.UID;
				}
			}
			return 0;
		}

		public IStackableData GetCurrentData()
		{
			if (CanPeak())
			{
				return Peak().StackableData;
			}
			if (ActualCount > 0)
			{
				if (m_productData != null)
				{
					return m_productData;
				}
				if (m_trashData != null)
				{
					return m_trashData;
				}
			}
			return null;
		}

		public bool CanPeak()
		{
			return Count > 0;
		}

		private IStackable Peak()
		{
			return m_stack[GetLastOccupiedIndex()];
		}

		public bool TryPeek(out IStackable stackable)
		{
			if (CanPeak())
			{
				stackable = Peak();
				return true;
			}
			stackable = null;
			return false;
		}

		public bool IsStackHomogeneous()
		{
			if (!HasStackable())
			{
				return true;
			}
			int currentUID = GetCurrentUID();
			for (int i = 0; i < Count; i++)
			{
				if (m_stack[i].StackableData.UID != currentUID)
				{
					return false;
				}
			}
			return true;
		}

		public bool TryGetStackUIDs(out List<int> uids)
		{
			uids = new List<int>();
			if (HasStackable())
			{
				using (IEnumerator<IStackable> enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IStackable current = enumerator.Current;
						if (current != null && current.StackableData.UID != 0)
						{
							uids.Add(current.StackableData.UID);
						}
					}
				}
				return true;
			}
			return false;
		}

		public virtual void Stack(IStackable stackable)
		{
			this.PreStacked?.Invoke();
			stackable.OnPreStackedIn(this);
			int firstAvailableIndex = GetFirstAvailableIndex();
			OnStack(firstAvailableIndex, stackable);
			stackable.Anchor(m_container, GetIndexedStackPosition(firstAvailableIndex, stackable.Bounds));
		}

		public virtual void AnimatedStack(IStackable stackable, AnimationPath path, Action stackingCompleteCallback = null)
		{
			if (!path.IsValid)
			{
				path.Init();
			}
			this.PreStacked?.Invoke();
			stackable.OnPreStackedIn(this);
			int index = GetFirstAvailableIndex();
			ReserveIndex(index);
			Tween animatedStackTween = GetAnimatedStackTween(index, stackable, path);
			if (!m_delayClippingLayerSet)
			{
				SetClippingObjectLayerToCurrent(stackable.ClippingObjectBehaviour);
			}
			m_stackingCount++;
			animatedStackTween.onComplete = delegate
			{
				m_stackingCount--;
				UnreserveIndex(index);
				OnStack(index, stackable);
				stackingCompleteCallback?.Invoke();
			};
			animatedStackTween.Play();
		}

		public bool CanPop()
		{
			return HasStackable();
		}

		public virtual IStackable Pop()
		{
			int lastOccupiedIndex = GetLastOccupiedIndex();
			IStackable stackable = m_stack[lastOccupiedIndex];
			OnUnstacked(lastOccupiedIndex, stackable);
			stackable.OnUnstackedFrom(this);
			return stackable;
		}

		public bool HasSpaceLeft()
		{
			if (m_stack == null)
			{
				return true;
			}
			return Size > ActualCount;
		}

		protected virtual Vector3 GetIndexedStackPosition(int index, Bounds stackableBounds)
		{
			Vector3Int zero = Vector3Int.zero;
			while (index >= m_layout.x * m_layout.z)
			{
				zero.y++;
				index -= m_layout.x * m_layout.z;
			}
			while (index >= m_layout.x)
			{
				zero.z++;
				index -= m_layout.x;
			}
			zero.x = index;
			Vector3 vector = new Vector3(m_bounds.size.x, stackableBounds.size.y, m_bounds.size.z);
			Vector3 vector2 = new Vector3(vector.x / (float)m_layout.x, vector.y, vector.z / (float)m_layout.z);
			return m_bounds.min + new Vector3(vector2.x * ((float)zero.x + 0.5f), vector2.y * ((float)zero.y + 0.5f), vector2.z * ((float)zero.z + 0.5f)) - stackableBounds.center;
		}

		protected void ComputeFlatLayout(Bounds stackableBounds)
		{
			if (!m_currentFitIn)
			{
				if (stackableBounds.size.x <= m_bounds.size.x)
				{
					int num = Mathf.FloorToInt(m_bounds.size.x / stackableBounds.size.x);
					if (m_limit.IsEnabled(out var value))
					{
						num = Mathf.Min(num, value);
					}
					m_layout = new Vector3Int(num, 1, 1);
				}
				else if (stackableBounds.size.z <= m_bounds.size.z)
				{
					int num2 = Mathf.FloorToInt(m_bounds.size.z / stackableBounds.size.z);
					if (m_limit.IsEnabled(out var value2))
					{
						num2 = Mathf.Min(num2, value2);
					}
					m_layout = new Vector3Int(1, 1, num2);
				}
				else
				{
					m_layout = Vector3Int.one;
				}
				return;
			}
			m_layout = new Vector3Int(Mathf.FloorToInt(m_bounds.size.x / stackableBounds.size.x), Mathf.Max(1, Mathf.FloorToInt(m_bounds.size.y / stackableBounds.size.y)), Mathf.FloorToInt(m_bounds.size.z / stackableBounds.size.z));
			if (!m_limit.IsEnabled(out var value3))
			{
				return;
			}
			while (m_layout.x * m_layout.y * m_layout.z > value3)
			{
				if (m_layout.y > 1)
				{
					m_layout.y--;
				}
				else if (m_layout.x > value3)
				{
					m_layout = new Vector3Int(value3, 1, 1);
				}
				else if (m_layout.z > 1)
				{
					m_layout.z--;
				}
			}
		}

		protected void ComputeSpacing(Bounds stackableBounds)
		{
			if (!m_currentFitIn)
			{
				m_actualSpacing = Vector3.zero;
			}
			else
			{
				m_actualSpacing = (m_spacing ? new Vector3((m_bounds.size.x - stackableBounds.size.x * (float)m_layout.x) / (float)(m_layout.x + 1), 0f, (m_bounds.size.z - stackableBounds.size.z * (float)m_layout.z) / (float)(m_layout.z + 1)) : Vector3.zero);
			}
		}

		private bool DoesStackableFitInBounds(IStackable stackable)
		{
			if (stackable == null)
			{
				return false;
			}
			return DoesStackableFitInBounds(stackable.Bounds);
		}

		private bool DoesStackableFitInBounds(Bounds bounds)
		{
			if (bounds.size.x <= m_bounds.size.x)
			{
				return bounds.size.z <= m_bounds.size.z;
			}
			return false;
		}

		protected virtual void OnStack(int index, IStackable stackable)
		{
			if (m_stack == null)
			{
				OnStackNewType(stackable);
			}
			m_stack[index] = stackable;
			Count++;
			int num = 0;
			for (int i = 0; i < Count; i++)
			{
				if (m_stack[i] != null)
				{
					num++;
				}
			}
			UpdateCounter();
			SetClippingObjectLayerToCurrent(stackable.ClippingObjectBehaviour);
			this.Stacked?.Invoke();
			stackable.OnStackedIn(this);
		}

		protected virtual Tween GetAnimatedStackTween(int index, IStackable stackable, AnimationPath path)
		{
			if (m_stack == null)
			{
				OnStackNewType(stackable);
			}
			path.Add(base.transform.TransformPoint(GetIndexedStackPosition(index, stackable.Bounds)));
			return stackable.AnimatedAnchor(m_container, path, ProductsSettings.StackingAnimDuration);
		}

		protected virtual void OnUnstacked(int index, IStackable stackable)
		{
			m_stack[index] = null;
			Count--;
			UpdateCounter();
			SetClippingObjectLayer(stackable.ClippingObjectBehaviour, ClippingObjectBehaviour.ELayerType.DEFAULT);
			stackable.transform.SetParent(null);
			this.Poped?.Invoke();
			if (ActualCount == 0)
			{
				OnEmpty();
			}
		}

		protected virtual void OnStackNewType(IStackable stackable)
		{
			switch (stackable.StackableData.StackableType)
			{
			case IStackable.EType.PRODUCT:
				m_productData = stackable.StackableData as ProductData;
				break;
			case IStackable.EType.TRASH:
				m_trashData = stackable.StackableData as TrashData;
				break;
			}
			m_currentFitIn = DoesStackableFitInBounds(stackable);
			ComputeFlatLayout(stackable.Bounds);
			ComputeSpacing(stackable.Bounds);
			m_stack = new IStackable[m_layout.x * m_layout.y * m_layout.z];
			if (stackable.StackableData.StackableType == IStackable.EType.PRODUCT)
			{
				this.StackedNewProduct?.Invoke(m_productData);
			}
		}

		protected virtual void OnEmpty()
		{
			m_productData = null;
			m_trashData = null;
			m_stack = null;
			this.StackEmpty?.Invoke();
		}

		public IEnumerator<IStackable> GetEnumerator()
		{
			if (!HasStackable())
			{
				yield break;
			}
			for (int i = Size - 1; i >= 0; i--)
			{
				if (m_stack[i] != null)
				{
					yield return m_stack[i];
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		protected virtual void SetContentClippingObjectLayer(ClippingObjectBehaviour.ELayerType layer)
		{
			using IEnumerator<IStackable> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IStackable current = enumerator.Current;
				if (current != null)
				{
					SetClippingObjectLayer(current.ClippingObjectBehaviour, layer);
				}
			}
		}

		protected void SetClippingObjectLayer(ClippingObjectBehaviour clippingObjectBehaviour, ClippingObjectBehaviour.ELayerType layerType)
		{
			clippingObjectBehaviour.SetRenderersLayer(layerType);
		}

		protected void SetClippingObjectLayerToCurrent(ClippingObjectBehaviour clippingObjectBehaviour)
		{
			SetClippingObjectLayer(clippingObjectBehaviour, ClippingLayer);
		}

		protected virtual int GetFirstAvailableIndex()
		{
			if (m_stack == null)
			{
				return 0;
			}
			if (Size > ActualCount)
			{
				for (int i = 0; i < Size; i++)
				{
					if (m_stack[i] == null && !IsIndexReserved(i))
					{
						return i;
					}
				}
			}
			return -1;
		}

		protected virtual int GetLastOccupiedIndex()
		{
			for (int num = Size - 1; num >= 0; num--)
			{
				if (m_stack[num] != null)
				{
					return num;
				}
			}
			return -1;
		}

		protected virtual bool ReserveIndex(int index)
		{
			return m_reservedIndexes.Add(index);
		}

		protected virtual void UnreserveIndex(int index)
		{
			m_reservedIndexes.Remove(index);
		}

		protected bool IsIndexReserved(int index)
		{
			return m_reservedIndexes.Contains(index);
		}

		protected virtual void UpdateCounter()
		{
			if (m_enableCounter && m_counterText != null)
			{
				if (Count > 0)
				{
					m_counterText.text = "x" + Count;
					m_counterText.enabled = true;
				}
				else
				{
					m_counterText.enabled = false;
				}
			}
		}
	}
}
