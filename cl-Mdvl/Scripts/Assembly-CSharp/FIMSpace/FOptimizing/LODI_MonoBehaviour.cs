using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public sealed class LODI_MonoBehaviour : ILODInstance
	{
		[Serializable]
		public class ParameterHelper
		{
			public bool Change;

			public int ParamID;

			public int TypeID;

			public string ParamName;

			public string ParamType;

			public bool Supported = true;

			public int Int;

			public float Float;

			public Vector2 Vec2;

			public Vector3 Vec3;

			public Color Color;

			public bool Bool;

			public ParameterHelper(string name, string type)
			{
				ParamID = name.GetHashCode();
				ParamName = name;
				TypeID = type.GetHashCode();
				ParamType = type;
				Supported = true;
			}

			public void SetValue(int valueId, object value)
			{
				if (valueId == intId)
				{
					Int = (int)value;
				}
				else if (valueId == floatId)
				{
					Float = (float)value;
				}
				else if (valueId == boolId)
				{
					Bool = (bool)value;
				}
				else if (valueId == colorId)
				{
					Color = (Color)value;
				}
			}

			public object GetValue(int valueId)
			{
				if (valueId == intId)
				{
					return Int;
				}
				if (valueId == floatId)
				{
					return Float;
				}
				if (valueId == boolId)
				{
					return Bool;
				}
				if (valueId == colorId)
				{
					return Color;
				}
				return null;
			}

			public void DrawParameter()
			{
			}
		}

		internal int index = -1;

		internal string LODName = "";

		[HideInInspector]
		public bool SetDisabled;

		[SerializeField]
		[HideInInspector]
		private int ver;

		[HideInInspector]
		[SerializeField]
		private bool _Locked;

		[SerializeField]
		[HideInInspector]
		private MonoBehaviour cmp;

		public bool BaseLOD;

		public UnityEvent Event;

		public List<ParameterHelper> Parameters;

		public List<ParameterHelper> NotSupported;

		internal bool DrawNotSupported;

		public static readonly int intId = "int".GetHashCode();

		public static readonly int floatId = "float".GetHashCode();

		public static readonly int boolId = "bool".GetHashCode();

		public static readonly int colorId = "Color".GetHashCode();

		public int Index
		{
			get
			{
				return index;
			}
			set
			{
				index = value;
			}
		}

		public string Name
		{
			get
			{
				return LODName;
			}
			set
			{
				LODName = value;
			}
		}

		public bool CustomEditor => true;

		public bool Disable
		{
			get
			{
				return SetDisabled;
			}
			set
			{
				SetDisabled = value;
			}
		}

		public bool DrawDisableOption => true;

		public bool SupportingTransitions => true;

		public bool DrawLowererSlider => false;

		public float QualityLowerer
		{
			get
			{
				return 1f;
			}
			set
			{
				new NotImplementedException();
			}
		}

		public string HeaderText => "MonoBehaviour LOD Settings";

		public float ToCullDelay => 0f;

		public bool SupportVersions => true;

		public int DrawingVersion
		{
			get
			{
				return ver;
			}
			set
			{
				ver = value;
			}
		}

		public bool LockSettings
		{
			get
			{
				return _Locked;
			}
			set
			{
				_Locked = value;
			}
		}

		public Texture Icon => null;

		public Component TargetComponent => cmp;

		public void SetSameValuesAsComponent(Component component)
		{
			if (component == null)
			{
				Debug.LogError("[OPTIMIZERS] Given component is null instead of MonoBehaviour!");
			}
			MonoBehaviour monoBehaviour = (cmp = component as MonoBehaviour);
			if (DrawingVersion == 0)
			{
				_ = monoBehaviour != null;
			}
		}

		public void ApplySettingsToTheComponent(Component component, ILODInstance initialSettingsReference)
		{
			if (DrawingVersion == 0)
			{
				if (!(initialSettingsReference is LODI_MonoBehaviour))
				{
					Debug.Log("[OPTIMIZERS] Target LOD is not MonoBehaviour LOD or is null");
					return;
				}
				if (Parameters != null)
				{
					for (int i = 0; i < Parameters.Count; i++)
					{
						if (!Parameters[i].Change && !BaseLOD)
						{
							continue;
						}
						FieldInfo field = component.GetType().GetField(Parameters[i].ParamName);
						if (field != null)
						{
							if (Parameters[i].TypeID == intId)
							{
								field.SetValue(component, Parameters[i].Int);
							}
							else if (Parameters[i].TypeID == floatId)
							{
								field.SetValue(component, Parameters[i].Float);
							}
							else if (Parameters[i].TypeID == boolId)
							{
								field.SetValue(component, Parameters[i].Bool);
							}
							else if (Parameters[i].TypeID == colorId)
							{
								field.SetValue(component, Parameters[i].Color);
							}
						}
					}
				}
			}
			if (Event != null)
			{
				Event.Invoke();
			}
			FLOD.ApplyEnableDisableState(this, component);
		}

		public void AssignAutoSettingsAsForLODLevel(int lodIndex, int lodCount, Component component)
		{
			if (component == null)
			{
				Debug.Log("<color=red>[OPTIMIZERS]</color> Given component for reference values is null or is not MonoBehaviour Component!");
			}
			SetSameValuesAsComponent(component);
			Name = "LOD" + (lodIndex + 2);
		}

		public void AssignSettingsAsForCulled(Component component)
		{
			FLOD.AssignDefaultCulledParams(this);
			SetSameValuesAsComponent(component);
		}

		public void AssignSettingsAsForNearest(Component component)
		{
			FLOD.AssignDefaultNearestParams(this);
			SetSameValuesAsComponent(component);
			if (Parameters != null)
			{
				for (int i = 0; i < Parameters.Count; i++)
				{
					Parameters[i].Change = true;
				}
			}
		}

		public void AssignSettingsAsForHidden(Component component)
		{
			FLOD.AssignDefaultHiddenParams(this);
		}

		public ILODInstance GetCopy()
		{
			LODI_MonoBehaviour lODI_MonoBehaviour = MemberwiseClone() as LODI_MonoBehaviour;
			lODI_MonoBehaviour.Parameters = new List<ParameterHelper>();
			if (Parameters != null)
			{
				for (int i = 0; i < Parameters.Count; i++)
				{
					ParameterHelper parameterHelper = new ParameterHelper(Parameters[i].ParamName, Parameters[i].ParamType);
					parameterHelper.SetValue(Parameters[i].TypeID, Parameters[i].GetValue(Parameters[i].TypeID));
					parameterHelper.Change = Parameters[i].Change;
					lODI_MonoBehaviour.Parameters.Add(parameterHelper);
				}
			}
			return lODI_MonoBehaviour;
		}

		public void InterpolateBetween(ILODInstance lodA, ILODInstance lodB, float transitionToB)
		{
			FLOD.DoBaseInterpolation(this, lodA, lodB, transitionToB);
			if (DrawingVersion == 1)
			{
				return;
			}
			LODI_MonoBehaviour lODI_MonoBehaviour = lodA as LODI_MonoBehaviour;
			LODI_MonoBehaviour lODI_MonoBehaviour2 = lodB as LODI_MonoBehaviour;
			BaseLOD = lODI_MonoBehaviour2.BaseLOD;
			if (Parameters == null)
			{
				return;
			}
			for (int i = 0; i < Parameters.Count; i++)
			{
				if (lODI_MonoBehaviour2.Parameters[i].Change)
				{
					Parameters[i].Change = true;
				}
				if (!lODI_MonoBehaviour.BaseLOD && !lODI_MonoBehaviour.Parameters[i].Change)
				{
					Parameters[i].SetValue(Parameters[i].TypeID, lODI_MonoBehaviour2.Parameters[i].GetValue(Parameters[i].TypeID));
				}
				else if (Parameters[i].TypeID == intId)
				{
					Parameters[i].Int = (int)Mathf.Lerp(lODI_MonoBehaviour.Parameters[i].Int, lODI_MonoBehaviour2.Parameters[i].Int, transitionToB);
				}
				else if (Parameters[i].TypeID == floatId)
				{
					Parameters[i].Float = Mathf.Lerp(lODI_MonoBehaviour.Parameters[i].Float, lODI_MonoBehaviour2.Parameters[i].Float, transitionToB);
				}
				else if (Parameters[i].TypeID == boolId)
				{
					if (transitionToB > 0.5f)
					{
						Parameters[i].Bool = lODI_MonoBehaviour2.Parameters[i].Bool;
					}
					else
					{
						Parameters[i].Bool = lODI_MonoBehaviour.Parameters[i].Bool;
					}
				}
				else if (Parameters[i].TypeID == colorId)
				{
					Parameters[i].Color = Color.Lerp(lODI_MonoBehaviour.Parameters[i].Color, lODI_MonoBehaviour2.Parameters[i].Color, transitionToB);
				}
			}
		}

		public void AssignToggler(ILODInstance reference)
		{
		}

		public void Simplify()
		{
			if (Parameters == null)
			{
				Parameters = new List<ParameterHelper>();
			}
			else
			{
				Parameters.Clear();
			}
			if (NotSupported == null)
			{
				NotSupported = new List<ParameterHelper>();
			}
			else
			{
				NotSupported.Clear();
			}
			DrawingVersion = 1;
		}
	}
}
