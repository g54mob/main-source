using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	public static class MalbersAnimationsExtensions
	{
		public const float Epsilon = 0.0001f;

		public static T Get<T>(this Dictionary<string, object> instance, string key)
		{
			return (T)instance[key];
		}

		public static bool IsSubclassDeep(this Type type, Type parenType)
		{
			while (type != null)
			{
				if (type.IsSubclassOf(parenType))
				{
					return true;
				}
				type = type.BaseType;
			}
			return false;
		}

		public static bool TryGetGenericTypeOfDefinition(this Type type, Type genericTypeDefinition, out Type generictype)
		{
			generictype = null;
			while (type != null)
			{
				if (type.IsGenericType && type.GetGenericTypeDefinition() == genericTypeDefinition)
				{
					generictype = type;
					return true;
				}
				type = type.BaseType;
			}
			return false;
		}

		public static bool IsSubclassOfGenericTypeDefinition(this Type t, Type genericTypeDefinition)
		{
			if (!genericTypeDefinition.IsGenericTypeDefinition)
			{
				throw new Exception("genericTypeDefinition parameter isn't generic type definition");
			}
			if (t.IsGenericType && t.GetGenericTypeDefinition() == genericTypeDefinition)
			{
				return true;
			}
			t = t.BaseType;
			while (t != null)
			{
				if (t.IsGenericType && t.GetGenericTypeDefinition() == genericTypeDefinition)
				{
					return true;
				}
				t = t.BaseType;
			}
			return false;
		}

		public static T Ref<T>(this T o) where T : UnityEngine.Object
		{
			if (!(o == null))
			{
				return o;
			}
			return null;
		}

		public static bool CompareFloat(this float current, float newValue, ComparerInt comparer)
		{
			return comparer switch
			{
				ComparerInt.Equal => current == newValue, 
				ComparerInt.Greater => current > newValue, 
				ComparerInt.Less => current < newValue, 
				ComparerInt.NotEqual => current != newValue, 
				_ => false, 
			};
		}

		public static bool CompareInt(this int current, int newValue, ComparerInt comparer)
		{
			return comparer switch
			{
				ComparerInt.Equal => current == newValue, 
				ComparerInt.Greater => current > newValue, 
				ComparerInt.Less => current < newValue, 
				ComparerInt.NotEqual => current != newValue, 
				_ => false, 
			};
		}

		public static bool InRange(this float current, float min, float max)
		{
			if (current >= min)
			{
				return current <= max;
			}
			return false;
		}

		public static bool InRange(this int current, float min, float max)
		{
			if ((float)current >= min)
			{
				return (float)current <= max;
			}
			return false;
		}

		public static void StartCoroutine(this MonoBehaviour Mono, out IEnumerator Cor, IEnumerator newCoro)
		{
			Cor = null;
			if (Mono.gameObject.activeInHierarchy)
			{
				Cor = newCoro;
				Mono.StartCoroutine(Cor);
			}
		}

		public static Vector3 Round(this Vector3 vector3, int decimalPlaces = 2)
		{
			float num = 1f;
			for (int i = 0; i < decimalPlaces; i++)
			{
				num *= 10f;
			}
			return new Vector3(Mathf.Round(vector3.x * num) / num, Mathf.Round(vector3.y * num) / num, Mathf.Round(vector3.z * num) / num);
		}

		public static Vector3 FlattenY(this Vector3 origin)
		{
			return new Vector3(origin.x, 0f, origin.z);
		}

		public static bool CloseToZero(this Vector3 v, float threshold = 0.0001f)
		{
			return v.sqrMagnitude < threshold * threshold;
		}

		public static Vector3 ClosestPointOnLine(this Vector3 point, Vector3 a, Vector3 b)
		{
			Vector3 vector = b - a;
			Vector3 lhs = point - a;
			float sqrMagnitude = vector.sqrMagnitude;
			if (sqrMagnitude < 0.0001f)
			{
				return a;
			}
			float num = Mathf.Clamp01(Vector3.Dot(lhs, vector) / sqrMagnitude);
			return a + vector * num;
		}

		public static Vector3 ProjectPointOnPlane(this Vector3 point, Vector3 planeNormal, Vector3 planePoint)
		{
			float num = SignedDistancePlanePoint(planeNormal, planePoint, point);
			num *= -1f;
			Vector3 vector = SetVectorLength(planeNormal, num);
			return point + vector;
		}

		public static float SignedDistancePlanePoint(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
		{
			return Vector3.Dot(planeNormal, point - planePoint);
		}

		public static Vector3 SetVectorLength(Vector3 vector, float size)
		{
			return Vector3.Normalize(vector) * size;
		}

		public static float ClosestTimeOnSegment(this Vector3 p, Vector3 s0, Vector3 s1)
		{
			Vector3 vector = s1 - s0;
			float num = Vector3.SqrMagnitude(vector);
			if (num < 0.0001f)
			{
				return 0f;
			}
			return Mathf.Clamp01(Vector3.Dot(p - s0, vector) / num);
		}

		public static Vector3 DirectionTo(this Vector3 origin, Vector3 destination)
		{
			return Vector3.Normalize(destination - origin);
		}

		public static Vector3 DeltaPositionFromRotate(this Transform transform, Vector3 point, Vector3 axis, float deltaAngle)
		{
			Vector3 position = transform.position;
			Vector3 vector = position - point;
			vector = Quaternion.AngleAxis(deltaAngle, axis) * vector;
			position = point + vector - position;
			position.y = 0f;
			return position;
		}

		public static Vector3 DeltaPositionFromRotate(this Transform transform, Vector3 platform, Quaternion deltaRotation)
		{
			Vector3 vector = transform.position - platform;
			Vector3 vector2 = deltaRotation * vector;
			return platform + vector2 - transform.position;
		}

		public static bool PointInsideSphere(this Vector3 point, Vector3 sphereCenter, float sphereRadius)
		{
			return (point - sphereCenter).sqrMagnitude <= sphereRadius * sphereRadius;
		}

		public static Transform FindGrandChild(this Transform aParent, string aName)
		{
			if (string.IsNullOrEmpty(aName))
			{
				return null;
			}
			Transform transform = aParent.ChildContainsName(aName);
			if (transform != null)
			{
				return transform;
			}
			foreach (Transform item in aParent)
			{
				transform = item.FindGrandChild(aName);
				if (transform != null)
				{
					return transform;
				}
			}
			return null;
		}

		public static Transform FindObjectCore(this Transform transf)
		{
			IObjectCore objectCore = transf.FindInterface<IObjectCore>();
			if (objectCore != null)
			{
				return objectCore.transform;
			}
			return transf;
		}

		public static bool SameHierarchy(this Transform child, Transform Parent)
		{
			if (child == Parent)
			{
				return true;
			}
			if (child.parent == null)
			{
				return false;
			}
			if (child.parent == Parent)
			{
				return true;
			}
			return child.parent.SameHierarchy(Parent);
		}

		[Obsolete("Use [SameHierarchy] Instead")]
		public static bool IsGrandchild(this Transform child, Transform Parent)
		{
			return child.SameHierarchy(Parent);
		}

		public static Vector3 DirectionTo(this Transform origin, Transform destination)
		{
			return origin.position.DirectionTo(destination.position);
		}

		public static Vector3 DirectionTo(this Transform origin, Vector3 destination)
		{
			return origin.position.DirectionTo(destination);
		}

		public static Transform NearestTransform(this Transform origin, params Transform[] transforms)
		{
			Transform result = null;
			float num = float.PositiveInfinity;
			Vector3 position = origin.position;
			foreach (Transform transform in transforms)
			{
				float sqrMagnitude = (transform.position - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = transform;
				}
			}
			return result;
		}

		public static Transform NearestTransform(this Transform origin, params TransformReference[] transforms)
		{
			Transform result = null;
			float num = float.PositiveInfinity;
			Vector3 position = origin.position;
			foreach (Transform transform in transforms)
			{
				float sqrMagnitude = (transform.position - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = transform;
				}
			}
			return result;
		}

		public static Vector3 NearestPoint(this Transform origin, params Vector3[] allPoints)
		{
			Vector3 result = Vector3.zero;
			float num = float.PositiveInfinity;
			Vector3 position = origin.position;
			foreach (Vector3 vector in allPoints)
			{
				float sqrMagnitude = (vector - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = vector;
				}
			}
			return result;
		}

		public static Transform FarestTransform(this Transform t, params Transform[] transforms)
		{
			Transform result = null;
			float num = float.PositiveInfinity;
			Vector3 position = t.position;
			foreach (Transform transform in transforms)
			{
				float sqrMagnitude = (transform.position - position).sqrMagnitude;
				if (sqrMagnitude > num)
				{
					num = sqrMagnitude;
					result = transform;
				}
			}
			return result;
		}

		public static Transform ChildContainsName(this Transform aParent, string aName)
		{
			foreach (Transform item in aParent)
			{
				if (item.name.Contains(aName))
				{
					return item;
				}
			}
			return null;
		}

		public static void ResetLocal(this Transform transform)
		{
			transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			transform.localScale = Vector3.one;
		}

		public static void SetLocalTransform(this Transform transform, Vector3 LocalPos, Vector3 LocalRot, Vector3 localScale)
		{
			transform.localPosition = LocalPos;
			transform.localEulerAngles = LocalRot;
			transform.localScale = localScale;
		}

		public static void SetLocalTransform(this Transform transform, TransformOffset offset)
		{
			offset.RestoreTransform(transform);
		}

		public static Transform SetParentScaleFixer(this Transform transform, Transform parent, Vector3 Position)
		{
			Vector3 lossyScale = parent.lossyScale;
			Vector3 vector = new Vector3(lossyScale.x, lossyScale.x, lossyScale.x);
			if (lossyScale == vector)
			{
				transform.SetParent(parent, worldPositionStays: true);
				transform.position = Position;
				return null;
			}
			Vector3 lossyScale2 = parent.transform.lossyScale;
			lossyScale2.x = 1f / Mathf.Max(lossyScale2.x, 0.0001f);
			lossyScale2.y = 1f / Mathf.Max(lossyScale2.y, 0.0001f);
			lossyScale2.z = 1f / Mathf.Max(lossyScale2.z, 0.0001f);
			GameObject gameObject = new GameObject
			{
				name = transform.name + "Link"
			};
			gameObject.transform.SetParent(parent);
			gameObject.transform.localScale = lossyScale2;
			gameObject.transform.position = Position;
			gameObject.transform.localRotation = Quaternion.identity;
			transform.SetParent(gameObject.transform);
			transform.localPosition = Vector3.zero;
			return gameObject.transform;
		}

		public static int TryOptionalParameter(this Animator m_Animator, string param)
		{
			int num = Animator.StringToHash(param);
			AnimatorControllerParameter[] parameters = m_Animator.parameters;
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i].nameHash == num)
				{
					return num;
				}
			}
			return 0;
		}

		public static string RemoveSpecialCharacters(this string str)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in str)
			{
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		public static void Resize<T>(this List<T> list, int size, T element = default(T))
		{
			int count = list.Count;
			if (size < count)
			{
				list.RemoveRange(size, count - size);
			}
			else if (size > count)
			{
				if (size > list.Capacity)
				{
					list.Capacity = size;
				}
				list.AddRange(Enumerable.Repeat(element, size - count));
			}
		}

		public static int GetListenerNumber(this UnityEventBase unityEvent)
		{
			object value = typeof(UnityEventBase).GetField("m_Calls", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic).GetValue(unityEvent);
			return (int)value.GetType().GetProperty("Count").GetValue(value);
		}

		public static bool IsPrefab(this GameObject go)
		{
			return !go.scene.IsValid();
		}

		public static IEnumerator Delay_Action(this MonoBehaviour mono, Action action)
		{
			return mono.Delay_Action(1, action);
		}

		public static IEnumerator Delay_Action(this MonoBehaviour mono, int frames, Action action)
		{
			if (mono.enabled && mono.gameObject.activeInHierarchy)
			{
				IEnumerator enumerator = DelayedAction(frames, action);
				mono.StartCoroutine(enumerator);
				return enumerator;
			}
			return null;
		}

		public static void Stop_Action(this MonoBehaviour mono, IEnumerator action)
		{
			if (action != null)
			{
				mono.StopCoroutine(action);
			}
		}

		public static IEnumerator Delay_Action(this MonoBehaviour mono, float time, Action action)
		{
			if (mono.enabled && mono.gameObject.activeInHierarchy)
			{
				IEnumerator enumerator = DelayedAction(time, action);
				mono.StartCoroutine(enumerator);
				return enumerator;
			}
			return null;
		}

		public static void Delay_Action(this MonoBehaviour mono, ref IEnumerator oldAction, float time, Action action)
		{
			if (oldAction != null)
			{
				mono.StopCoroutine(oldAction);
			}
			oldAction = mono.Delay_Action(time, action);
		}

		public static IEnumerator Delay_Action(this MonoBehaviour mono, Func<bool> Condition, Action action)
		{
			if (mono.enabled && mono.gameObject.activeInHierarchy)
			{
				IEnumerator enumerator = DelayedAction(Condition, action);
				mono.StartCoroutine(enumerator);
				return enumerator;
			}
			return null;
		}

		public static IEnumerator Delay_Action(this MonoBehaviour mono, WaitForSeconds time, Action action)
		{
			if (mono.enabled && mono.gameObject.activeInHierarchy)
			{
				IEnumerator enumerator = DelayedAction(time, action);
				mono.StartCoroutine(enumerator);
				return enumerator;
			}
			return null;
		}

		private static IEnumerator DelayedAction(int frame, Action action)
		{
			for (int i = 0; i < frame; i++)
			{
				yield return null;
			}
			action();
		}

		private static IEnumerator DelayedAction(Func<bool> Condition, Action action)
		{
			yield return new WaitWhile(Condition);
			action();
		}

		public static bool IsUnityRefNull<T>(this T o) where T : class
		{
			if (o != null)
			{
				if (o is UnityEngine.Object obj)
				{
					return obj == null;
				}
				return false;
			}
			return true;
		}

		private static IEnumerator DelayedAction(float time, Action action)
		{
			yield return new WaitForSeconds(time);
			action();
		}

		private static IEnumerator DelayedAction(WaitForSeconds time, Action action)
		{
			yield return time;
			action();
		}

		public static T CopyComponent<T>(this T original, GameObject destination) where T : Component
		{
			Type type = original.GetType();
			Component component = destination.AddComponent(type);
			FieldInfo[] fields = type.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(component, fieldInfo.GetValue(original));
			}
			return component as T;
		}

		public static T FindComponent<T>(this GameObject c) where T : Component
		{
			T component = c.GetComponent<T>();
			if (component != null)
			{
				return component;
			}
			component = c.GetComponentInParent<T>();
			if (component != null)
			{
				return component;
			}
			component = c.GetComponentInChildren<T>(includeInactive: true);
			if (component != null)
			{
				return component;
			}
			return null;
		}

		public static Component FindComponent(this GameObject c, Type t)
		{
			Component component = c.GetComponent(t);
			if (component != null)
			{
				return component;
			}
			component = c.GetComponentInParent(t);
			if (component != null)
			{
				return component;
			}
			component = c.GetComponentInChildren(t, includeInactive: true);
			if (component != null)
			{
				return component;
			}
			return null;
		}

		public static T[] FindComponents<T>(this GameObject c) where T : Component
		{
			T[] components = c.GetComponents<T>();
			if (components != null)
			{
				return components;
			}
			components = c.GetComponentsInParent<T>();
			if (components != null)
			{
				return components;
			}
			components = c.GetComponentsInChildren<T>(includeInactive: true);
			if (components != null)
			{
				return components;
			}
			return null;
		}

		public static T MFindComponentInRoot<T>(this GameObject c) where T : Component
		{
			Transform root = c.transform.root;
			if (root.TryGetComponent<T>(out var component))
			{
				return component;
			}
			component = c.GetComponentInParent<T>();
			if (component != null)
			{
				return component;
			}
			component = root.GetComponentInChildren<T>(includeInactive: true);
			if (component != null)
			{
				return component;
			}
			return null;
		}

		public static T FindInterface<T>(this GameObject c)
		{
			T component = c.GetComponent<T>();
			if (component != null)
			{
				return component;
			}
			component = c.GetComponentInParent<T>(includeInactive: true);
			if (component != null)
			{
				return component;
			}
			component = c.GetComponentInChildren<T>(includeInactive: true);
			if (component != null)
			{
				return component;
			}
			return default(T);
		}

		public static T FindInterface<T>(this GameObject c, bool includeInactive)
		{
			T component = c.GetComponent<T>();
			if (component != null)
			{
				return component;
			}
			component = c.GetComponentInParent<T>(includeInactive);
			if (component != null)
			{
				return component;
			}
			component = c.GetComponentInChildren<T>(includeInactive);
			if (component != null)
			{
				return component;
			}
			return default(T);
		}

		public static T[] FindInterfaces<T>(this GameObject c)
		{
			T[] components = c.GetComponents<T>();
			if (components != null && components.Length != 0)
			{
				return components;
			}
			components = c.GetComponentsInParent<T>();
			if (components != null && components.Length != 0)
			{
				return components;
			}
			components = c.GetComponentsInChildren<T>(includeInactive: true);
			if (components != null && components.Length != 0)
			{
				return components;
			}
			return null;
		}

		public static T FindComponent<T>(this Component c) where T : Component
		{
			return c.gameObject.FindComponent<T>();
		}

		public static T FindInterface<T>(this Component c)
		{
			return c.gameObject.FindInterface<T>();
		}

		public static T FindInterface<T>(this Component c, bool includeInactive)
		{
			return c.gameObject.FindInterface<T>(includeInactive);
		}

		public static T[] FindInterfaces<T>(this Component c)
		{
			return c.gameObject.FindInterfaces<T>();
		}

		public static T MFindComponentInRoot<T>(this Component c) where T : Component
		{
			return c.gameObject.MFindComponentInRoot<T>();
		}

		public static Component GetComponentInChildren(this Component owner, string classtype)
		{
			Component component = owner.GetComponent(classtype);
			if ((bool)component)
			{
				return component;
			}
			foreach (Transform item in owner.transform)
			{
				Component componentInChildren = item.GetComponentInChildren(classtype);
				if ((bool)componentInChildren)
				{
					return componentInChildren;
				}
			}
			return null;
		}

		public static Component GetComponentInParent(this Component owner, string classtype)
		{
			Component component = owner.GetComponent(classtype);
			if (component != null)
			{
				return component;
			}
			if (owner.transform.parent == null)
			{
				return null;
			}
			return owner.transform.parent.GetComponentInParent(classtype);
		}

		private static T GetCopyOf<T>(this Component comp, T other) where T : Component
		{
			Type type = comp.GetType();
			if (type != other.GetType())
			{
				return null;
			}
			BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			PropertyInfo[] properties = type.GetProperties(bindingAttr);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.CanWrite)
				{
					try
					{
						propertyInfo.SetValue(comp, propertyInfo.GetValue(other, null), null);
					}
					catch
					{
					}
				}
			}
			FieldInfo[] fields = type.GetFields(bindingAttr);
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(comp, fieldInfo.GetValue(other));
			}
			return comp as T;
		}

		public static T AddCopyComponent<T>(this GameObject go, T toAdd) where T : Component
		{
			return go.AddComponent<T>().GetCopyOf(toAdd);
		}

		public static IDeltaRootMotion TryDeltaRootMotion(this Component c)
		{
			if (c.TryGetComponent<IDeltaRootMotion>(out var component))
			{
				component.ResetDeltaRootMotion();
				return component;
			}
			return null;
		}

		public static bool IsDestroyed(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return (object)gameObject != null;
			}
			return false;
		}

		public static T GetPropertyValue<T>(this Component component, string propertyName)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			Type type = component.GetType();
			PropertyInfo property = type.GetProperty(propertyName);
			if (property == null)
			{
				Debug.LogError($"Property '{propertyName}' of type '{typeof(T)}' not found on component '{type.FullName}'.");
				return default(T);
			}
			if (property.PropertyType != typeof(T))
			{
				Debug.LogError($"Property '{propertyName}' was found, but it does not have the type '{typeof(T)}'. '{type.FullName}'.");
				return default(T);
			}
			return (T)property.GetValue(component);
		}

		public static UnityAction<T> CreateDelegate<T>(object target, MethodInfo method)
		{
			return (UnityAction<T>)Delegate.CreateDelegate(typeof(UnityAction<T>), target, method);
		}

		public static UnityAction CreateDelegate(object target, MethodInfo method)
		{
			return (UnityAction)Delegate.CreateDelegate(typeof(UnityAction), target, method);
		}

		public static UnityAction GetUnityAction(this Component c, string component, string method)
		{
			object obj = c.GetComponent(component) ?? c.GetComponentInParent(component);
			if (obj == null)
			{
				obj = c.GetComponentInChildren(component);
			}
			Component component2 = (Component)obj;
			if (component2 != null)
			{
				MethodInfo method2 = component2.GetType().GetMethod(method, new Type[0]);
				if (method2 != null)
				{
					return CreateDelegate(component2, method2);
				}
				return null;
			}
			return null;
		}

		public static Type FindType(string qualifiedTypeName)
		{
			Type type = Type.GetType(qualifiedTypeName);
			if (type != null)
			{
				return type;
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				type = assemblies[i].GetType(qualifiedTypeName);
				if (type != null)
				{
					return type;
				}
			}
			return null;
		}

		public static UnityAction<T> GetUnityAction<T>(this Component c, string component, string method)
		{
			if (string.IsNullOrEmpty(component))
			{
				return null;
			}
			Component component2 = (c.GetComponent(component) ?? c.GetComponentInParent(component)) ?? c.GetComponentInChildren(component);
			if (component2 == null)
			{
				return null;
			}
			MethodInfo method2 = component2.GetType().GetMethod(method, new Type[1] { typeof(T) });
			if (method2 != null)
			{
				return CreateDelegate<T>(component2, method2);
			}
			PropertyInfo property = component2.GetType().GetProperty(method);
			if (property != null)
			{
				return CreateDelegate<T>(component2, property.SetMethod);
			}
			return null;
		}

		public static T GetFieldClass<T>(this Component owner, string component, string field) where T : class
		{
			Component component2 = owner.GetComponent(component);
			if (component2 != null)
			{
				FieldInfo field2 = component2.GetType().GetField(field, BindingFlags.Instance | BindingFlags.Public);
				if (field2 != null)
				{
					return field2.GetValue(component2) as T;
				}
			}
			return null;
		}

		public static bool InvokeWithParams(this MonoBehaviour sender, string method, object args)
		{
			Type type = null;
			if (args != null)
			{
				type = args.GetType();
			}
			MethodInfo method2;
			if (type != null)
			{
				method2 = sender.GetType().GetMethod(method, new Type[1] { type });
			}
			else
			{
				try
				{
					method2 = sender.GetType().GetMethod(method);
				}
				catch (Exception)
				{
					throw;
				}
			}
			if (method2 != null)
			{
				if (args != null)
				{
					object[] parameters = new object[1] { args };
					method2.Invoke(sender, parameters);
					return true;
				}
				method2.Invoke(sender, null);
				return true;
			}
			PropertyInfo property = sender.GetType().GetProperty(method);
			if (property != null)
			{
				property.SetValue(sender, args, null);
				return true;
			}
			return false;
		}

		public static void InvokeDelay(this MonoBehaviour behaviour, string method, object options, YieldInstruction wait)
		{
			behaviour.StartCoroutine(behaviour._invoke(method, wait, options));
		}

		private static IEnumerator _invoke(this MonoBehaviour behaviour, string method, YieldInstruction wait, object options)
		{
			yield return wait;
			behaviour.GetType().GetMethod(method).Invoke(behaviour, new object[1] { options });
			yield return null;
		}

		public static void Invoke(this ScriptableObject sender, string method, object args)
		{
			MethodInfo method2 = sender.GetType().GetMethod(method);
			if (method2 != null)
			{
				if (args != null)
				{
					object[] parameters = new object[1] { args };
					method2.Invoke(sender, parameters);
				}
				else
				{
					method2.Invoke(sender, null);
				}
			}
		}

		public static void SetLayer(this GameObject parent, int layer, bool includeChildren = true)
		{
			parent.layer = layer;
			if (includeChildren)
			{
				Transform[] componentsInChildren = parent.transform.GetComponentsInChildren<Transform>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.layer = layer;
				}
			}
		}

		public static void SetEnable(this MonoBehaviour c, bool enable)
		{
			c.enabled = enable;
		}

		public static void SetEnable(this Collider c, bool enable)
		{
			c.enabled = enable;
		}
	}
}
