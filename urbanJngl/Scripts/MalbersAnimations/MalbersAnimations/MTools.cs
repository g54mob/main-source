using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	public static class MTools
	{
		public const float Epsilon = 0.0001f;

		public static Keyframe[] DefaultCurve = new Keyframe[2]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		};

		public static Keyframe[] DefaultCurveLinear = new Keyframe[2]
		{
			new Keyframe(0f, 0f, 0f, 0f, 0f, 0f),
			new Keyframe(1f, 1f, 0f, 0f, 0f, 0f)
		};

		public static Keyframe[] DefaultCurveLinearInverse = new Keyframe[2]
		{
			new Keyframe(0f, 1f, 0f, 0f, 0f, 0f),
			new Keyframe(1f, 0f, 0f, 0f, 0f, 0f)
		};

		public static GameObject FindRealRoot(Collider collider, bool includeInactive = false)
		{
			GameObject gameObject = collider.transform.root.gameObject;
			IObjectCore componentInParent = collider.GetComponentInParent<IObjectCore>(includeInactive);
			if (componentInParent != null)
			{
				gameObject = componentInParent.transform.gameObject;
			}
			else if (gameObject.layer != collider.gameObject.layer)
			{
				gameObject = FindRealParentByLayer(collider.transform);
			}
			return gameObject;
		}

		public static bool ReboneSkinnedMesh(Transform RootBone, SkinnedMeshRenderer thisRenderer)
		{
			Transform rootBone = thisRenderer.rootBone;
			Transform[] componentsInChildren = RootBone.GetComponentsInChildren<Transform>();
			Dictionary<string, Transform> dictionary = new Dictionary<string, Transform>();
			Transform[] array = componentsInChildren;
			foreach (Transform transform in array)
			{
				dictionary[transform.name] = transform;
			}
			Transform[] bones = thisRenderer.bones;
			for (int j = 0; j < bones.Length; j++)
			{
				string name = bones[j].name;
				if (!dictionary.TryGetValue(name, out bones[j]))
				{
					Debug.LogError("failed to get bone: " + name);
					return false;
				}
			}
			thisRenderer.bones = bones;
			if (dictionary.TryGetValue(rootBone.name, out var value))
			{
				thisRenderer.rootBone = value;
			}
			return true;
		}

		public static Vector3 ProjectOntoPlane(Vector3 vector, Vector3 planeNormal)
		{
			return vector - Vector3.Dot(vector, planeNormal) * planeNormal;
		}

		public static float CalculateRangeWeight(this float value, float min, float max)
		{
			if (value <= min)
			{
				return 1f;
			}
			if (value >= max)
			{
				return 0f;
			}
			return 1f - (value - min) / (max - min);
		}

		public static bool DoSpheresIntersect(Vector3 center1, float radius1, Vector3 center2, float radius2)
		{
			float sqrMagnitude = (center1 - center2).sqrMagnitude;
			float num = Mathf.Pow(radius1 + radius2, 2f);
			return sqrMagnitude <= num;
		}

		public static float SmoothStep(float min, float max, float value)
		{
			float value2 = (value - min) / (max - min);
			value2 = Mathf.Clamp01(value2);
			return value2 * value2 * (3f - 2f * value2);
		}

		public static int[] GetDigits(int num)
		{
			List<int> list = new List<int>();
			while (num > 0)
			{
				list.Add(num % 10);
				num /= 10;
			}
			list.Reverse();
			return list.ToArray();
		}

		public static bool ElapsedTime(float StartTime, float intervalTime)
		{
			return Time.time - StartTime >= intervalTime;
		}

		public static bool CompareOR(int source, params int[] comparison)
		{
			foreach (int num in comparison)
			{
				if (source == num)
				{
					return true;
				}
			}
			return false;
		}

		public static bool CompareAND(int source, params int[] comparison)
		{
			foreach (int num in comparison)
			{
				if (source != num)
				{
					return false;
				}
			}
			return true;
		}

		public static bool CompareOR(bool source, params bool[] comparison)
		{
			foreach (bool flag in comparison)
			{
				if (source == flag)
				{
					return true;
				}
			}
			return false;
		}

		public static bool CompareAND(bool source, params bool[] comparison)
		{
			foreach (bool flag in comparison)
			{
				if (source != flag)
				{
					return false;
				}
			}
			return true;
		}

		public static List<Type> GetAllTypes<T>()
		{
			return ReflectionUtility.GetAllTypes<T>();
		}

		public static List<Type> GetAllTypes(Type type)
		{
			return ReflectionUtility.GetAllTypes(type);
		}

		public static Camera FindMainCamera()
		{
			if (!(Camera.main != null))
			{
				return UnityEngine.Object.FindFirstObjectByType<Camera>();
			}
			return Camera.main;
		}

		public static List<T> GetAllResources<T>() where T : UnityEngine.Object
		{
			return Resources.FindObjectsOfTypeAll<T>()?.ToList();
		}

		public static T GetResource<T>(string name) where T : UnityEngine.Object
		{
			return GetAllResources<T>().Find((T x) => x.name == name);
		}

		public static GameObject FindRealParentByLayer(Transform other)
		{
			if (other.transform.parent == null)
			{
				return other.gameObject;
			}
			if (other.gameObject.layer == other.parent.gameObject.layer)
			{
				return FindRealParentByLayer(other.parent);
			}
			return other.gameObject;
		}

		public static void SetLayer(Transform root, int layer)
		{
			root.gameObject.layer = layer;
			foreach (Transform item in root)
			{
				SetLayer(item, layer);
			}
		}

		public static bool CollidersLayer(Collider collider, LayerMask layerMask)
		{
			return (int)layerMask == ((int)layerMask | (1 << collider.gameObject.layer));
		}

		public static bool Layer_in_LayerMask(int layer, LayerMask layerMask)
		{
			return (int)layerMask == ((int)layerMask | (1 << layer));
		}

		public static string Serialize<T>(this T toSerialize)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			StringWriter stringWriter = new StringWriter();
			xmlSerializer.Serialize(stringWriter, toSerialize);
			return stringWriter.ToString();
		}

		public static bool IsBitActive(int IntValue, int index)
		{
			return (IntValue & (1 << index)) != 0;
		}

		public static T Deserialize<T>(this string toDeserialize)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			StringReader textReader = new StringReader(toDeserialize);
			return (T)xmlSerializer.Deserialize(textReader);
		}

		public static Vector3 DirectionFromCamera(Transform origin, float x, float y, out RaycastHit hit, LayerMask hitmask)
		{
			Camera main = Camera.main;
			hit = default(RaycastHit);
			Ray ray = main.ScreenPointToRay(new Vector2(x * (float)main.pixelWidth, y * (float)main.pixelHeight));
			Vector3 result = ray.direction;
			hit.distance = float.MaxValue;
			RaycastHit[] array = Physics.RaycastAll(ray, 100f, hitmask);
			for (int i = 0; i < array.Length; i++)
			{
				RaycastHit raycastHit = array[i];
				if (!raycastHit.transform.SameHierarchy(origin.transform) && !(Vector3.Distance(main.transform.position, raycastHit.point) < Vector3.Distance(main.transform.position, origin.position)) && hit.distance > raycastHit.distance)
				{
					hit = raycastHit;
				}
			}
			if (hit.distance != float.MaxValue)
			{
				result = (hit.point - origin.position).normalized;
			}
			return result;
		}

		public static Vector3 DirectionFromCamera(Camera cam, Transform origin, Vector3 ScreenPoint, out RaycastHit hit, LayerMask hitmask, Transform Ignore = null)
		{
			Ray ray = cam.ScreenPointToRay(ScreenPoint);
			Vector3 result = ray.direction;
			hit = new RaycastHit
			{
				distance = float.MaxValue,
				point = ray.GetPoint(100f)
			};
			RaycastHit[] array = Physics.RaycastAll(ray, 100f, hitmask);
			for (int i = 0; i < array.Length; i++)
			{
				RaycastHit raycastHit = array[i];
				if (!raycastHit.transform.SameHierarchy(Ignore) && !raycastHit.transform.SameHierarchy(origin) && !(Vector3.Distance(cam.transform.position, raycastHit.point) < Vector3.Distance(cam.transform.position, origin.position)) && hit.distance > raycastHit.distance)
				{
					hit = raycastHit;
				}
			}
			if (hit.distance != float.MaxValue)
			{
				result = (hit.point - origin.position).normalized;
			}
			return result;
		}

		public static Vector3 DirectionFromCamera(Transform origin)
		{
			RaycastHit hit;
			return DirectionFromCamera(origin, 0.5f * (float)Screen.width, 0.5f * (float)Screen.height, out hit, -1);
		}

		public static Vector3 DirectionFromCamera(Transform origin, LayerMask layerMask)
		{
			RaycastHit hit;
			return DirectionFromCamera(origin, 0.5f * (float)Screen.width, 0.5f * (float)Screen.height, out hit, layerMask);
		}

		public static bool RayArcCast(Vector3 center, Quaternion rotation, float angle, float radius, int resolution, LayerMask layer, out RaycastHit hit)
		{
			rotation *= Quaternion.Euler((0f - angle) / 2f, 0f, 0f);
			for (int i = 0; i < resolution; i++)
			{
				Vector3 vector = center + rotation * Vector3.forward * radius;
				rotation *= Quaternion.Euler(angle / (float)resolution, 0f, 0f);
				Vector3 vector2 = center + rotation * Vector3.forward * radius;
				Vector3 direction = vector2 - vector;
				Debug.DrawLine(vector, vector2, Color.green);
				if (Physics.Raycast(vector, direction, out hit, direction.magnitude, layer, QueryTriggerInteraction.Ignore))
				{
					return true;
				}
			}
			hit = default(RaycastHit);
			return false;
		}

		public static RaycastHit RayCastHitToCenter(Camera cam, Transform origin, Vector3 ScreenCenter, int layerMask = 0)
		{
			RaycastHit result = default(RaycastHit);
			Ray ray = cam.ScreenPointToRay(ScreenCenter);
			result.distance = float.MaxValue;
			RaycastHit[] array = Physics.RaycastAll(ray, 100f, layerMask);
			for (int i = 0; i < array.Length; i++)
			{
				RaycastHit raycastHit = array[i];
				if (!raycastHit.transform.SameHierarchy(origin) && !(Vector3.Distance(cam.transform.position, raycastHit.point) < Vector3.Distance(cam.transform.position, origin.position)) && result.distance > raycastHit.distance)
				{
					result = raycastHit;
				}
			}
			return result;
		}

		public static Vector3 DirectionFromCameraNoRayCast(Camera cam, Vector3 ScreenCenter)
		{
			return cam.ScreenPointToRay(ScreenCenter).direction;
		}

		public static RaycastHit RayCastHitToCenter(Camera cam, Transform origin)
		{
			Vector3 screenCenter = new Vector3(0.5f * (float)Screen.width, 0.5f * (float)Screen.height);
			return RayCastHitToCenter(cam, origin, screenCenter);
		}

		public static RaycastHit RayCastHitToCenter(Camera cam, Transform origin, LayerMask layerMask)
		{
			Vector3 screenCenter = new Vector3(0.5f * (float)Screen.width, 0.5f * (float)Screen.height);
			return RayCastHitToCenter(cam, origin, screenCenter, layerMask);
		}

		public static void RotateInBoneSpace(Quaternion target, Transform boneToRotate, Vector3 rotationAmount)
		{
			Quaternion rotation = boneToRotate.rotation;
			Quaternion quaternion = Quaternion.Inverse(target) * rotation;
			Quaternion rotation2 = target * Quaternion.Euler(rotationAmount) * quaternion;
			boneToRotate.rotation = rotation2;
		}

		public static void RotateInBoneSpace(Quaternion target, Transform boneToRotate, Quaternion rotationAmount)
		{
			Quaternion rotation = boneToRotate.rotation;
			Quaternion quaternion = Quaternion.Inverse(target) * rotation;
			Quaternion rotation2 = target * rotationAmount * quaternion;
			boneToRotate.rotation = rotation2;
		}

		public static float PowerFromAngle(Vector3 OriginPos, Vector3 TargetPos, float angle)
		{
			Vector2 a = new Vector2(OriginPos.x, OriginPos.z);
			Vector2 b = new Vector2(TargetPos.x, TargetPos.z);
			float num = Vector2.Distance(a, b);
			float y = Physics.gravity.y;
			float y2 = OriginPos.y;
			float y3 = TargetPos.y;
			float f = Mathf.Cos(angle * (MathF.PI / 180f));
			float num2 = Mathf.Tan(angle * (MathF.PI / 180f));
			float num3 = y * Mathf.Pow(num, 2f) / (2f * Mathf.Pow(f, 2f) * (y3 - y2 - num * num2));
			if (num3 <= 0f)
			{
				return 0f;
			}
			return Mathf.Sqrt(num3);
		}

		public static Vector3 ClosestPointOnLine(Vector3 point, Vector3 a, Vector3 b)
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

		public static Vector3 VelocityFromPower(Vector3 OriginPos, float Power, float angle, Vector3 pos)
		{
			Vector3 vector = pos;
			OriginPos.y = 0f;
			vector.y = 0f;
			Vector3 normalized = (vector - OriginPos).normalized;
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.right, normalized);
			Vector3 vector2 = Power * Vector3.right;
			return quaternion * Quaternion.AngleAxis(angle, Vector3.forward) * vector2;
		}

		public static Vector3 DirectionTarget(Transform origin, Transform Target, bool normalized = true)
		{
			return DirectionTarget(origin.position, Target.position, normalized);
		}

		public static Vector3 Quaternion_to_AngularVelocity(Quaternion quaternion)
		{
			quaternion.ToAngleAxis(out var angle, out var axis);
			return axis * angle * (MathF.PI / 180f) / Time.deltaTime;
		}

		public static Vector3 DirectionTarget(Vector3 origin, Vector3 Target, bool normalized = true)
		{
			if (normalized)
			{
				return (Target - origin).normalized;
			}
			return Target - origin;
		}

		public static float HorizontalAngle(Vector3 From, Vector3 To, Vector3 Up)
		{
			float num = Mathf.Atan2(Vector3.Dot(Up, Vector3.Cross(From, To)), Vector3.Dot(From, To));
			num *= 57.29578f;
			if (Mathf.Abs(num) < 0.0001f)
			{
				num = 0f;
			}
			return num;
		}

		public static float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
		{
			dirA -= Vector3.Project(dirA, axis);
			dirB -= Vector3.Project(dirB, axis);
			return Vector3.Angle(dirA, dirB) * (float)((!(Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0f)) ? 1 : (-1));
		}

		public static Vector3 ClosestPointOnPlane(Vector3 planeOffset, Vector3 planeNormal, Vector3 point)
		{
			return point + DistanceFromPlane(planeOffset, planeNormal, point) * planeNormal;
		}

		public static float DistanceFromPlane(Vector3 planeOffset, Vector3 planeNormal, Vector3 point)
		{
			return Vector3.Dot(planeOffset - point, planeNormal);
		}

		public static UnityAction<T> Property_Set_UnityAction<T>(UnityEngine.Object component, string propName)
		{
			PropertyInfo property = component.GetType().GetProperty(propName);
			return (UnityAction<T>)Delegate.CreateDelegate(typeof(UnityAction<T>), component, property.GetSetMethod());
		}

		public static IEnumerator AlignTransform_Position(Transform slave, Transform target, float time, AnimationCurve curve = null)
		{
			float elapsedTime = 0f;
			WaitForFixedUpdate Wait = new WaitForFixedUpdate();
			Vector3 CurrentPos = slave.position;
			slave.TryDeltaRootMotion();
			while (time > 0f && elapsedTime <= time)
			{
				float t = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				slave.position = Vector3.LerpUnclamped(CurrentPos, target.position, t);
				elapsedTime += Time.fixedDeltaTime;
				MDebug.DrawWireSphere(slave.position, 0.1f, Color.white, 1f);
				yield return Wait;
			}
			slave.position = target.position;
		}

		public static IEnumerator AlignTransform_Position(Transform t1, Vector3 NewPosition, float time, AnimationCurve curve = null)
		{
			float elapsedTime = 0f;
			WaitForFixedUpdate Wait = new WaitForFixedUpdate();
			Vector3 CurrentPos = t1.position;
			t1.TryDeltaRootMotion();
			while (time > 0f && elapsedTime <= time)
			{
				float t2 = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				t1.position = Vector3.LerpUnclamped(CurrentPos, NewPosition, t2);
				elapsedTime += Time.fixedDeltaTime;
				yield return Wait;
			}
			t1.position = NewPosition;
		}

		public static IEnumerator AlignTransform(Transform t1, Transform t2, float time, AnimationCurve curve = null)
		{
			yield return AlignTransform(t1, t2.position, t2.rotation, time, curve);
		}

		public static IEnumerator AlignTransform(Transform t1, Vector3 t2Pos, Quaternion t2Rot, float time, AnimationCurve curve = null)
		{
			float elapsedTime = 0f;
			t1.GetPositionAndRotation(out var CurrentPos, out var CurrentRot);
			WaitForFixedUpdate Wait = new WaitForFixedUpdate();
			t1.TryDeltaRootMotion();
			while (time > 0f && elapsedTime <= time)
			{
				float t2 = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				t1.SetPositionAndRotation(Vector3.LerpUnclamped(CurrentPos, t2Pos, t2), Quaternion.LerpUnclamped(CurrentRot, t2Rot, t2));
				elapsedTime += Time.fixedDeltaTime;
				yield return Wait;
			}
			t1.SetPositionAndRotation(t2Pos, t2Rot);
		}

		public static IEnumerator AlignLookAtTransform(Transform t1, Vector3 target, float AlignOffset, float time, float scale, AnimationCurve AlignCurve)
		{
			float elapsedTime = 0f;
			WaitForFixedUpdate wait = new WaitForFixedUpdate();
			Quaternion CurrentRot = t1.rotation;
			Vector3 vector = target - t1.position;
			vector = Vector3.ProjectOnPlane(vector, t1.up);
			Quaternion FinalRot = Quaternion.LookRotation(vector);
			Vector3 Offset = t1.position + AlignOffset * scale * t1.forward;
			if (AlignOffset != 0f)
			{
				Quaternion deltaRotation = Quaternion.Inverse(t1.rotation) * FinalRot;
				Vector3 vector2 = t1.position + t1.DeltaPositionFromRotate(Offset, deltaRotation);
				vector = target - vector2;
				float num = 3f;
				MDebug.Draw_Arrow(vector2, vector, Color.yellow, num);
				MDebug.DrawWireSphere(vector2, 0.1f, Color.green, num);
				MDebug.DrawWireSphere(target, 0.1f, Color.yellow, num);
				vector = Vector3.ProjectOnPlane(vector, t1.up);
			}
			if (vector.CloseToZero())
			{
				Debug.LogWarning("Direction is Zero. Please set a correct rotation", t1);
				yield return null;
				yield break;
			}
			vector = Vector3.ProjectOnPlane(vector, t1.up);
			FinalRot = Quaternion.LookRotation(vector);
			Quaternion Last_Platform_Rot = t1.rotation;
			while (time > 0f && elapsedTime <= time)
			{
				float t2 = AlignCurve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				t1.rotation = Quaternion.SlerpUnclamped(CurrentRot, FinalRot, t2);
				if (AlignOffset != 0f)
				{
					Quaternion deltaRotation2 = Quaternion.Inverse(Last_Platform_Rot) * t1.rotation;
					t1.position += t1.DeltaPositionFromRotate(Offset, deltaRotation2);
				}
				elapsedTime += Time.fixedDeltaTime;
				Last_Platform_Rot = t1.rotation;
				Debug.DrawRay(Offset, Vector3.up, Color.white);
				MDebug.DrawWireSphere(t1.position, t1.rotation, 0.05f * scale, Color.white, 0.2f);
				MDebug.DrawWireSphere(t1.position, t1.rotation, 0.05f * scale, Color.white, 0.2f);
				MDebug.DrawWireSphere(Offset, 0.05f * scale, Color.white, 0.2f);
				MDebug.Draw_Arrow(t1.position, t1.forward, Color.white, 0.2f);
				yield return wait;
			}
		}

		public static IEnumerator AlignLookAtTransform(Transform t1, Transform t2, float time, float angleOffset = 0f, AnimationCurve curve = null)
		{
			float elapsedTime = 0f;
			WaitForFixedUpdate wait = new WaitForFixedUpdate();
			Quaternion CurrentRot = t1.rotation;
			Vector3 normalized = (t2.position - t1.position).normalized;
			normalized = Vector3.ProjectOnPlane(normalized, Vector3.up);
			Quaternion FinalRot = Quaternion.LookRotation(normalized) * Quaternion.Euler(0f, angleOffset, 0f);
			while (time > 0f && elapsedTime <= time)
			{
				float t3 = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				t1.rotation = Quaternion.SlerpUnclamped(CurrentRot, FinalRot, t3);
				elapsedTime += Time.fixedDeltaTime;
				yield return wait;
			}
			t1.rotation = FinalRot;
		}

		public static IEnumerator AlignLookAtTransformDirection(Transform t1, Vector3 direction, float time, AnimationCurve curve = null)
		{
			float elapsedTime = 0f;
			WaitForFixedUpdate wait = new WaitForFixedUpdate();
			Quaternion CurrentRot = t1.rotation;
			direction = Vector3.ProjectOnPlane(direction, t1.up);
			Quaternion FinalRot = Quaternion.LookRotation(direction);
			while (time > 0f && elapsedTime <= time)
			{
				float t2 = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				t1.rotation = Quaternion.SlerpUnclamped(CurrentRot, FinalRot, t2);
				elapsedTime += Time.fixedDeltaTime;
				yield return wait;
			}
			t1.rotation = FinalRot;
		}

		public static IEnumerator AlignTransformToTargetDirection(Transform t1, Vector3 t2Pos, Quaternion t2Rot, float time, AnimationCurve curve = null)
		{
			float elapsedTime = 0f;
			Vector3 currentPos = t1.position;
			Quaternion currentRot = t1.rotation;
			Vector3 vector = t2Rot * Vector3.forward;
			if (Vector3.Dot(t1.forward, vector) < 0f)
			{
				vector = -vector;
				t2Rot = Quaternion.LookRotation(vector, Vector3.up);
			}
			WaitForFixedUpdate wait = new WaitForFixedUpdate();
			while (time > 0f && elapsedTime <= time)
			{
				float t2 = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				t1.SetPositionAndRotation(Vector3.LerpUnclamped(currentPos, t2Pos, t2), Quaternion.RotateTowards(currentRot, t2Rot, Time.deltaTime * 1000f));
				elapsedTime += Time.fixedDeltaTime;
				yield return wait;
			}
			t1.SetPositionAndRotation(t2Pos, t2Rot);
		}

		public static IEnumerator AlignLookAtTransform(Transform t1, Vector3 targetPosition, float time, AnimationCurve curve = null)
		{
			float elapsedTime = 0f;
			WaitForFixedUpdate wait = new WaitForFixedUpdate();
			Quaternion CurrentRot = t1.rotation;
			Vector3 normalized = (targetPosition - t1.position).normalized;
			if (normalized.CloseToZero())
			{
				Debug.LogWarning("Direction is Zero. Please set a correct rotation", t1);
				yield return null;
				yield break;
			}
			normalized = Vector3.ProjectOnPlane(normalized, t1.up);
			Quaternion FinalRot = Quaternion.LookRotation(normalized);
			while (time > 0f && elapsedTime <= time)
			{
				float t2 = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				t1.rotation = Quaternion.SlerpUnclamped(CurrentRot, FinalRot, t2);
				elapsedTime += Time.fixedDeltaTime;
				yield return wait;
			}
			t1.rotation = FinalRot;
		}

		public static IEnumerator AlignTransformRadius(Transform TargetToAlign, Vector3 AlignOrigin, float time, float radius, AnimationCurve curve = null)
		{
			if (radius > 0f)
			{
				float elapsedTime = 0f;
				WaitForFixedUpdate Wait = new WaitForFixedUpdate();
				Vector3 CurrentPos = TargetToAlign.position;
				Ray ray = new Ray(AlignOrigin, (TargetToAlign.position - AlignOrigin).normalized);
				Vector3 TargetPos = ray.GetPoint(radius);
				Debug.DrawRay(ray.origin, ray.direction, Color.white, 1f);
				TargetToAlign.TryDeltaRootMotion();
				MDebug.DrawWireSphere(TargetPos, Color.red, 0.05f, 3f);
				while (time > 0f && elapsedTime <= time)
				{
					float t = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
					TargetToAlign.position = Vector3.LerpUnclamped(CurrentPos, TargetPos, t);
					MDebug.DrawWireSphere(TargetToAlign.position, Color.white, 0.05f, 3f);
					elapsedTime += Time.fixedDeltaTime;
					yield return Wait;
				}
				TargetToAlign.position = TargetPos;
			}
			yield return null;
		}

		public static IEnumerator AlignTransformRadius(Transform objectToAlign, Transform target, float time, float radius, AnimationCurve curve = null)
		{
			if (radius > 0f)
			{
				float elapsedTime = 0f;
				WaitForFixedUpdate Wait = new WaitForFixedUpdate();
				objectToAlign.TryDeltaRootMotion();
				while (time > 0f && elapsedTime <= time)
				{
					yield return Wait;
					Vector3 normalized = (target.position - objectToAlign.position).normalized;
					Vector3 vector = target.position - normalized * radius;
					float t = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
					objectToAlign.position = Vector3.LerpUnclamped(objectToAlign.position, vector, t);
					MDebug.DrawWireSphere(vector, Color.white, 0.05f, 3f);
					MDebug.DrawRay(vector, Vector3.up, Color.white);
					MDebug.DrawWireSphere(objectToAlign.position, Color.white, 0.05f, 3f);
					MDebug.DrawRay(objectToAlign.position, Vector3.up, Color.white);
					elapsedTime += Time.fixedDeltaTime;
				}
				objectToAlign.position = target.position - (target.position - objectToAlign.position).normalized * radius;
			}
			yield return null;
		}

		public static IEnumerator AlignTransform_Rotation(Transform t1, Quaternion NewRotation, float time, AnimationCurve curve = null)
		{
			float elapsedTime = 0f;
			WaitForFixedUpdate Wait = new WaitForFixedUpdate();
			Quaternion CurrentRot = t1.rotation;
			while (time > 0f && elapsedTime <= time)
			{
				float t2 = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				t1.rotation = Quaternion.LerpUnclamped(CurrentRot, NewRotation, t2);
				elapsedTime += Time.fixedDeltaTime;
				yield return Wait;
			}
			t1.rotation = NewRotation;
		}

		public static IEnumerator AlignTransformLocal(Transform obj, Vector3 LocalPos, Vector3 LocalRot, float time)
		{
			float elapsedtime = 0f;
			WaitForFixedUpdate Wait = new WaitForFixedUpdate();
			Vector3 startPos = obj.localPosition;
			Quaternion startRot = obj.localRotation;
			while (elapsedtime < time)
			{
				obj.localPosition = Vector3.Slerp(startPos, LocalPos, Mathf.SmoothStep(0f, 1f, elapsedtime / time));
				obj.localRotation = Quaternion.Slerp(startRot, Quaternion.Euler(LocalRot), elapsedtime / time);
				elapsedtime += Time.deltaTime;
				yield return Wait;
			}
			obj.localPosition = LocalPos;
			obj.localEulerAngles = LocalRot;
		}

		public static IEnumerator AlignTransformLocal(Transform obj, Vector3 LocalPos, Vector3 LocalRot, Vector3 localScale, float time)
		{
			float elapsedtime = 0f;
			WaitForFixedUpdate Wait = new WaitForFixedUpdate();
			obj.GetLocalPositionAndRotation(out var startPos, out var startRot);
			Vector3 startScale = obj.localScale;
			while (elapsedtime < time)
			{
				obj.SetLocalPositionAndRotation(Vector3.Slerp(startPos, LocalPos, Mathf.SmoothStep(0f, 1f, elapsedtime / time)), Quaternion.Slerp(startRot, Quaternion.Euler(LocalRot), elapsedtime / time));
				obj.localScale = Vector3.Lerp(startScale, localScale, Mathf.SmoothStep(0f, 1f, elapsedtime / time));
				elapsedtime += Time.deltaTime;
				yield return Wait;
			}
			obj.localPosition = LocalPos;
			obj.localEulerAngles = LocalRot;
			obj.localScale = localScale;
		}

		public static IEnumerator AlignTransform(Transform obj, TransformOffset offset, float time)
		{
			yield return AlignTransformLocal(obj, offset.Position, offset.Rotation, offset.Scale, time);
		}

		public static bool SearchParameter(AnimatorControllerParameter[] parameters, string name)
		{
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i].name == name)
				{
					return true;
				}
			}
			return false;
		}

		public static void ResetFloatParameters(Animator animator)
		{
			if (!animator)
			{
				return;
			}
			AnimatorControllerParameter[] parameters = animator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				if (!animator.IsParameterControlledByCurve(animatorControllerParameter.name) && animatorControllerParameter.type == AnimatorControllerParameterType.Float)
				{
					animator.SetFloat(animatorControllerParameter.nameHash, animatorControllerParameter.defaultFloat);
				}
			}
		}

		public static bool FindAnimatorParameter(Animator animator, AnimatorControllerParameterType type, string ParameterName)
		{
			AnimatorControllerParameter[] parameters = animator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				if (animatorControllerParameter.type == type && animatorControllerParameter.name == ParameterName)
				{
					return true;
				}
			}
			return false;
		}

		public static bool FindAnimatorParameter(Animator animator, AnimatorControllerParameterType type, int hash)
		{
			AnimatorControllerParameter[] parameters = animator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				if (animatorControllerParameter.type == type && animatorControllerParameter.nameHash == hash)
				{
					return true;
				}
			}
			return false;
		}

		public static Transform GetClosestTransform(Vector3 rPosition, Transform rCollider, LayerMask mask)
		{
			float rMinDistance = float.MaxValue;
			Transform rMinTransform = rCollider;
			GetClosestTransform(rPosition, rCollider, ref rMinDistance, ref rMinTransform, mask);
			return rMinTransform;
		}

		public static void GetClosestTransform(Vector3 rPosition, Transform rTransform, ref float rMinDistance, ref Transform rMinTransform, LayerMask mask)
		{
			if (rTransform.gameObject.activeInHierarchy)
			{
				float num = Vector3.Distance(rPosition, rTransform.position);
				MDebug.DrawLine(rPosition, rTransform.position, Color.red, 0.5f);
				if (num < rMinDistance && Layer_in_LayerMask(rTransform.gameObject.layer, mask))
				{
					rMinDistance = num;
					rMinTransform = rTransform;
				}
				for (int i = 0; i < rTransform.childCount; i++)
				{
					Transform child = rTransform.GetChild(i);
					GetClosestTransform(rPosition, child, ref rMinDistance, ref rMinTransform, mask);
				}
			}
		}

		public static void SetDirty(UnityEngine.Object ob)
		{
		}

		public static List<T> GetAllInstances<T>() where T : UnityEngine.Object
		{
			return null;
		}

		public static T GetInstance<T>(string name) where T : UnityEngine.Object
		{
			return null;
		}
	}
}
