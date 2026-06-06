using System.Collections.Generic;
using System.Linq;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Check Var Listener", order = 5)]
	public class CheckVarListener : MAIDecision
	{
		public enum Affect
		{
			Self = 0,
			CurrentTarget = 1,
			Tag = 2,
			TransformHook = 3,
			GameObjectHook = 4,
			RuntimeGameObjectSet = 5
		}

		public enum ComponentPlace
		{
			SameHierarchy = 0,
			Parent = 1,
			Children = 2
		}

		public enum VarType
		{
			Bool = 0,
			Int = 1,
			Float = 2
		}

		public enum BoolType
		{
			True = 0,
			False = 1
		}

		[Space]
		[Tooltip("Check the Variable Listener ID Value, when this value is Zero, the ID is ignored")]
		public IntReference ListenerID = 0;

		[Space]
		[Tooltip("Find the VarListener component on:\n\n-Self: \nCheck on the Animal Gameobject using the Brain\n-Target: \ncurrent AI Target\n-Tag: \nAll the gameobjects using a Malbers Tag\n-Transform Hook: \na in a Transform Hook\n-GameObject Hook: \na in a GameObject Hook\n-Runtime GameObject Set: \na in all the GameObject in a Runtime Set")]
		public Affect checkOn;

		[Tooltip("Check if the Var Listener component its placed on:\n\n-SameHierarchy: \nsame hierarchy level as the gameobject(s) in the [CheckOn] Option\n-Parent: \nany of the parents of the gameobject(s) in the [CheckOn] Option\n-Children: \nany of the children of the gameobject(s) in the [CheckOn] Option")]
		public ComponentPlace PlacedOn;

		[Hide("checkOn", new int[] { 2 })]
		public Tag tag;

		[Hide("checkOn", new int[] { 3 })]
		public TransformVar Transform;

		[Hide("checkOn", new int[] { 4 })]
		public GameObjectVar GameObject;

		[Hide("checkOn", new int[] { 5 })]
		public RuntimeGameObjects GameObjectSet;

		[Space]
		[Tooltip("Check on the Target or Self if it has a Listener Variable Component <Int><Bool><Float> and compares it with the local variable)")]
		public VarType varType;

		[Hide("varType", new int[] { 1, 2 })]
		public ComparerInt comparer;

		[Hide("varType", new int[] { 0 })]
		public bool boolValue = true;

		[Hide("varType", new int[] { 1 })]
		public int intValue;

		[Hide("varType", new int[] { 2 })]
		public float floatValue;

		public bool debug;

		public override string DisplayName => "Variables/Check Variable Listener";

		public override void PrepareDecision(MAnimalBrain brain, int Index)
		{
			MonoBehaviour[] array = null;
			Transform[] objective = GetObjective(brain);
			if (objective == null)
			{
				if (debug)
				{
					Debug.LogWarning("Check Var Listener Objectives is Null, Please check your Decisions", this);
				}
				return;
			}
			if (objective != null && objective.Length != 0)
			{
				Transform[] array2 = objective;
				foreach (Transform transform in array2)
				{
					if (transform == null)
					{
						if (debug)
						{
							Debug.LogWarning($"Check Var Listener Checking on [{checkOn}]. Objective is Null", this);
						}
						return;
					}
					switch (varType)
					{
					case VarType.Bool:
					{
						MonoBehaviour[] components = GetComponents<BoolVarListener>(transform.gameObject);
						array = components;
						break;
					}
					case VarType.Int:
					{
						MonoBehaviour[] components = GetComponents<IntVarListener>(transform.gameObject);
						array = components;
						break;
					}
					case VarType.Float:
					{
						MonoBehaviour[] components = GetComponents<FloatVarListener>(transform.gameObject);
						array = components;
						break;
					}
					}
				}
			}
			ref BrainVars reference = ref brain.DecisionsVars[Index];
			Component[] components2 = array;
			reference.AddComponents(components2);
		}

		private Transform[] GetObjective(MAnimalBrain brain)
		{
			switch (checkOn)
			{
			case Affect.Self:
				return new Transform[1] { brain.Animal.transform };
			case Affect.CurrentTarget:
				return new Transform[1] { brain.Target };
			case Affect.Tag:
			{
				List<Tags> list2 = Tags.TagsHolders.FindAll((Tags X) => X.HasTag(tag));
				if (list2 != null)
				{
					List<Transform> list3 = new List<Transform>();
					foreach (Tags item in list2)
					{
						list3.Add(item.transform);
					}
					return list3.ToArray();
				}
				return null;
			}
			case Affect.TransformHook:
				if (Transform == null || Transform.Value == null)
				{
					return null;
				}
				return new Transform[1] { Transform.Value };
			case Affect.GameObjectHook:
				if (!GameObject.Value.IsPrefab())
				{
					return new Transform[1] { GameObject.Value.transform };
				}
				Debug.LogWarning("The GameObject Hook is a Prefab. Is not in the scene.", GameObject.Value);
				return null;
			case Affect.RuntimeGameObjectSet:
			{
				List<Transform> list = new List<Transform>();
				foreach (GameObject item2 in GameObjectSet.Items)
				{
					list.Add(item2.transform);
				}
				return list.ToArray();
			}
			default:
				return null;
			}
		}

		private TVarListener[] GetComponents<TVarListener>(GameObject gameObject) where TVarListener : VarListener
		{
			return (PlacedOn switch
			{
				ComponentPlace.Children => gameObject.GetComponentsInChildren<TVarListener>(), 
				ComponentPlace.Parent => gameObject.GetComponentsInParent<TVarListener>(), 
				ComponentPlace.SameHierarchy => gameObject.GetComponents<TVarListener>(), 
				_ => gameObject.GetComponents<TVarListener>(), 
			}).ToList().FindAll((TVarListener x) => ListenerID.Value == 0 || (int)x.ID == ListenerID.Value).ToArray();
		}

		public override bool Decide(MAnimalBrain brain, int Index)
		{
			Component[] components = brain.DecisionsVars[Index].Components;
			if (components == null || components.Length == 0)
			{
				return false;
			}
			bool flag = false;
			Component[] array = components;
			foreach (Component component in array)
			{
				if (!(component is VarListener))
				{
					continue;
				}
				switch (varType)
				{
				case VarType.Bool:
				{
					BoolVarListener boolVarListener = component as BoolVarListener;
					flag = boolVarListener.Value == boolValue;
					if (debug)
					{
						Debug.Log($"{brain.Animal.name}: <B>[{base.name}]</B> ListenerBool<{boolVarListener.transform.name}> ID<{boolVarListener.ID.Value}> Value<{boolVarListener.Value}>  <B>Result[{flag}]</B>");
					}
					break;
				}
				case VarType.Int:
				{
					IntVarListener intVarListener = component as IntVarListener;
					flag = CompareInteger(intVarListener.Value);
					if (debug)
					{
						Debug.Log($"{brain.Animal.name}: <B>[{base.name}]</B> ListenerInt<{intVarListener.transform.name}> ID<{intVarListener.ID.Value}> Value<{intVarListener.Value}>  <B>Result[{flag}]</B>");
					}
					break;
				}
				case VarType.Float:
				{
					FloatVarListener floatVarListener = component as FloatVarListener;
					flag = CompareFloat(floatVarListener.Value);
					if (debug)
					{
						Debug.Log($"{brain.Animal.name}: <B>[{base.name}]</B> ListenerInt<{floatVarListener.transform.name}> ID<{floatVarListener.ID.Value}> Value<{floatVarListener.Value}>  <B>Result[{flag}]</B>");
					}
					break;
				}
				default:
					return false;
				}
			}
			return flag;
		}

		public bool CompareInteger(int IntValue)
		{
			return comparer switch
			{
				ComparerInt.Equal => IntValue == intValue, 
				ComparerInt.Greater => IntValue > intValue, 
				ComparerInt.Less => IntValue < intValue, 
				ComparerInt.NotEqual => IntValue != intValue, 
				_ => false, 
			};
		}

		public bool CompareFloat(float IntValue)
		{
			return comparer switch
			{
				ComparerInt.Equal => IntValue == floatValue, 
				ComparerInt.Greater => IntValue > floatValue, 
				ComparerInt.Less => IntValue < floatValue, 
				ComparerInt.NotEqual => IntValue != floatValue, 
				_ => false, 
			};
		}
	}
}
