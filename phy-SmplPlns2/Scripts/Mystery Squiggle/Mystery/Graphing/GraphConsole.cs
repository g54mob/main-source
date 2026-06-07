using System.Collections;
using System.Collections.Generic;
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

		public bool MinLocked { get; set; }

		public bool MaxLocked { get; set; }

		public IValueRange RangeX { get; set; }

		public IValueRange RangeY { get; set; }

		public IValueTransformer TransformerX { get; protected set; }

		public IValueTransformer TransformerY { get; protected set; }

		public virtual bool DisplayMidValue => true;

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

		public abstract void GetSamplesAt(float x, List<GraphPointSample> samples);

		public void Clear(bool resetRanges)
		{
			using IEnumerator<IPlottableGraph> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.Clear();
				if (resetRanges)
				{
					RangeX.Reset();
					RangeY.Reset();
				}
			}
		}

		public string GetMaxXString()
		{
			if (TransformerX == null)
			{
				return "-";
			}
			return TransformerX.ToString(RangeX.Max);
		}

		public string GetMidXString()
		{
			if (TransformerX == null)
			{
				return "-";
			}
			return TransformerX.ToString(TransformerX.GetMid(RangeX.Min, RangeX.Max));
		}

		public string GetMinXString()
		{
			if (TransformerX == null)
			{
				return "-";
			}
			return TransformerX.ToString(RangeX.Min);
		}

		public string GetMaxYString()
		{
			if (TransformerY == null)
			{
				return "-";
			}
			return TransformerY.ToString(RangeY.Max);
		}

		public string GetMidYString()
		{
			if (TransformerY == null)
			{
				return "-";
			}
			return TransformerY.ToString(TransformerY.GetMid(RangeY.Min, RangeY.Max));
		}

		public string GetMinYString()
		{
			if (TransformerY == null)
			{
				return "-";
			}
			return TransformerY.ToString(RangeY.Min);
		}

		public void CleanUpBefore(float time, bool onlyCleanUpSharedTime = true)
		{
			if (onlyCleanUpSharedTime && RangeX is TimeRange && !((TimeRange)RangeX).UseSharedTime)
			{
				return;
			}
			using IEnumerator<IPlottableGraph> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IPlottableGraph current = enumerator.Current;
				if (current is ILineGraphOverTime && (!onlyCleanUpSharedTime || ((TimeRange)current.DefaultRangeX).UseSharedTime))
				{
					((ILineGraphOverTime)current).CleanUpBefore(time);
				}
			}
		}

		public void CleanUpAfter(float time, bool onlyCleanUpSharedTime = true)
		{
			if (onlyCleanUpSharedTime && RangeX is TimeRange && !((TimeRange)RangeX).UseSharedTime)
			{
				return;
			}
			using IEnumerator<IPlottableGraph> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IPlottableGraph current = enumerator.Current;
				if (current is ILineGraphOverTime && (!onlyCleanUpSharedTime || ((TimeRange)current.DefaultRangeX).UseSharedTime))
				{
					((ILineGraphOverTime)current).CleanUpAfter(time);
				}
			}
		}

		public void ResetBounds()
		{
			using (IEnumerator<IPlottableGraph> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.ResetBounds();
				}
			}
			RangeX.Reset();
			RangeY.Reset();
			UpdateValueRange();
		}

		protected abstract void UpdateValueRange();

		public List<ILineGraphPoint[]> ExportData()
		{
			List<ILineGraphPoint[]> list = new List<ILineGraphPoint[]>();
			using IEnumerator<IPlottableGraph> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IPlottableGraph current = enumerator.Current;
				list.Add(current.ExportData());
			}
			return list;
		}

		public object ParseX(string value, object fallback)
		{
			return TransformerX.Parse(value, fallback);
		}

		public object ParseY(string value, object fallback)
		{
			return TransformerY.Parse(value, fallback);
		}

		public abstract void SetUseSharedTime(bool value);
	}
}
