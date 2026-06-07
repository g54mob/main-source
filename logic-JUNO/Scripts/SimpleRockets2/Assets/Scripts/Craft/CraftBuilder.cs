using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Events;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.State;
using Jundroo.ModTools;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class CraftBuilder
	{
		public struct CenterOfMassResult
		{
			public float TotalMass { get; set; }

			public Vector3 WorldCenterOfMass { get; set; }
		}

		public CraftData Craft { get; private set; }

		private static bool InDesigner => Game.InDesignerScene;

		public static event EventHandler<CreatedBodyJointEventArgs> CreatedBodyJoint;

		public static event EventHandler<CreatedBodyScriptEventArgs> CreatedBodyScript;

		public static event EventHandler<CreatedCraftScriptEventArgs> CreatedCraftScript;

		public static event EventHandler<CreatedPartGameObjectEventArgs> CreatedPartGameObject;

		public static event EventHandler<CreatedPartGameObjectsEventArgs> CreatedPartGameObjects;

		public static event EventHandler<CreatingBodyJointEventArgs> CreatingBodyJoint;

		public static event EventHandler<CreatingBodyScriptEventArgs> CreatingBodyScript;

		public static event EventHandler<CreatingCraftScriptEventArgs> CreatingCraftScript;

		public static event EventHandler<CreatingPartGameObjectEventArgs> CreatingPartGameObject;

		public static event EventHandler<CreatingPartGameObjectsEventArgs> CreatingPartGameObjects;

		public CraftBuilder(CraftData craft)
		{
			Craft = craft;
		}

		public static CenterOfMassResult CalculateCenterOfMass(ICollection<PartData> parts)
		{
			CenterOfMassResult result = default(CenterOfMassResult);
			Vector3 worldCenterOfMass = Vector3.zero;
			foreach (PartData part in parts)
			{
				float mass = part.Mass;
				Vector3 vector = part.PartScript.Transform.TransformPoint(part.PartScript.Data.Config.CenterOfMass);
				result.WorldCenterOfMass += vector * mass;
				result.TotalMass += mass;
				worldCenterOfMass = vector;
			}
			if (result.TotalMass > 0.005f)
			{
				result.WorldCenterOfMass /= result.TotalMass;
			}
			else
			{
				result.TotalMass = 0.005f;
				result.WorldCenterOfMass = worldCenterOfMass;
			}
			return result;
		}

		public static void CalculateInertiaTensors(IBodyScript bodyScript, bool finalKinematicState)
		{
			float num = 1f;
			float num2 = 0.05f;
			foreach (PartData part in bodyScript.Data.Parts)
			{
				((PartScript)part.PartScript).OnInertiaTensorCalculation(starting: true);
				num += part.InertiaTensorScale - 1f;
				num2 = Mathf.Max(num2, part.Config.InertiaTensorMin);
			}
			bodyScript.RigidBody.isKinematic = false;
			bodyScript.RigidBody.ResetInertiaTensor();
			if (bodyScript.RigidBody.inertiaTensor.magnitude * num > num2)
			{
				bodyScript.RigidBody.inertiaTensor *= num;
			}
			else
			{
				bodyScript.RigidBody.inertiaTensor = Vector3.Max(Vector3.one * 0.05f, bodyScript.RigidBody.inertiaTensor).normalized * num2;
			}
			if (bodyScript.RigidBody.isKinematic != finalKinematicState)
			{
				bodyScript.RigidBody.isKinematic = finalKinematicState;
			}
			foreach (PartData part2 in bodyScript.Data.Parts)
			{
				((PartScript)part2.PartScript).OnInertiaTensorCalculation(starting: false);
			}
		}

		public static BodyData CreateBodyData(ICollection<PartData> parts, Transform craftTransform)
		{
			CenterOfMassResult centerOfMassResult = CalculateCenterOfMass(parts);
			if (float.IsNaN(centerOfMassResult.WorldCenterOfMass.x) || float.IsNaN(centerOfMassResult.WorldCenterOfMass.y) || float.IsNaN(centerOfMassResult.WorldCenterOfMass.z))
			{
				Debug.Log("TODO: CoM is NaN");
				centerOfMassResult.WorldCenterOfMass = Vector3.zero;
			}
			BodyData bodyData = new BodyData(craftTransform.InverseTransformPoint(centerOfMassResult.WorldCenterOfMass), Vector3.zero, centerOfMassResult.TotalMass);
			bodyData.Parts.AddRange(parts);
			return bodyData;
		}

		public static void CreateBodyDatas(ICraftScript craftScript)
		{
			List<List<PartData>> list = CreateBodyPartLists(craftScript.Data.Assembly.Parts);
			craftScript.Data.Assembly.RemoveAllBodies();
			foreach (List<PartData> item in list)
			{
				BodyData body = CreateBodyData(item, craftScript.Transform);
				craftScript.Data.Assembly.AddBody(body);
			}
			CreateBodyJointDatas(craftScript);
		}

		public static BodyJoint CreateBodyJoint(PartConnection partConnection)
		{
			CreatingBodyJointEventArgs.RaiseStaticEvent(CraftBuilder.CreatingBodyJoint, partConnection);
			BodyJointData bodyJointData = partConnection.BodyJointData;
			BodyJoint bodyJoint = new BodyJoint(partConnection, bodyJointData.Body.BodyScript, bodyJointData.ConnectedBody.BodyScript);
			bodyJointData.Body.BodyScript.Joints.Add(bodyJoint);
			bodyJointData.ConnectedBody.BodyScript.Joints.Add(bodyJoint);
			bool flag = false;
			AttachPoint attachPoint = null;
			if (partConnection.Attachments.Count == 1)
			{
				if (partConnection.Attachments[0].AttachPointA.RequiresPhysicsJoint)
				{
					attachPoint = partConnection.Attachments[0].AttachPointA;
				}
				else if (partConnection.Attachments[0].AttachPointB.RequiresPhysicsJoint)
				{
					attachPoint = partConnection.Attachments[0].AttachPointB;
				}
				flag = partConnection.Attachments[0].AttachPointA.DisableJointCollisions || partConnection.Attachments[0].AttachPointB.DisableJointCollisions;
			}
			if (!bodyJointData.ConnectedBodyNeutralPosition.HasValue)
			{
				bodyJointData.ConnectedBodyNeutralPosition = bodyJointData.Body.BodyScript.Transform.InverseTransformPoint(bodyJointData.ConnectedBody.BodyScript.Transform.position);
			}
			if (!bodyJointData.ConnectedBodyNeutralRotation.HasValue)
			{
				bodyJointData.ConnectedBodyNeutralRotation = (Quaternion.Inverse(bodyJointData.Body.BodyScript.Transform.rotation) * bodyJointData.ConnectedBody.BodyScript.Transform.rotation).eulerAngles;
			}
			Joint joint = CreateJoint(bodyJointData.Body, bodyJointData.Position, bodyJointData.Axis, bodyJointData.SecondaryAxis, bodyJointData.ConnectedBody, bodyJointData.ConnectedPosition, bodyJointData.ConnectedBodyNeutralPosition, bodyJointData.ConnectedBodyNeutralRotation, bodyJointData.JointType, !flag, bodyJointData.BreakTorque, bodyJointData.BreakForce);
			bodyJoint.SetJoint(joint, attachPoint);
			CreatedBodyJointEventArgs.RaiseStaticEvent(CraftBuilder.CreatedBodyJoint, partConnection, attachPoint, bodyJoint, joint);
			return bodyJoint;
		}

		public static BodyScript CreateBodyScript(CraftScript craftScript, BodyData body, Quaternion? bodyRotation = null)
		{
			CreatingBodyScriptEventArgs.RaiseStaticEvent(CraftBuilder.CreatingBodyScript, craftScript, body);
			GameObject gameObject = new GameObject("Body-" + body.Id);
			gameObject.layer = 31;
			Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
			rigidbody.maxAngularVelocity = GetMaxAngularVelocityForBody(body.Mass);
			rigidbody.angularDrag = 0.05f;
			rigidbody.mass = body.Mass;
			rigidbody.centerOfMass = Vector3.zero;
			rigidbody.interpolation = RigidbodyInterpolation.None;
			BodyScript bodyScript = gameObject.AddComponent<BodyScript>();
			bodyScript.Initialize(craftScript, body, rigidbody);
			gameObject.transform.localPosition = body.Position;
			if (bodyRotation.HasValue)
			{
				gameObject.transform.localRotation = bodyRotation.Value;
			}
			else
			{
				gameObject.transform.localRotation = Quaternion.Euler(body.Rotation);
			}
			foreach (PartData part in bodyScript.Data.Parts)
			{
				(part.PartScript as PartScript).BodyScript = bodyScript;
			}
			body.BodyScript = bodyScript;
			bodyScript.CalculateDrag();
			CreatedBodyScriptEventArgs.RaiseStaticEvent(CraftBuilder.CreatedBodyScript, craftScript, body, bodyScript);
			return bodyScript;
		}

		public static CraftScript CreateCraftScript(CraftData craft, bool createBodyScripts, bool initialLaunch = false)
		{
			CraftScript craftScript = null;
			GameObject gameObject = null;
			string text = craft?.Name ?? string.Empty;
			try
			{
				ApplicationState.PushTask("Creating Craft Script: " + text);
				CreatingCraftScriptEventArgs.RaiseStaticEvent(CraftBuilder.CreatingCraftScript, craft, createBodyScripts);
				gameObject = new GameObject("Craft");
				gameObject.layer = 31;
				craftScript = gameObject.AddComponent<CraftScript>();
				craftScript.Initialize(craft);
				if (Game.InFlightScene)
				{
					PartConnection[] array = craft.Assembly.PartConnections.ToArray();
					foreach (PartConnection partConnection in array)
					{
						if (partConnection.BreakOnStart)
						{
							partConnection.DestroyConnection();
						}
					}
					RemoveInvalidParts(craftScript, initialLaunch);
				}
				CreatePartGameObjects(craftScript.Data.Assembly.Parts, craftScript);
				if (createBodyScripts)
				{
					CreateBodyScripts(craftScript.Data.Assembly, craftScript);
					FuselageSmoother.FlightSmooth(craftScript.FuselageScripts);
				}
				else
				{
					FuselageSmoother.BatchDesignerSmooth(craftScript.FuselageScripts);
				}
				craftScript.OnCraftLoaded(movedToNewCraft: false, initialLaunch);
				CreatedCraftScriptEventArgs.RaiseStaticEvent(CraftBuilder.CreatedCraftScript, craft, createBodyScripts, craftScript);
				Resources.UnloadUnusedAssets();
				return craftScript;
			}
			catch (Exception innerException)
			{
				gameObject.SetActive(value: false);
				throw new Exception("Failed to create CraftScript for '" + text + "'", innerException);
			}
			finally
			{
				ApplicationState.PopTask("Creating Craft Script: " + text);
			}
		}

		public static void CreateModifierScripts(PartData part)
		{
			foreach (PartModifierData modifier in part.Modifiers)
			{
				try
				{
					modifier.CreateScript();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogErrorFormat("Error enabling modifier ({0})", modifier.Name);
				}
			}
		}

		public static GameObject CreatePartGameObject(PartData part, ICraftScript craftScript)
		{
			CreatingPartGameObjectEventArgs.RaiseStaticEvent(CraftBuilder.CreatingPartGameObject, part, craftScript);
			GameObject gameObject = null;
			string prefabPath = part.PartType.PrefabPath;
			if (!string.IsNullOrEmpty(prefabPath))
			{
				ILoadedMod mod = part.PartType.Mod;
				if (mod != null && prefabPath.StartsWith("Assets/", StringComparison.Ordinal))
				{
					GameObject gameObject2 = mod.ResourceLoader.LoadAsset<GameObject>(prefabPath);
					if (gameObject2 != null)
					{
						gameObject = UnityEngine.Object.Instantiate(gameObject2);
					}
				}
				else
				{
					prefabPath = prefabPath.Replace(".prefab", string.Empty);
					gameObject = Game.Instance.ResourceLoader.InstantiatePrefab(prefabPath);
				}
			}
			if (gameObject == null)
			{
				Debug.LogErrorFormat("Unable to load part '{0}' because its prefab could not be found", part.PartType.PrefabPath);
				return null;
			}
			if (!part.ThemeDataId.HasValue)
			{
				part.ThemeData = craftScript.Data.Themes[0];
			}
			else
			{
				foreach (ThemeData theme in craftScript.Data.Themes)
				{
					if (part.ThemeDataId == theme.Id)
					{
						part.ThemeData = theme;
					}
				}
			}
			if (part.ThemeData == null)
			{
				Debug.LogErrorFormat("Unable to find theme {0} for part {1} ({2})", part.ThemeDataId, part.Id, part.PartType.Name);
			}
			gameObject.name = part.PartType.Name + "-" + part.Id;
			gameObject.transform.SetParent(craftScript.Transform, worldPositionStays: false);
			gameObject.transform.localRotation = Quaternion.Euler(part.Rotation);
			gameObject.transform.localPosition = part.Position;
			PartScript partScript = gameObject.AddComponent<PartScript>();
			EnabledScript.ProcessGameObject(partScript.gameObject);
			partScript.Initialize(part, craftScript);
			Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(gameObject, 31);
			if (InDesigner)
			{
				partScript.CreateAttachPoints();
				partScript.UpdateAttachPoints();
			}
			part.PartScript = partScript;
			CreatedPartGameObjectEventArgs.RaiseStaticEvent(CraftBuilder.CreatedPartGameObject, part, craftScript, partScript);
			return gameObject;
		}

		public static void CreatePartGameObjects(IEnumerable<PartData> parts, ICraftScript craftScript)
		{
			CreatingPartGameObjectsEventArgs.RaiseStaticEvent(CraftBuilder.CreatingPartGameObjects, parts, craftScript);
			foreach (PartData part in parts)
			{
				CreatePartGameObject(part, craftScript);
			}
			foreach (PartData part2 in parts)
			{
				CreateModifierScripts(part2);
			}
			foreach (PartData part3 in parts)
			{
				part3.PartScript.Transform.localScale = part3.Config.PartScale;
			}
			Physics.SyncTransforms();
			foreach (PartData part4 in parts)
			{
				part4.PartScript.OnModifiersCreated();
				part4.PartScript.OnCommandPodChanged();
			}
			CreatedPartGameObjectsEventArgs.RaiseStaticEvent(CraftBuilder.CreatedPartGameObjects, parts, craftScript);
		}

		public static PartData DuplicatePart(PartData part, ICraftScript craftScript, bool clearSymmetryIds, bool clearGroupIds, bool? mirrorOverride = null)
		{
			PartData partData = new PartData(part.GenerateXml(craftScript.Transform, optimizeXml: true), craftScript.Data.XmlVersion, part.PartType);
			partData.CommandPod = part.CommandPod;
			partData.IsRootPart = false;
			if (mirrorOverride.HasValue)
			{
				partData.Mirrored = mirrorOverride.Value;
			}
			if (clearSymmetryIds)
			{
				partData.SymmetryId = null;
				foreach (PartModifierData modifier in partData.Modifiers)
				{
					modifier.SymmetryId = null;
				}
			}
			if (clearGroupIds)
			{
				partData.GroupId = null;
			}
			CreatePartGameObjects(new PartData[1] { partData }, craftScript);
			craftScript.Data.Assembly.AddPart(partData);
			(partData.PartScript as PartScript).OnCloned();
			return partData;
		}

		public static float GetMaxAngularVelocityForBody(float mass)
		{
			return Mathf.Clamp(1f / mass * 5000f, 3f, 1000f);
		}

		public static BodyData GetPartBodyData(PartData part, Assembly assembly)
		{
			foreach (BodyData body in assembly.Bodies)
			{
				if (body.Parts.Contains(part))
				{
					return body;
				}
			}
			return null;
		}

		public static void SetJointTargetRotation(ConfigurableJoint joint, Quaternion targetBodyLocalRotation)
		{
			Vector3 axis = joint.axis;
			Vector3 normalized = Vector3.Cross(joint.axis, joint.secondaryAxis).normalized;
			Vector3 normalized2 = Vector3.Cross(normalized, axis).normalized;
			Quaternion quaternion = Quaternion.LookRotation(normalized, normalized2);
			Quaternion targetRotation = Quaternion.Inverse(quaternion);
			targetRotation *= targetBodyLocalRotation;
			targetRotation *= quaternion;
			joint.targetRotation = targetRotation;
		}

		public CraftScript BuildCraft(bool createRigidBodies, bool initialLaunch)
		{
			return CreateCraftScript(Craft, createRigidBodies, initialLaunch);
		}

		private static bool AreBodiesConnectedWithJoint(IBodyScript bodyA, IBodyScript bodyB)
		{
			foreach (IBodyJoint joint in bodyA.Joints)
			{
				if ((joint.Body == bodyA || joint.Body == bodyB) && (joint.ConnectedBody == bodyA || joint.ConnectedBody == bodyB))
				{
					return true;
				}
			}
			return false;
		}

		private static void BuildPartGroup(PartData part, List<PartData> remainingParts, PartGroupScript partGroup, int maxPartsPerGroup)
		{
			PartScript obj = part.PartScript as PartScript;
			obj.transform.SetParent(partGroup.transform, worldPositionStays: true);
			obj.AssignToPartGroup(partGroup);
			partGroup.Data.Parts.Add(part);
			remainingParts.Remove(part);
			foreach (PartConnection partConnection in part.PartConnections)
			{
				if (partGroup.Data.Parts.Count < maxPartsPerGroup)
				{
					PartData otherPart = partConnection.GetOtherPart(part);
					if (!otherPart.PartType.MustBeBySelfInPartGroup && remainingParts.Contains(otherPart))
					{
						BuildPartGroup(otherPart, remainingParts, partGroup, maxPartsPerGroup);
					}
				}
			}
		}

		private static BodyJointData CreateBodyJointData(PartConnection partConnection, ICraftScript craftScript)
		{
			BodyJointData bodyJointData = new BodyJointData(partConnection);
			if (partConnection.Attachments.Count == 1 && partConnection.Attachments[0].AttachPointA.RequiresPhysicsJoint)
			{
				_ = partConnection.Attachments[0].AttachPointB.RequiresPhysicsJoint;
			}
			bodyJointData.Axis = Vector3.forward;
			bodyJointData.SecondaryAxis = Vector3.up;
			Assembly assembly = craftScript.Data.Assembly;
			BodyData partBodyData = GetPartBodyData(partConnection.PartA, assembly);
			BodyData partBodyData2 = GetPartBodyData(partConnection.PartB, assembly);
			Vector3 position;
			if (partConnection.Attachments.Count == 1 && partConnection.Attachments[0].AttachPointA.RequiresPhysicsJoint)
			{
				AttachPoint attachPointA = partConnection.Attachments[0].AttachPointA;
				bodyJointData.Axis = attachPointA.AttachPointScript.WorldJointAxis;
				bodyJointData.SecondaryAxis = attachPointA.AttachPointScript.WorldSecondaryJointAxis;
				position = partConnection.PartA.PartScript.Transform.TransformPoint(GetAttachPointPosition(attachPointA.Position, partConnection.PartA));
				if (attachPointA.JointPosition.HasValue)
				{
					position = partConnection.PartA.PartScript.Transform.TransformPoint(GetAttachPointPosition(attachPointA.JointPosition.Value, partConnection.PartA));
				}
				bodyJointData.Body = partBodyData;
				bodyJointData.ConnectedBody = partBodyData2;
				bodyJointData.JointType = GetBodyJointType(attachPointA.JointType);
			}
			else if (partConnection.Attachments.Count == 1 && partConnection.Attachments[0].AttachPointB.RequiresPhysicsJoint)
			{
				AttachPoint attachPointB = partConnection.Attachments[0].AttachPointB;
				bodyJointData.Axis = attachPointB.AttachPointScript.WorldJointAxis;
				bodyJointData.SecondaryAxis = attachPointB.AttachPointScript.WorldSecondaryJointAxis;
				position = partConnection.PartB.PartScript.Transform.TransformPoint(GetAttachPointPosition(attachPointB.Position, partConnection.PartB));
				if (attachPointB.JointPosition.HasValue)
				{
					position = partConnection.PartB.PartScript.Transform.TransformPoint(GetAttachPointPosition(attachPointB.JointPosition.Value, partConnection.PartB));
				}
				bodyJointData.Body = partBodyData2;
				bodyJointData.ConnectedBody = partBodyData;
				bodyJointData.JointType = GetBodyJointType(attachPointB.JointType);
			}
			else
			{
				if (partConnection.Attachments.Count > 0)
				{
					position = GetCenterOfAttachPoints(partConnection);
				}
				else
				{
					Debug.LogErrorFormat("No attachments found for part connection. PartA={1}, PartB={2}", partConnection.PartA.Id, partConnection.PartB.Id);
					position = Vector3.zero;
				}
				bodyJointData.JointType = BodyJointData.BodyJointType.Normal;
				if (partBodyData.Mass < partBodyData2.Mass)
				{
					bodyJointData.Body = partBodyData2;
					bodyJointData.ConnectedBody = partBodyData;
				}
				else
				{
					bodyJointData.Body = partBodyData;
					bodyJointData.ConnectedBody = partBodyData2;
				}
			}
			bodyJointData.Position = craftScript.Transform.InverseTransformPoint(position) - bodyJointData.Body.Position;
			bodyJointData.ConnectedPosition = craftScript.Transform.InverseTransformPoint(position) - bodyJointData.ConnectedBody.Position;
			bodyJointData.BreakTorque = 10000000f;
			return bodyJointData;
		}

		private static void CreateBodyJointDatas(ICraftScript craftScript)
		{
			foreach (PartConnection partConnection in craftScript.Data.Assembly.PartConnections)
			{
				partConnection.BodyJointData = null;
				BodyData partBodyData = GetPartBodyData(partConnection.PartA, craftScript.Data.Assembly);
				BodyData partBodyData2 = GetPartBodyData(partConnection.PartB, craftScript.Data.Assembly);
				if (partBodyData != partBodyData2)
				{
					partConnection.BodyJointData = CreateBodyJointData(partConnection, craftScript);
				}
			}
		}

		private static List<List<PartData>> CreateBodyPartLists(IReadOnlyList<PartData> parts)
		{
			List<PartData> list = Utilities.CloneList(parts);
			List<List<PartData>> list2 = new List<List<PartData>>();
			while (list.Count > 0)
			{
				List<PartData> parts2 = new PartGraph(list[0], breakOnRigidBodyBoundary: true).Parts;
				list2.Add(parts2);
				foreach (PartData item in parts2)
				{
					list.Remove(item);
				}
			}
			return list2;
		}

		private static void CreateBodyScripts(Assembly assembly, CraftScript craftScript)
		{
			int partGroupId = 1;
			foreach (BodyData body in assembly.Bodies)
			{
				BodyScript bodyScript = CreateBodyScript(craftScript, body);
				CreatePartGroups(bodyScript, body.Parts, ref partGroupId);
				CalculateInertiaTensors(bodyScript, finalKinematicState: true);
				bodyScript.OnInitialized();
			}
			CreateJointsForRigidBodies(craftScript);
		}

		private static Joint CreateJoint(BodyData jointBodyData, Vector3 jointPosition, Vector3 jointAxis, Vector3 secondaryAxis, BodyData connectedBodyData, Vector3 connectedPosition, Vector3? connectedBodyNeutralPosition, Vector3? connectedBodyNeutralRotation, BodyJointData.BodyJointType jointType, bool enableCollision, float breakTorque, float breakForce)
		{
			IBodyScript bodyScript = jointBodyData.BodyScript;
			Rigidbody rigidBody = connectedBodyData.BodyScript.RigidBody;
			Quaternion localRotation = Quaternion.identity;
			Vector3 localPosition = Vector3.zero;
			if (true)
			{
				Transform transform = rigidBody.transform;
				localPosition = transform.localPosition;
				localRotation = transform.localRotation;
				if (connectedBodyNeutralPosition.HasValue)
				{
					transform.position = bodyScript.Transform.TransformPoint(connectedBodyNeutralPosition.Value);
				}
				if (connectedBodyNeutralRotation.HasValue)
				{
					transform.rotation = bodyScript.Transform.rotation * Quaternion.Euler(connectedBodyNeutralRotation.Value);
				}
			}
			Joint joint = null;
			if (jointType == BodyJointData.BodyJointType.Motor)
			{
				HingeJoint hingeJoint = bodyScript.GameObject.AddComponent<HingeJoint>();
				hingeJoint.useMotor = true;
				JointMotor motor = hingeJoint.motor;
				motor.freeSpin = true;
				hingeJoint.motor = motor;
				joint = hingeJoint;
			}
			else
			{
				ConfigurableJoint configurableJoint = bodyScript.GameObject.AddComponent<ConfigurableJoint>();
				configurableJoint.secondaryAxis = secondaryAxis;
				switch (jointType)
				{
				case BodyJointData.BodyJointType.Hinge:
					configurableJoint.xMotion = ConfigurableJointMotion.Locked;
					configurableJoint.yMotion = ConfigurableJointMotion.Locked;
					configurableJoint.zMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
					configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularXDrive = new JointDrive
					{
						maximumForce = 400000f,
						positionSpring = 400000f,
						positionDamper = 10f
					};
					break;
				case BodyJointData.BodyJointType.Docking:
					configurableJoint.xMotion = ConfigurableJointMotion.Locked;
					configurableJoint.yMotion = ConfigurableJointMotion.Locked;
					configurableJoint.zMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
					configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
					configurableJoint.rotationDriveMode = RotationDriveMode.XYAndZ;
					configurableJoint.angularXDrive = new JointDrive
					{
						maximumForce = 400000f,
						positionSpring = 400000f,
						positionDamper = 10f
					};
					configurableJoint.enableCollision = false;
					break;
				case BodyJointData.BodyJointType.Normal:
					configurableJoint.xMotion = ConfigurableJointMotion.Locked;
					configurableJoint.yMotion = ConfigurableJointMotion.Locked;
					configurableJoint.zMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
					break;
				default:
					Debug.LogError($"Unsupported joint type: {jointType}");
					break;
				}
				joint = configurableJoint;
			}
			joint.connectedBody = rigidBody;
			joint.autoConfigureConnectedAnchor = false;
			joint.axis = jointAxis;
			joint.anchor = jointPosition;
			joint.connectedAnchor = connectedPosition;
			if (breakTorque > 0f)
			{
				joint.breakTorque = breakTorque;
			}
			if (breakForce > 0f)
			{
				joint.breakForce = breakForce;
			}
			if (true)
			{
				rigidBody.transform.SetLocalPositionAndRotation(localPosition, localRotation);
			}
			return joint;
		}

		private static void CreateJointsForRigidBodies(CraftScript craftScript)
		{
			foreach (PartConnection partConnection in craftScript.Data.Assembly.PartConnections)
			{
				if (partConnection.BodyJointData != null)
				{
					CreateBodyJoint(partConnection);
				}
			}
		}

		private static void CreatePartGroups(BodyScript body, List<PartData> parts, ref int partGroupId)
		{
			List<PartData> list = new List<PartData>();
			list.AddRange(parts);
			int num = 5;
			int num2 = Mathf.Clamp(list.Count / num, 5, 25);
			while (list.Count > 0)
			{
				PartData partData = list[0];
				PartGroupScript partGroupScript = new GameObject("PartGroup").AddComponent<PartGroupScript>();
				partGroupScript.gameObject.name = "PartGroup-" + partGroupId;
				partGroupScript.Id = partGroupId++;
				partGroupScript.BodyScript = body;
				partGroupScript.transform.parent = body.transform;
				partGroupScript.transform.localPosition = Vector3.zero;
				partGroupScript.transform.localScale = Vector3.one;
				partGroupScript.transform.rotation = Quaternion.identity;
				BuildPartGroup(partData, list, partGroupScript, partData.PartType.MustBeBySelfInPartGroup ? 1 : num2);
				body.PartGroups.Add(partGroupScript);
			}
		}

		private static Vector3 GetAttachPointPosition(Vector3 p, PartData part)
		{
			return p;
		}

		private static BodyJointData.BodyJointType GetBodyJointType(JointType jointType)
		{
			return jointType switch
			{
				JointType.Hinge => BodyJointData.BodyJointType.Hinge, 
				JointType.Motor => BodyJointData.BodyJointType.Motor, 
				_ => BodyJointData.BodyJointType.Normal, 
			};
		}

		private static Vector3 GetCenterOfAttachPoints(PartConnection partConnection)
		{
			int num = 0;
			Vector3 zero = Vector3.zero;
			foreach (PartConnection.Attachment attachment in partConnection.Attachments)
			{
				if (attachment.AttachPointA.JointType != JointType.Fused || attachment.AttachPointB.JointType != JointType.Fused)
				{
					if (attachment.AttachPointA.JointType != JointType.Fused)
					{
						zero += partConnection.PartA.PartScript.Transform.TransformPoint(attachment.AttachPointA.Position);
						num++;
					}
					if (attachment.AttachPointB.JointType != JointType.Fused)
					{
						zero += partConnection.PartB.PartScript.Transform.TransformPoint(attachment.AttachPointB.Position);
						num++;
					}
					continue;
				}
				Debug.LogFormat("Both attachments are fused here. PartA={0}, PartB={1}", partConnection.PartA.Id, partConnection.PartB.Id);
				if (!attachment.AttachPointA.IsSurfaceAttachPoint)
				{
					zero += partConnection.PartA.PartScript.Transform.TransformPoint(attachment.AttachPointA.Position);
					num++;
				}
				if (!attachment.AttachPointB.IsSurfaceAttachPoint)
				{
					zero += partConnection.PartB.PartScript.Transform.TransformPoint(attachment.AttachPointB.Position);
					num++;
				}
			}
			if (num > 0)
			{
				zero /= (float)num;
			}
			else
			{
				Debug.LogErrorFormat("No suitable joint position was found with part connection PartA={0}, PartB={1}", partConnection.PartA.Id, partConnection.PartB.Id);
			}
			return zero;
		}

		private static bool IsPartInRigidBody(BodyData bodyData, PartData part)
		{
			foreach (PartData part2 in bodyData.Parts)
			{
				if (part2 == part)
				{
					return true;
				}
			}
			return false;
		}

		private static void RemoveInvalidParts(CraftScript craftScript, bool initialLaunch)
		{
			if (!craftScript.Data.RemoveInvalidParts)
			{
				foreach (PartData part in craftScript.Data.Assembly.Parts)
				{
					EvaData modifier = part.GetModifier<EvaData>();
					if (modifier != null && !modifier.IsTourist && Game.Instance.GameState.Crew.GetCrewMember(modifier.CrewId) == null && Game.IsCareer)
					{
						modifier.AssignCrewMember(Game.Instance.GameState.Crew.CreateCrewMember());
					}
				}
				return;
			}
			List<PartData> list = new List<PartData>();
			List<CrewMember> list2 = new List<CrewMember>();
			foreach (PartData part2 in craftScript.Data.Assembly.Parts)
			{
				EvaData modifier2 = part2.GetModifier<EvaData>();
				if (modifier2 == null || modifier2.IsTourist)
				{
					continue;
				}
				CrewMember crewMember = Game.Instance.GameState.Crew.GetCrewMember(modifier2.CrewId);
				if (crewMember != null && initialLaunch && (crewMember.State != CrewMemberState.Available || list2.Contains(crewMember)))
				{
					modifier2.AssignCrewMember(null);
					crewMember = null;
				}
				if (crewMember == null && Game.IsCareer)
				{
					if (part2.IsRootPart)
					{
						CrewMember crewMember2 = Game.Instance.GameState.Crew.GetAvailableCrew(craftScript.Data.Assembly)?.FirstOrDefault() ?? Game.Instance.GameState.Crew.CreateCrewMember();
						modifier2.AssignCrewMember(crewMember2);
					}
					else
					{
						list.Add(part2);
						Debug.LogWarning($"EVA part {modifier2?.Part?.Name}, id={modifier2?.Part?.Id} does not have associated crew member and has been removed.");
					}
				}
				if (crewMember != null)
				{
					list2.Add(crewMember);
				}
			}
			foreach (PartData item in list)
			{
				PartConnection[] array = item.PartConnections.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DestroyConnection();
				}
				foreach (BodyData body in craftScript.Data.Assembly.Bodies)
				{
					body.Parts.Remove(item);
				}
				craftScript.Data.Assembly.RemovePart(item);
			}
		}
	}
}
