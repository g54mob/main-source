using System;
using System.Collections.Generic;
using UnityEngine;
using XUGL;

namespace XCharts.Runtime
{
	[Serializable]
	public class SerieData : ChildComponent
	{
		public static List<string> extraFieldList = new List<string> { "m_Id", "m_ParentId", "m_State", "m_Ignore", "m_Selected", "m_Radius" };

		public static Dictionary<Type, string> extraComponentMap = new Dictionary<Type, string>
		{
			{
				typeof(ItemStyle),
				"m_ItemStyles"
			},
			{
				typeof(LabelStyle),
				"m_Labels"
			},
			{
				typeof(LabelLine),
				"m_LabelLines"
			},
			{
				typeof(SerieSymbol),
				"m_Symbols"
			},
			{
				typeof(LineStyle),
				"m_LineStyles"
			},
			{
				typeof(AreaStyle),
				"m_AreaStyles"
			},
			{
				typeof(TitleStyle),
				"m_TitleStyles"
			},
			{
				typeof(EmphasisStyle),
				"m_EmphasisStyles"
			},
			{
				typeof(BlurStyle),
				"m_BlurStyles"
			},
			{
				typeof(SelectStyle),
				"m_SelectStyles"
			}
		};

		[SerializeField]
		private int m_Index;

		[SerializeField]
		private string m_Name;

		[SerializeField]
		private string m_Id;

		[SerializeField]
		private string m_ParentId;

		[SerializeField]
		private bool m_Ignore;

		[SerializeField]
		private bool m_Selected;

		[SerializeField]
		private float m_Radius;

		[SerializeField]
		[Since("v3.2.0")]
		private SerieState m_State = SerieState.Auto;

		[SerializeField]
		[IgnoreDoc]
		private List<ItemStyle> m_ItemStyles = new List<ItemStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<LabelStyle> m_Labels = new List<LabelStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<LabelLine> m_LabelLines = new List<LabelLine>();

		[SerializeField]
		[IgnoreDoc]
		private List<SerieSymbol> m_Symbols = new List<SerieSymbol>();

		[SerializeField]
		[IgnoreDoc]
		private List<LineStyle> m_LineStyles = new List<LineStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<AreaStyle> m_AreaStyles = new List<AreaStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<TitleStyle> m_TitleStyles = new List<TitleStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<EmphasisStyle> m_EmphasisStyles = new List<EmphasisStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<BlurStyle> m_BlurStyles = new List<BlurStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<SelectStyle> m_SelectStyles = new List<SelectStyle>();

		[SerializeField]
		private List<double> m_Data = new List<double>();

		[NonSerialized]
		public SerieDataContext context = new SerieDataContext();

		[NonSerialized]
		public InteractData interact = new InteractData();

		private bool m_Show = true;

		private List<double> m_PreviousData = new List<double>();

		private List<float> m_DataUpdateTime = new List<float>();

		private List<bool> m_DataUpdateFlag = new List<bool>();

		private List<float> m_DataAddTime = new List<float>();

		private List<bool> m_DataAddFlag = new List<bool>();

		private List<Vector2> m_PolygonPoints = new List<Vector2>();

		public ChartLabel labelObject { get; set; }

		public ChartLabel titleObject { get; set; }

		public override int index
		{
			get
			{
				return m_Index;
			}
			set
			{
				m_Index = value;
			}
		}

		public string name
		{
			get
			{
				return m_Name;
			}
			set
			{
				m_Name = value;
			}
		}

		public string id
		{
			get
			{
				return m_Id;
			}
			set
			{
				m_Id = value;
			}
		}

		public string parentId
		{
			get
			{
				return m_ParentId;
			}
			set
			{
				m_ParentId = value;
			}
		}

		public bool ignore
		{
			get
			{
				return m_Ignore;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Ignore, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				m_Radius = value;
			}
		}

		public bool selected
		{
			get
			{
				return m_Selected;
			}
			set
			{
				m_Selected = value;
			}
		}

		public SerieState state
		{
			get
			{
				return m_State;
			}
			set
			{
				m_State = value;
			}
		}

		public string legendName
		{
			get
			{
				if (!string.IsNullOrEmpty(name))
				{
					return name;
				}
				return ChartCached.IntToStr(index);
			}
		}

		public LabelStyle labelStyle
		{
			get
			{
				if (m_Labels.Count <= 0)
				{
					return null;
				}
				return m_Labels[0];
			}
		}

		public LabelLine labelLine
		{
			get
			{
				if (m_LabelLines.Count <= 0)
				{
					return null;
				}
				return m_LabelLines[0];
			}
		}

		public ItemStyle itemStyle
		{
			get
			{
				if (m_ItemStyles.Count <= 0)
				{
					return null;
				}
				return m_ItemStyles[0];
			}
		}

		public SerieSymbol symbol
		{
			get
			{
				if (m_Symbols.Count <= 0)
				{
					return null;
				}
				return m_Symbols[0];
			}
		}

		public LineStyle lineStyle
		{
			get
			{
				if (m_LineStyles.Count <= 0)
				{
					return null;
				}
				return m_LineStyles[0];
			}
		}

		public AreaStyle areaStyle
		{
			get
			{
				if (m_AreaStyles.Count <= 0)
				{
					return null;
				}
				return m_AreaStyles[0];
			}
		}

		public TitleStyle titleStyle
		{
			get
			{
				if (m_TitleStyles.Count <= 0)
				{
					return null;
				}
				return m_TitleStyles[0];
			}
		}

		public EmphasisStyle emphasisStyle
		{
			get
			{
				if (m_EmphasisStyles.Count <= 0)
				{
					return null;
				}
				return m_EmphasisStyles[0];
			}
		}

		public BlurStyle blurStyle
		{
			get
			{
				if (m_BlurStyles.Count <= 0)
				{
					return null;
				}
				return m_BlurStyles[0];
			}
		}

		public SelectStyle selectStyle
		{
			get
			{
				if (m_SelectStyles.Count <= 0)
				{
					return null;
				}
				return m_SelectStyles[0];
			}
		}

		public List<double> data
		{
			get
			{
				return m_Data;
			}
			set
			{
				m_Data = value;
			}
		}

		public bool show
		{
			get
			{
				return m_Show;
			}
			set
			{
				m_Show = value;
			}
		}

		public override bool vertsDirty
		{
			get
			{
				if (!m_VertsDirty && !ChildComponent.IsVertsDirty(labelLine) && !ChildComponent.IsVertsDirty(itemStyle) && !ChildComponent.IsVertsDirty(symbol) && !ChildComponent.IsVertsDirty(lineStyle) && !ChildComponent.IsVertsDirty(areaStyle) && !ChildComponent.IsVertsDirty(emphasisStyle) && !ChildComponent.IsVertsDirty(blurStyle))
				{
					return ChildComponent.IsVertsDirty(selectStyle);
				}
				return true;
			}
		}

		public override bool componentDirty
		{
			get
			{
				if (!m_ComponentDirty && !ChildComponent.IsComponentDirty(labelStyle) && !ChildComponent.IsComponentDirty(labelLine) && !ChildComponent.IsComponentDirty(titleStyle) && !ChildComponent.IsComponentDirty(emphasisStyle) && !ChildComponent.IsComponentDirty(blurStyle))
				{
					return ChildComponent.IsComponentDirty(selectStyle);
				}
				return true;
			}
		}

		public override void ClearVerticesDirty()
		{
			base.ClearVerticesDirty();
			ChildComponent.ClearVerticesDirty(labelLine);
			ChildComponent.ClearVerticesDirty(itemStyle);
			ChildComponent.ClearVerticesDirty(lineStyle);
			ChildComponent.ClearVerticesDirty(areaStyle);
			ChildComponent.ClearVerticesDirty(emphasisStyle);
			ChildComponent.ClearVerticesDirty(blurStyle);
			ChildComponent.ClearVerticesDirty(selectStyle);
		}

		public override void ClearComponentDirty()
		{
			base.ClearComponentDirty();
			ChildComponent.ClearComponentDirty(labelLine);
			ChildComponent.ClearComponentDirty(itemStyle);
			ChildComponent.ClearComponentDirty(lineStyle);
			ChildComponent.ClearComponentDirty(areaStyle);
			ChildComponent.ClearComponentDirty(symbol);
			ChildComponent.ClearComponentDirty(emphasisStyle);
			ChildComponent.ClearComponentDirty(blurStyle);
			ChildComponent.ClearComponentDirty(selectStyle);
		}

		public void Reset()
		{
			index = 0;
			m_Id = null;
			m_ParentId = null;
			labelObject = null;
			m_Name = string.Empty;
			m_Show = true;
			context.Reset();
			interact.Reset();
			m_Data.Clear();
			m_PreviousData.Clear();
			m_DataUpdateTime.Clear();
			m_DataUpdateFlag.Clear();
			m_DataAddTime.Clear();
			m_DataAddFlag.Clear();
			m_Labels.Clear();
			m_LabelLines.Clear();
			m_ItemStyles.Clear();
			m_Symbols.Clear();
			m_LineStyles.Clear();
			m_AreaStyles.Clear();
			m_TitleStyles.Clear();
			m_EmphasisStyles.Clear();
			m_BlurStyles.Clear();
			m_SelectStyles.Clear();
		}

		public void OnAdd(AnimationStyle animation, double startValue = 0.0)
		{
			if (!animation.enable)
			{
				return;
			}
			if (!animation.context.enableSerieDataAddedAnimation)
			{
				animation.Addition();
				return;
			}
			m_DataAddTime.Clear();
			m_DataAddFlag.Clear();
			if (animation.GetAdditionDuration() > 0f)
			{
				for (int i = 0; i < m_Data.Count; i++)
				{
					m_DataAddTime.Add(animation.unscaledTime ? Time.unscaledTime : Time.time);
					m_DataAddFlag.Add(item: true);
				}
			}
		}

		[Obsolete("GetOrAddComponent is obsolete. Use EnsureComponent instead.")]
		public T GetOrAddComponent<T>() where T : ChildComponent, ISerieDataComponent
		{
			return EnsureComponent<T>();
		}

		public T GetComponent<T>() where T : ChildComponent, ISerieDataComponent
		{
			return GetComponentInternal(typeof(T), addIfNotExist: false) as T;
		}

		[Since("v3.6.0")]
		public T EnsureComponent<T>() where T : ChildComponent, ISerieDataComponent
		{
			return GetComponentInternal(typeof(T), addIfNotExist: true) as T;
		}

		[Since("v3.6.0")]
		public ISerieDataComponent EnsureComponent(Type type)
		{
			return GetComponentInternal(type, addIfNotExist: true);
		}

		private ISerieDataComponent GetComponentInternal(Type type, bool addIfNotExist)
		{
			if (type == typeof(ItemStyle))
			{
				if (m_ItemStyles.Count == 0)
				{
					if (!addIfNotExist)
					{
						return null;
					}
					m_ItemStyles.Add(new ItemStyle
					{
						show = true
					});
				}
				return m_ItemStyles[0];
			}
			if (type == typeof(LabelStyle))
			{
				if (m_Labels.Count == 0)
				{
					if (!addIfNotExist)
					{
						return null;
					}
					m_Labels.Add(new LabelStyle
					{
						show = true
					});
				}
				return m_Labels[0];
			}
			if (type == typeof(LabelLine))
			{
				if (m_LabelLines.Count == 0)
				{
					if (!addIfNotExist)
					{
						return null;
					}
					m_LabelLines.Add(new LabelLine
					{
						show = true
					});
				}
				return m_LabelLines[0];
			}
			if (type == typeof(EmphasisStyle))
			{
				if (m_EmphasisStyles.Count == 0)
				{
					if (!addIfNotExist)
					{
						return null;
					}
					m_EmphasisStyles.Add(new EmphasisStyle
					{
						show = true
					});
				}
				return m_EmphasisStyles[0];
			}
			if (type == typeof(BlurStyle))
			{
				if (m_BlurStyles.Count == 0)
				{
					if (!addIfNotExist)
					{
						return null;
					}
					m_BlurStyles.Add(new BlurStyle
					{
						show = true
					});
				}
				return m_BlurStyles[0];
			}
			if (type == typeof(SelectStyle))
			{
				if (m_SelectStyles.Count == 0)
				{
					if (!addIfNotExist)
					{
						return null;
					}
					m_SelectStyles.Add(new SelectStyle
					{
						show = true
					});
				}
				return m_SelectStyles[0];
			}
			if (type == typeof(SerieSymbol))
			{
				if (m_Symbols.Count == 0)
				{
					if (!addIfNotExist)
					{
						return null;
					}
					m_Symbols.Add(new SerieSymbol
					{
						show = true
					});
				}
				return m_Symbols[0];
			}
			if (type == typeof(LineStyle))
			{
				if (m_LineStyles.Count == 0)
				{
					if (!addIfNotExist)
					{
						return null;
					}
					m_LineStyles.Add(new LineStyle
					{
						show = true
					});
				}
				return m_LineStyles[0];
			}
			if (type == typeof(AreaStyle))
			{
				if (m_AreaStyles.Count == 0)
				{
					if (!addIfNotExist)
					{
						return null;
					}
					m_AreaStyles.Add(new AreaStyle
					{
						show = true
					});
				}
				return m_AreaStyles[0];
			}
			if (type == typeof(TitleStyle))
			{
				if (m_TitleStyles.Count == 0)
				{
					if (!addIfNotExist)
					{
						return null;
					}
					m_TitleStyles.Add(new TitleStyle
					{
						show = true
					});
				}
				return m_TitleStyles[0];
			}
			throw new Exception("SerieData not support component:" + type);
		}

		public void RemoveAllComponent()
		{
			m_ItemStyles.Clear();
			m_Labels.Clear();
			m_LabelLines.Clear();
			m_Symbols.Clear();
			m_EmphasisStyles.Clear();
			m_BlurStyles.Clear();
			m_SelectStyles.Clear();
			m_LineStyles.Clear();
			m_AreaStyles.Clear();
			m_TitleStyles.Clear();
		}

		public void RemoveComponent<T>() where T : ISerieDataComponent
		{
			RemoveComponent(typeof(T));
		}

		public void RemoveComponent(Type type)
		{
			if (type == typeof(ItemStyle))
			{
				m_ItemStyles.Clear();
				return;
			}
			if (type == typeof(LabelStyle))
			{
				m_Labels.Clear();
				return;
			}
			if (type == typeof(LabelLine))
			{
				m_LabelLines.Clear();
				return;
			}
			if (type == typeof(EmphasisStyle))
			{
				m_EmphasisStyles.Clear();
				return;
			}
			if (type == typeof(BlurStyle))
			{
				m_BlurStyles.Clear();
				return;
			}
			if (type == typeof(SelectStyle))
			{
				m_SelectStyles.Clear();
				return;
			}
			if (type == typeof(SerieSymbol))
			{
				m_Symbols.Clear();
				return;
			}
			if (type == typeof(LineStyle))
			{
				m_LineStyles.Clear();
				return;
			}
			if (type == typeof(AreaStyle))
			{
				m_AreaStyles.Clear();
				return;
			}
			if (type == typeof(TitleStyle))
			{
				m_TitleStyles.Clear();
				return;
			}
			throw new Exception("SerieData not support component:" + type);
		}

		public double GetData(int index, bool inverse = false)
		{
			if (index >= 0 && index < m_Data.Count)
			{
				if (!inverse)
				{
					return m_Data[index];
				}
				return 0.0 - m_Data[index];
			}
			return 0.0;
		}

		public double GetData(int index, double min, double max)
		{
			if (index >= 0 && index < m_Data.Count)
			{
				double num = m_Data[index];
				if (num < min)
				{
					return min;
				}
				if (num > max)
				{
					return max;
				}
				return num;
			}
			return 0.0;
		}

		public double GetPreviousData(int index, bool inverse = false)
		{
			if (index >= 0 && index < m_PreviousData.Count)
			{
				if (!inverse)
				{
					return m_PreviousData[index];
				}
				return 0.0 - m_PreviousData[index];
			}
			return 0.0;
		}

		public double GetFirstData(bool unscaledTime, float animationDuration = 500f)
		{
			if (m_Data.Count > 0)
			{
				return GetCurrData(0, 0f, animationDuration, unscaledTime);
			}
			return 0.0;
		}

		public double GetLastData()
		{
			if (m_Data.Count > 0)
			{
				return m_Data[m_Data.Count - 1];
			}
			return 0.0;
		}

		public double GetCurrData(int index, AnimationStyle animation, bool inverse = false, bool loop = false)
		{
			if (animation == null || !animation.enable)
			{
				return GetData(index, inverse);
			}
			return GetCurrData(index, animation.GetAdditionDuration(), animation.GetChangeDuration(), inverse, 0.0, 0.0, animation.unscaledTime, loop);
		}

		public double GetCurrData(int index, AnimationStyle animation, bool inverse, double min, double max, bool loop = false)
		{
			if (animation == null || !animation.enable)
			{
				return GetData(index, inverse);
			}
			return GetCurrData(index, animation.GetAdditionDuration(), animation.GetChangeDuration(), inverse, min, max, animation.unscaledTime, loop);
		}

		public double GetCurrData(int index, float dataAddDuration = 500f, float animationDuration = 500f, bool unscaledTime = false, bool inverse = false)
		{
			return GetCurrData(index, dataAddDuration, animationDuration, inverse, 0.0, 0.0, unscaledTime);
		}

		public double GetCurrData(int index, float dataAddDuration, float animationDuration, bool inverse, double min, double max, bool unscaledTime, bool loop = false)
		{
			if (dataAddDuration > 0f && index < m_DataAddFlag.Count && m_DataAddFlag[index])
			{
				float num = (unscaledTime ? Time.unscaledTime : Time.time) - m_DataAddTime[index];
				float num2 = dataAddDuration / 1000f;
				float num3 = num / num2;
				if (num3 > 1f)
				{
					num3 = 1f;
				}
				if (num3 < 1f)
				{
					double a = ((min > 0.0) ? min : 0.0);
					double b = GetData(index);
					double num4 = MathUtil.Lerp(a, b, num3);
					return inverse ? (0.0 - num4) : num4;
				}
				for (int i = 0; i < m_DataAddFlag.Count; i++)
				{
					m_DataAddFlag[i] = false;
				}
				return GetData(index, inverse);
			}
			if (animationDuration > 0f)
			{
				if (index < m_DataUpdateFlag.Count && m_DataUpdateFlag[index])
				{
					float num5 = (unscaledTime ? Time.unscaledTime : Time.time) - m_DataUpdateTime[index];
					float num6 = animationDuration / 1000f;
					float num7 = num5 / num6;
					if (num7 > 1f)
					{
						num7 = 1f;
					}
					if (num7 < 1f)
					{
						CheckLastData(unscaledTime);
						double previousData = GetPreviousData(index);
						double num8 = GetData(index);
						if (loop && num8 <= min && previousData != 0.0)
						{
							num8 = max;
						}
						double num9 = MathUtil.Lerp(previousData, num8, num7);
						if (min != 0.0 || max != 0.0)
						{
							if (inverse)
							{
								double num10 = min;
								min = 0.0 - max;
								max = 0.0 - num10;
							}
							double num11 = m_PreviousData[index];
							if (num11 < min)
							{
								m_PreviousData[index] = min;
								num9 = min;
							}
							else if (num11 > max)
							{
								m_PreviousData[index] = max;
								num9 = max;
							}
						}
						return inverse ? (0.0 - num9) : num9;
					}
					for (int j = 0; j < m_DataUpdateFlag.Count; j++)
					{
						m_DataUpdateFlag[j] = false;
					}
					return GetData(index, inverse);
				}
				return GetData(index, inverse);
			}
			return GetData(index, inverse);
		}

		public double GetAddAnimationData(double min, double max, float animationDuration = 500f, bool unscaledTime = false)
		{
			if (animationDuration > 0f && m_DataAddFlag.Count > 0 && m_DataAddFlag[0])
			{
				float num = (unscaledTime ? Time.unscaledTime : Time.time) - m_DataAddTime[0];
				float num2 = animationDuration / 1000f;
				float num3 = num / num2;
				if (num3 > 1f)
				{
					num3 = 1f;
				}
				if (num3 < 1f)
				{
					return MathUtil.Lerp(min, max, num3);
				}
				for (int i = 0; i < m_DataAddFlag.Count; i++)
				{
					m_DataAddFlag[i] = false;
				}
				return max;
			}
			return max;
		}

		public double GetMaxData(bool inverse = false)
		{
			if (m_Data.Count == 0)
			{
				return 0.0;
			}
			double num = double.MinValue;
			for (int i = 0; i < m_Data.Count; i++)
			{
				double num2 = GetData(i, inverse);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		public double GetMinData(bool inverse = false)
		{
			if (m_Data.Count == 0)
			{
				return 0.0;
			}
			double num = double.MaxValue;
			for (int i = 0; i < m_Data.Count; i++)
			{
				double num2 = GetData(i, inverse);
				if (num2 < num)
				{
					num = num2;
				}
			}
			return num;
		}

		public void GetMinMaxData(int startDimensionIndex, bool inverse, out double min, out double max)
		{
			if (m_Data.Count == 0)
			{
				min = 0.0;
				max = 0.0;
			}
			min = double.MaxValue;
			max = double.MinValue;
			for (int i = startDimensionIndex; i < m_Data.Count; i++)
			{
				double num = GetData(i, inverse);
				if (num < min)
				{
					min = num;
				}
				if (num > max)
				{
					max = num;
				}
			}
		}

		public double GetTotalData()
		{
			double num = 0.0;
			foreach (double datum in m_Data)
			{
				num += datum;
			}
			return num;
		}

		public bool UpdateData(int dimension, double value, bool updateAnimation, bool unscaledTime, float animationDuration = 500f)
		{
			if (dimension >= 0 && dimension < data.Count)
			{
				CheckLastData(unscaledTime);
				m_PreviousData[dimension] = GetCurrData(dimension, 0f, animationDuration, unscaledTime);
				m_DataUpdateTime[dimension] = (unscaledTime ? Time.unscaledTime : Time.time);
				m_DataUpdateFlag[dimension] = updateAnimation;
				data[dimension] = value;
				return true;
			}
			return false;
		}

		public bool UpdateData(int dimension, double value)
		{
			if (dimension >= 0 && dimension < data.Count)
			{
				data[dimension] = value;
				return true;
			}
			return false;
		}

		private void CheckLastData(bool unscaledTime)
		{
			if (m_PreviousData.Count != m_Data.Count)
			{
				m_PreviousData.Clear();
				m_DataUpdateTime.Clear();
				m_DataUpdateFlag.Clear();
				for (int i = 0; i < m_Data.Count; i++)
				{
					m_PreviousData.Add(m_Data[i]);
					m_DataUpdateTime.Add(unscaledTime ? Time.unscaledTime : Time.time);
					m_DataUpdateFlag.Add(item: false);
				}
			}
		}

		public bool IsDataChanged()
		{
			for (int i = 0; i < m_DataUpdateFlag.Count; i++)
			{
				if (m_DataUpdateFlag[i])
				{
					return true;
				}
			}
			for (int j = 0; j < m_DataAddFlag.Count; j++)
			{
				if (m_DataAddFlag[j])
				{
					return true;
				}
			}
			return false;
		}

		public float GetLabelWidth()
		{
			if (labelObject != null)
			{
				return labelObject.GetTextWidth();
			}
			return 0f;
		}

		public float GetLabelHeight()
		{
			if (labelObject != null)
			{
				return labelObject.GetTextHeight();
			}
			return 0f;
		}

		public void SetLabelActive(bool flag)
		{
			if (labelObject != null)
			{
				labelObject.SetActive(flag);
			}
			foreach (ChartLabel dataLabel in context.dataLabels)
			{
				dataLabel.SetActive(flag: false);
			}
		}

		public void SetIconActive(bool flag)
		{
			if (labelObject != null)
			{
				labelObject.SetActive(flag);
			}
		}

		public void SetPolygon(params Vector2[] points)
		{
			m_PolygonPoints.Clear();
			m_PolygonPoints.AddRange(points);
		}

		public void SetPolygon(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
		{
			m_PolygonPoints.Clear();
			m_PolygonPoints.Add(p1);
			m_PolygonPoints.Add(p2);
			m_PolygonPoints.Add(p3);
			m_PolygonPoints.Add(p4);
		}

		public void SetPolygon(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 p5)
		{
			SetPolygon(p1, p2, p3, p4);
			m_PolygonPoints.Add(p5);
		}

		public bool IsInPolygon(Vector2 p)
		{
			return UGLHelper.IsPointInPolygon(p, m_PolygonPoints);
		}
	}
}
