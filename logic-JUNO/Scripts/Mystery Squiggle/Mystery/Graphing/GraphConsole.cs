using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Mystery.Graphing
{
	public abstract class GraphConsole : IGraphConsole, IEnumerable<IPlottableGraph>, IEnumerable
	{
		private static bool valueNamesEnabled = true;

		private float height = 50f;

		private bool heightIsChanging;

		private float zoom;

		private float pan;

		private bool isPanZooming;

		public static bool ValueNamesEnabled
		{
			get
			{
				return valueNamesEnabled;
			}
			set
			{
				valueNamesEnabled = value;
			}
		}

		public string Name { get; set; }

		public IEnumerable<string> ValueNames { get; set; }

		public float Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
				if (height < 50f)
				{
					height = 50f;
				}
			}
		}

		public bool HeightIsChanging
		{
			get
			{
				return heightIsChanging;
			}
			set
			{
				heightIsChanging = value;
			}
		}

		public float Zoom
		{
			get
			{
				return zoom;
			}
			set
			{
				zoom = Mathf.Clamp(value, 0f, 0.495f);
			}
		}

		public float Pan
		{
			get
			{
				return pan;
			}
			set
			{
				pan = value;
			}
		}

		public bool IsPanZooming
		{
			get
			{
				return isPanZooming;
			}
			set
			{
				isPanZooming = value;
			}
		}

		public virtual bool HasYAxis => true;

		public bool MinLocked { get; private set; }

		public bool MaxLocked { get; private set; }

		public object MinLockValue { get; private set; }

		public object MaxLockValue { get; private set; }

		public virtual bool DisplayMidValue => true;

		public abstract void LockMin();

		public void LockMin(object value)
		{
			MinLocked = true;
			MinLockValue = value;
		}

		public abstract void LockMax();

		public void LockMax(object value)
		{
			MaxLocked = true;
			MaxLockValue = value;
		}

		public void UnlockMin()
		{
			MinLocked = false;
		}

		public void UnlockMax()
		{
			MaxLocked = false;
		}

		protected GraphConsole(string name)
		{
			Name = name;
		}

		public abstract IEnumerator<IPlottableGraph> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public abstract void PlotGLLines();

		public abstract void BuildRTFSampleAt(float x, StringBuilder strBuilder, ref float labelWidth);

		public void Clear()
		{
			using IEnumerator<IPlottableGraph> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.Clear();
			}
		}

		public abstract string GetYMaxString();

		public abstract string GetYMidString();

		public abstract string GetYMinString();

		public void CleanUpHistory(float beforeTime)
		{
			using IEnumerator<IPlottableGraph> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IPlottableGraph current = enumerator.Current;
				if (current is ILinearPlottableGraphOverTime)
				{
					((ILinearPlottableGraphOverTime)current).CleanUpHistory(beforeTime);
				}
			}
		}

		protected string ColorToHex(Color32 color)
		{
			return color.r.ToString("X2").ToLower() + color.g.ToString("X2").ToLower() + color.b.ToString("X2").ToLower();
		}

		public List<IPlottableGraphPoint[]> ExportData()
		{
			List<IPlottableGraphPoint[]> list = new List<IPlottableGraphPoint[]>();
			using IEnumerator<IPlottableGraph> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IPlottableGraph current = enumerator.Current;
				list.Add(current.ExportData());
			}
			return list;
		}

		public abstract object ParseY(string value, object fallback);
	}
}
