using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.Exceptions;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design;
using Assets.Scripts.Input;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class Assembly
	{
		public delegate void CreateGameObjectsCallback(bool success, string message, Exception exception);

		private static class Profile
		{
			public static class CreateGameObjects
			{
				public static readonly ProfilerMarker BuildInitializationPlan = new ProfilerMarker("Create Assembly GameObjects -> Build Initialization Plan");

				public static readonly ProfilerMarker CreateGameObjectAsync = new ProfilerMarker("Create Assembly GameObjects -> CreateGameObjectAsync");

				public static readonly ProfilerMarker ExecuteInitializeDelegate = new ProfilerMarker("Create Assembly GameObjects -> Execute Initialize Delegate");

				private const string Prefix = "Create Assembly GameObjects";
			}
		}

		private class IdProvider
		{
			private static class Profile
			{
				public static readonly ProfilerMarker Register = new ProfilerMarker(Prefix + "Register");

				public static readonly ProfilerMarker RegisterNewId = new ProfilerMarker(Prefix + "RegisterNewId");

				public static readonly ProfilerMarker Unregister = new ProfilerMarker(Prefix + "Unregister");

				public static readonly ProfilerMarker UnregisterAll = new ProfilerMarker(Prefix + "UnregisterAll");

				private static readonly string Prefix = "Assembly.IdProvider.";
			}

			private int _count;

			private int[] _ids;

			public int Count => _count;

			public IdProvider()
			{
				_ids = new int[2];
				_count = 0;
			}

			public void Register(int id)
			{
				using (Profile.Register.Auto())
				{
					int num = Array.BinarySearch(_ids, 0, _count, id);
					if (num >= 0)
					{
						throw new InvalidOperationException($"ID {id} is already registered.");
					}
					if (_count == _ids.Length)
					{
						Array.Resize(ref _ids, _ids.Length * 2);
					}
					num = ~num;
					if (num < _count)
					{
						Array.Copy(_ids, num, _ids, num + 1, _count - num);
					}
					_ids[num] = id;
					_count++;
				}
			}

			public int RegisterNewId()
			{
				using (Profile.RegisterNewId.Auto())
				{
					int num = 1;
					int num2 = 0;
					while (num2 < _count && num == _ids[num2])
					{
						num2++;
						num++;
					}
					if (_count == _ids.Length)
					{
						Array.Resize(ref _ids, _ids.Length * 2);
					}
					if (num2 < _count)
					{
						Array.Copy(_ids, num2, _ids, num2 + 1, _count - num2);
					}
					_ids[num2] = num;
					_count++;
					return num;
				}
			}

			public void Unregister(int id)
			{
				using (Profile.Unregister.Auto())
				{
					int num = Array.BinarySearch(_ids, 0, _count, id);
					if (num < 0)
					{
						throw new InvalidOperationException($"ID {id} is not registered.");
					}
					_count--;
					if (num < _count)
					{
						Array.Copy(_ids, num + 1, _ids, num, _count - num);
					}
					_ids[_count] = 0;
				}
			}

			public void UnregisterAll()
			{
				using (Profile.UnregisterAll.Auto())
				{
					_count = 0;
				}
			}
		}

		private static int _progressCounter;

		private static int _progressPart;

		private Stack<uint> _availableSymmetryIds = new Stack<uint>();

		private Dictionary<int, PartData> _disabledParts = new Dictionary<int, PartData>();

		private IdProvider _idProvider = new IdProvider();

		private uint _nextSymmetryId = 1u;

		private Dictionary<int, PartData> _partDictionary = new Dictionary<int, PartData>();

		private List<PartData> _parts = new List<PartData>();

		private Dictionary<uint, List<PartData>> _symmetricParts = new Dictionary<uint, List<PartData>>();

		public IReadOnlyCollection<PartData> DisabledParts => _disabledParts.Values;

		public CraftLoadContext LoadContext { get; }

		public List<string> MissingParts { get; private set; }

		public IReadOnlyList<PartData> Parts => _parts;

		public List<RigidBodyGroup> RigidBodyGroups { get; set; }

		public Assembly(XElement assemblyElement, int aircraftXmlVersion, CraftLoadContext loadContext)
		{
			LoadContext = loadContext;
			RigidBodyGroups = new List<RigidBodyGroup>();
			IEnumerable<XElement> enumerable = assemblyElement.Element("Parts").Elements("Part");
			MissingParts = new List<string>();
			bool flag = false;
			foreach (XElement item in enumerable)
			{
				try
				{
					PartData partData = new PartData(item, aircraftXmlVersion, loadContext);
					partData.Enabled = partData.Enabled && (!partData.PartType.RequiredLoadContext.HasValue || partData.PartType.RequiredLoadContext == loadContext);
					if (partData.Enabled)
					{
						_parts.Add(partData);
						_idProvider.Register(partData.Id);
						AddPartToLookup(partData);
					}
					else
					{
						_disabledParts[partData.Id] = partData;
						_idProvider.Register(partData.Id);
					}
					flag |= partData.Id > 65535;
				}
				catch (InvalidPartTypeException ex)
				{
					if (!MissingParts.Contains(ex.PartId))
					{
						MissingParts.Add(ex.PartId);
					}
				}
			}
			if (flag && _parts.Count + _disabledParts.Count < 65535)
			{
				UnityEngine.Debug.Log($"Part ids larger than {ushort.MaxValue} found. Attempting to re-assign large part ids to valid values.");
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				foreach (PartData part in _parts)
				{
					if (part.Id <= 65535)
					{
						continue;
					}
					int id = part.Id;
					int num = _idProvider.RegisterNewId();
					_idProvider.Unregister(id);
					_partDictionary.Remove(id);
					_partDictionary[num] = part;
					string text = id.ToString();
					string text2 = num.ToString();
					part.Id = num;
					dictionary[id] = num;
					foreach (XElement item2 in assemblyElement.Elements("Connections").Elements("Connection"))
					{
						if ((string)item2.Attribute("partA") == text)
						{
							item2.SetAttributeValue("partA", text2);
						}
						if ((string)item2.Attribute("partB") == text)
						{
							item2.SetAttributeValue("partB", text2);
						}
					}
					foreach (XElement item3 in assemblyElement.Elements("Bodies").Elements("Body"))
					{
						string[] array = ((string)item3.Attribute("partIds"))?.Split(',', StringSplitOptions.RemoveEmptyEntries);
						if (array == null)
						{
							continue;
						}
						for (int i = 0; i < array.Length; i++)
						{
							if (array[i] == text)
							{
								array[i] = text2;
							}
						}
						item3.SetAttributeValue("partIds", string.Join(",", array));
					}
				}
				foreach (PartData part2 in _parts)
				{
					foreach (PartModifierData modifier in part2.Modifiers)
					{
						if (modifier is IPartIDChangedListener partIDChangedListener)
						{
							partIDChangedListener.OnPartIDsRemapped(dictionary);
						}
					}
				}
			}
			InitializePartSymmetry(assemblyElement, aircraftXmlVersion);
			IEnumerable<XElement> enumerable2 = assemblyElement.Elements("Connections");
			if (enumerable2 != null)
			{
				foreach (XElement item4 in enumerable2.Elements("Connection"))
				{
					if (!int.TryParse(item4.Attribute("partA")?.Value, out var result))
					{
						UnityEngine.Debug.LogError("Removing connection due to invalid connection partA attribute on element: " + item4.ToString());
						continue;
					}
					if (!int.TryParse(item4.Attribute("partB")?.Value, out var result2))
					{
						UnityEngine.Debug.LogError("Removing connection due to invalid connection partB attribute on element: " + item4.ToString());
						continue;
					}
					PartData partById = GetPartById(result);
					PartData partById2 = GetPartById(result2);
					if (partById == null)
					{
						UnityEngine.Debug.LogError("Could not find part ID: " + result);
					}
					if (partById2 == null)
					{
						UnityEngine.Debug.LogError("Could not find part ID: " + result2);
					}
					if (partById == null || partById2 == null || !partById.Enabled || !partById2.Enabled)
					{
						continue;
					}
					PartConnection partConnection = new PartConnection(partById, partById2);
					string[] array2 = item4.Attribute("attachPointsA").Value.Split(new char[1] { ',' });
					bool flag2 = false;
					string[] array3 = array2;
					for (int j = 0; j < array3.Length; j++)
					{
						if (!int.TryParse(array3[j], out var result3))
						{
							UnityEngine.Debug.LogError($"Removing connection due to invalid connection attachPointsA attribute on element: {item4}");
							flag2 = true;
						}
						else if (result3 < partConnection.PartA.AttachPoints.Count)
						{
							partConnection.AddAttachPointA(partConnection.PartA.AttachPoints[result3]);
						}
					}
					if (flag2)
					{
						partConnection.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: false);
						continue;
					}
					array3 = item4.Attribute("attachPointsB").Value.Split(new char[1] { ',' });
					for (int j = 0; j < array3.Length; j++)
					{
						if (!int.TryParse(array3[j], out var result4))
						{
							UnityEngine.Debug.LogError($"Removing connection due to invalid connection attachPointsB attribute on element: {item4}");
							flag2 = true;
						}
						else if (result4 < partConnection.PartB.AttachPoints.Count)
						{
							partConnection.AddAttachPointB(partConnection.PartB.AttachPoints[result4]);
						}
					}
					if (flag2)
					{
						partConnection.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: false);
					}
				}
			}
			IEnumerable<XElement> enumerable3 = assemblyElement.Elements("Bodies");
			if (enumerable3 != null)
			{
				foreach (XElement item5 in enumerable3.Elements("Body"))
				{
					RigidBodyGroup rigidBodyGroup = new RigidBodyGroup();
					string[] array3 = item5.Attribute("partIds").Value.Split(new char[1] { ',' });
					foreach (string text3 in array3)
					{
						PartData partById3 = GetPartById(int.Parse(text3));
						if (partById3 != null)
						{
							if (partById3.Enabled)
							{
								rigidBodyGroup.Parts.Add(partById3);
							}
						}
						else
						{
							UnityEngine.Debug.LogError("Could not find part with ID=" + text3);
						}
					}
					if (rigidBodyGroup.Parts.Count != 0)
					{
						rigidBodyGroup.Position = item5.GetVector3Attribute("position");
						rigidBodyGroup.Rotation = item5.GetVector3Attribute("rotation");
						rigidBodyGroup.Velocity = item5.GetVector3Attribute("velocity");
						rigidBodyGroup.AngularVelocity = item5.GetVector3Attribute("angularVelocity", Vector3.zero);
						RigidBodyGroups.Add(rigidBodyGroup);
					}
				}
			}
			foreach (PartData part3 in _parts)
			{
				foreach (PartModifierData modifier2 in part3.Modifiers)
				{
					modifier2.OnAssemblyLoaded(this, loadContext);
				}
			}
			foreach (PartData value in _disabledParts.Values)
			{
				foreach (PartModifierData modifier3 in value.Modifiers)
				{
					modifier3.OnAssemblyLoaded(this, loadContext);
				}
			}
		}

		private Assembly(CraftLoadContext loadContext)
		{
			LoadContext = loadContext;
			RigidBodyGroups = new List<RigidBodyGroup>();
		}

		public static Assembly CreateAssemblyFromParts(List<PartData> parts, CraftLoadContext loadContext)
		{
			Assembly assembly = new Assembly(loadContext);
			foreach (PartData part in parts)
			{
				assembly._parts.Add(part);
				assembly._idProvider.Register(part.Id);
				assembly.AddPartToLookup(part);
				CreateEditorCollidersForPartScript(part.PartScript);
			}
			return assembly;
		}

		public static BodyJoint CreateBodyJoint(PartConnection partConnection, BodyScript bodyA, BodyScript bodyB)
		{
			BodyJoint bodyJoint = new BodyJoint(partConnection, bodyA, bodyB);
			bodyA.Joints.Add(bodyJoint);
			bodyB.Joints.Add(bodyJoint);
			bool flag = false;
			Rigidbody rigidbody = null;
			bodyJoint.PreventInertiaTensorDiffusion = false;
			bodyJoint.BodyIslandBoundary = false;
			foreach (AttachPointData item in partConnection.AttachPointsA)
			{
				bodyJoint.PreventInertiaTensorDiffusion = bodyJoint.PreventInertiaTensorDiffusion || item.PreventInertiaTensorDiffusion;
				bodyJoint.BodyIslandBoundary = bodyJoint.BodyIslandBoundary || item.BodyIslandBoundary;
			}
			foreach (AttachPointData item2 in partConnection.AttachPointsB)
			{
				bodyJoint.PreventInertiaTensorDiffusion = bodyJoint.PreventInertiaTensorDiffusion || item2.PreventInertiaTensorDiffusion;
				bodyJoint.BodyIslandBoundary = bodyJoint.BodyIslandBoundary || item2.BodyIslandBoundary;
			}
			if (partConnection.AttachPointsA.Count == 1 && partConnection.AttachPointsA[0].RequiresPhysicsJoint && partConnection.AttachPointsB.Count == 1 && partConnection.AttachPointsB[0].RequiresPhysicsJoint)
			{
				GameObject gameObject = new GameObject("RigidBodyIntermediary");
				gameObject.transform.parent = bodyA.transform.parent;
				float mass = 0.25f;
				gameObject.transform.position = partConnection.PartA.PartScript.transform.TransformPoint(partConnection.AttachPointsA[0].Position);
				gameObject.transform.eulerAngles = Vector3.zero;
				rigidbody = gameObject.AddComponent<Rigidbody>();
				rigidbody.maxAngularVelocity = 10f;
				rigidbody.angularDamping = 0.05f;
				rigidbody.mass = mass;
				rigidbody.solverIterations = 50;
				bodyJoint.IntermediaryRigidbody = rigidbody;
			}
			Vector3 zero = Vector3.zero;
			if (partConnection.AttachPointsA.Count > 0 && !partConnection.AttachPointsA[0].IsSurfaceAttachPoint)
			{
				Vector3 centerOfAttachPoints = GetCenterOfAttachPoints(partConnection.AttachPointsA);
				zero = partConnection.PartA.PartScript.transform.TransformPoint(GetAttachPointPosition(centerOfAttachPoints, partConnection.PartA));
			}
			else
			{
				Vector3 centerOfAttachPoints2 = GetCenterOfAttachPoints(partConnection.AttachPointsB);
				zero = partConnection.PartB.PartScript.transform.TransformPoint(GetAttachPointPosition(centerOfAttachPoints2, partConnection.PartB));
			}
			if (partConnection.AttachPointsA.Count == 1 && partConnection.AttachPointsA[0].RequiresPhysicsJoint)
			{
				AttachPointData attachPointData = partConnection.AttachPointsA[0];
				Vector3 worldJointAxis = partConnection.PartA.PartScript.transform.TransformDirection(attachPointData.JointAxis);
				Vector3 vector = partConnection.PartA.PartScript.transform.TransformPoint(GetAttachPointPosition(attachPointData.Position, partConnection.PartA));
				vector = ((!attachPointData.JointPosition.HasValue) ? zero : partConnection.PartA.PartScript.transform.TransformPoint(GetAttachPointPosition(attachPointData.JointPosition.Value, partConnection.PartA)));
				Rigidbody connectedBody = bodyB.RigidBody.PhysxRigidBody;
				if (rigidbody != null)
				{
					connectedBody = rigidbody;
				}
				ConfigurableJoint joint = CreateJoint(bodyA, connectedBody, vector, worldJointAxis, attachPointData.JointType == JointType.Hinge, enableCollision: false, 0f);
				bodyJoint.SetJoint(joint, attachPointData);
				flag = true;
			}
			if (partConnection.AttachPointsB.Count == 1 && partConnection.AttachPointsB[0].RequiresPhysicsJoint)
			{
				AttachPointData attachPointData2 = partConnection.AttachPointsB[0];
				Vector3 worldJointAxis2 = partConnection.PartB.PartScript.transform.TransformDirection(attachPointData2.JointAxis);
				Vector3 vector2 = partConnection.PartB.PartScript.transform.TransformPoint(GetAttachPointPosition(attachPointData2.Position, partConnection.PartB));
				vector2 = ((!attachPointData2.JointPosition.HasValue) ? zero : partConnection.PartB.PartScript.transform.TransformPoint(GetAttachPointPosition(attachPointData2.JointPosition.Value, partConnection.PartB)));
				Rigidbody connectedBody2 = bodyA.RigidBody.PhysxRigidBody;
				if (rigidbody != null)
				{
					connectedBody2 = rigidbody;
				}
				ConfigurableJoint joint2 = CreateJoint(bodyB, connectedBody2, vector2, worldJointAxis2, attachPointData2.JointType == JointType.Hinge, enableCollision: false, 0f);
				bodyJoint.SetJoint(joint2, attachPointData2);
				flag = true;
			}
			if (rigidbody != null)
			{
				Collider[] componentsInChildren = bodyA.GetComponentsInChildren<Collider>();
				Collider[] componentsInChildren2 = bodyB.GetComponentsInChildren<Collider>();
				Collider[] array = componentsInChildren;
				foreach (Collider collider in array)
				{
					Collider[] array2 = componentsInChildren2;
					foreach (Collider collider2 in array2)
					{
						Physics.IgnoreCollision(collider, collider2, ignore: true);
					}
				}
			}
			if (!flag)
			{
				Vector3 worldJointPosition;
				if (partConnection.AttachPointsA.Count > 0 && !partConnection.AttachPointsA[0].IsSurfaceAttachPoint)
				{
					Vector3 centerOfAttachPoints3 = GetCenterOfAttachPoints(partConnection.AttachPointsA);
					worldJointPosition = partConnection.PartA.PartScript.transform.TransformPoint(centerOfAttachPoints3);
				}
				else
				{
					Vector3 centerOfAttachPoints4 = GetCenterOfAttachPoints(partConnection.AttachPointsB);
					worldJointPosition = partConnection.PartB.PartScript.transform.TransformPoint(centerOfAttachPoints4);
				}
				BodyScript bodyScript = null;
				Rigidbody rigidbody2 = null;
				Rigidbody component = bodyA.GetComponent<Rigidbody>();
				Rigidbody component2 = bodyB.GetComponent<Rigidbody>();
				if (component.mass < component2.mass)
				{
					bodyScript = bodyA;
					rigidbody2 = component2;
				}
				else
				{
					bodyScript = bodyB;
					rigidbody2 = component;
				}
				float breakTorque = 0f;
				if (partConnection.PartA.GetModifier<DetacherData>() == null && partConnection.PartB.GetModifier<DetacherData>() == null)
				{
					breakTorque = Mathf.Min(bodyA.GetJointBreakTorque(), bodyB.GetJointBreakTorque());
				}
				ConfigurableJoint joint3 = CreateJoint(bodyScript, rigidbody2, worldJointPosition, Vector3.right, hingeJoint: false, partConnection.EnableCollision, breakTorque);
				bodyJoint.SetJoint(joint3, null);
			}
			return bodyJoint;
		}

		public static void CreateEditorCollidersForPartScript(PartScript partScript)
		{
			partScript.EditorColliders.Clear();
			WingScript modifier = partScript.GetModifier<WingScript>();
			if (modifier != null)
			{
				partScript.EditorColliders.Add(new EditorCollider(modifier, partScript));
				return;
			}
			Collider[] componentsInChildren = partScript.GetComponentsInChildren<Collider>(includeInactive: true);
			foreach (Collider collider in componentsInChildren)
			{
				if (!(collider == null) && collider.gameObject.layer != 10)
				{
					collider.TryGetComponent<PartColliderScript>(out var component);
					if (!AttachPointScript.TryGetAttachPointFromCollider(collider, out var _) || !(component == null))
					{
						partScript.EditorColliders.Add(new EditorCollider(collider, partScript, component));
					}
				}
			}
		}

		public static void RunPreStartInitialization(PartScript part)
		{
			RunPreStartInitialization(BuildPreStartInitializationPlan(part.Aircraft, part));
		}

		public void Absorb(Assembly assembly)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (PartData part in assembly._parts)
			{
				int id = part.Id;
				AddPart(part);
				dictionary[id] = part.Id;
			}
			foreach (PartData part2 in assembly._parts)
			{
				foreach (PartModifierData modifier in part2.Modifiers)
				{
					if (modifier is IPartIDChangedListener partIDChangedListener)
					{
						partIDChangedListener.OnPartIDsRemapped(dictionary);
					}
				}
			}
			assembly._parts.Clear();
			assembly._idProvider.UnregisterAll();
		}

		public void AddPart(PartData part)
		{
			part.Id = _idProvider.RegisterNewId();
			_parts.Add(part);
			AddPartToLookup(part);
			CreateEditorCollidersForPartScript(part.PartScript);
			part.PartScript.PartMaterialScript.OnPartIdUpdated();
		}

		public void CreateGameObjects(AircraftScript aircraftScript, PartData.PartCreationInfo partCreationInfo, Transform parentGameObject)
		{
			foreach (PartData part in _parts)
			{
				if (part.Enabled)
				{
					part.CreateGameObject(aircraftScript, partCreationInfo);
				}
			}
			aircraftScript.IsNonFlyableAircraft = partCreationInfo.IsNonFlyableAircraft;
			List<BodyScript> list = new List<BodyScript>();
			int partGroupId = 1;
			if (!partCreationInfo.IsNonFlyableAircraft && partCreationInfo.CreateRigidBody)
			{
				foreach (RigidBodyGroup rigidBodyGroup in RigidBodyGroups)
				{
					BodyScript bodyScript = aircraftScript.CreateBodyScript(rigidBodyGroup);
					PartGroup.CreatePartGroups(bodyScript, rigidBodyGroup.Parts, ref partGroupId);
					list.Add(bodyScript);
				}
			}
			bool flag = aircraftScript.LoadContext == CraftLoadContext.Designer;
			foreach (PartData part2 in _parts)
			{
				if (part2.Enabled)
				{
					part2.EnableModifiers();
					if (flag)
					{
						CreateEditorCollidersForPartScript(part2.PartScript);
					}
				}
			}
			if (!partCreationInfo.IsNonFlyableAircraft && partCreationInfo.CreateRigidBody)
			{
				if (!partCreationInfo.RemoteAircraft)
				{
					CreateJointsForRigidBodies(aircraftScript);
				}
				foreach (BodyScript item in list)
				{
					item.CalculateDrag();
					item.CalculateIntake();
				}
			}
			foreach (PartData part3 in _parts)
			{
				FuselageScript modifier = part3.PartScript.GetModifier<FuselageScript>();
				if (modifier != null && (modifier.Fuselage.SmoothBack || modifier.Fuselage.SmoothFront))
				{
					modifier.SyncNormals(updateConnected: false);
				}
			}
			aircraftScript.VariableSystem.RefreshVariables();
			aircraftScript.UpdateMainCockpit();
			RunPreStartInitialization(BuildPreStartInitializationPlan(aircraftScript, this));
			aircraftScript.OnGenerationComplete();
		}

		public void CreateGameObjectsMultipleFrames(AircraftScript aircraftScript, PartData.PartCreationInfo partCreationInfo, Transform parentGameObject, CreateGameObjectsCallback callback, IAircraftLoadingStatus status = null)
		{
			UniTask.Void(async delegate
			{
				try
				{
					await CreateGameObjectsMultipleFramesAsync(aircraftScript, partCreationInfo, parentGameObject, activateCraft: true, status);
				}
				catch (Exception ex)
				{
					callback(success: false, ex.Message, ex);
					return;
				}
				callback(success: true, null, null);
			});
		}

		public async UniTask CreateGameObjectsMultipleFramesAsync(AircraftScript aircraftScript, PartData.PartCreationInfo partCreationInfo, Transform parentGameObject, bool activateCraft, IAircraftLoadingStatus status = null)
		{
			ReportProgress(status, 0, 0);
			aircraftScript.gameObject.SetActive(value: false);
			await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
			Stopwatch watch = new Stopwatch();
			watch.Start();
			Action<AircraftScript> checkForAbort = delegate(AircraftScript craftScript)
			{
				if (craftScript == null)
				{
					throw new CraftLoadAbortedException();
				}
			};
			List<UniTask<PartScript>> createGameObjectTasks;
			using (CollectionPool<List<UniTask<PartScript>>, UniTask<PartScript>>.Get(out createGameObjectTasks))
			{
				foreach (PartData part in _parts)
				{
					if (part.Enabled)
					{
						using (Profile.CreateGameObjects.CreateGameObjectAsync.Auto())
						{
							UniTask<PartScript> item = part.CreateGameObjectAsync(aircraftScript, partCreationInfo);
							createGameObjectTasks.Add(item);
						}
					}
					if (watch.ElapsedMilliseconds > 8)
					{
						await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
						checkForAbort(aircraftScript);
						watch.Restart();
					}
					ReportProgress(status, 1, _parts.Count);
				}
				await UniTask.WhenAll(createGameObjectTasks);
			}
			if (watch.ElapsedMilliseconds > 8)
			{
				await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
				await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
				checkForAbort(aircraftScript);
				watch.Restart();
			}
			aircraftScript.IsNonFlyableAircraft = partCreationInfo.IsNonFlyableAircraft;
			int partGroupId = 1;
			List<BodyScript> bodyScripts = new List<BodyScript>();
			if (!partCreationInfo.IsNonFlyableAircraft && partCreationInfo.CreateRigidBody)
			{
				foreach (RigidBodyGroup rigidBodyGroup in RigidBodyGroups)
				{
					BodyScript bodyScript = aircraftScript.CreateBodyScript(rigidBodyGroup);
					PartGroup.CreatePartGroups(bodyScript, rigidBodyGroup.Parts, ref partGroupId);
					bodyScripts.Add(bodyScript);
					if (watch.ElapsedMilliseconds > 8)
					{
						await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
						checkForAbort(aircraftScript);
						watch.Restart();
					}
					ReportProgress(status, 2, RigidBodyGroups.Count);
				}
			}
			bool inDesigner = aircraftScript.LoadContext == CraftLoadContext.Designer;
			foreach (PartData part2 in _parts)
			{
				if (part2.Enabled)
				{
					part2.EnableModifiers();
					if (inDesigner)
					{
						CreateEditorCollidersForPartScript(part2.PartScript);
					}
				}
				if (watch.ElapsedMilliseconds > 8)
				{
					await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
					checkForAbort(aircraftScript);
					watch.Restart();
				}
				ReportProgress(status, 3, _parts.Count);
			}
			if (!partCreationInfo.IsNonFlyableAircraft && partCreationInfo.CreateRigidBody)
			{
				if (!partCreationInfo.RemoteAircraft)
				{
					CreateJointsForRigidBodies(aircraftScript);
				}
				foreach (BodyScript item2 in bodyScripts)
				{
					item2.CalculateDrag();
					item2.CalculateIntake();
					if (watch.ElapsedMilliseconds > 8)
					{
						await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
						checkForAbort(aircraftScript);
						watch.Restart();
					}
					ReportProgress(status, 4, bodyScripts.Count);
				}
			}
			foreach (PartData part3 in _parts)
			{
				FuselageScript modifier = part3.PartScript.GetModifier<FuselageScript>();
				if (modifier != null && (modifier.Fuselage.SmoothBack || modifier.Fuselage.SmoothFront))
				{
					modifier.SyncNormals(updateConnected: false);
				}
				if (watch.ElapsedMilliseconds > 8)
				{
					await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
					checkForAbort(aircraftScript);
					watch.Restart();
				}
				ReportProgress(status, 5, _parts.Count);
			}
			aircraftScript.VariableSystem.RefreshVariables();
			aircraftScript.UpdateMainCockpit();
			await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
			await RunPreStartInitialization(BuildPreStartInitializationPlan(aircraftScript, this), 8f, checkForAbort, status);
			await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
			checkForAbort(aircraftScript);
			aircraftScript.OnGenerationComplete();
			if (LoadContext == CraftLoadContext.Flight)
			{
				aircraftScript.transform.position = new Vector3(-1000f, -1000f, -1000f) - aircraftScript.Aircraft.Size;
			}
			aircraftScript.gameObject.SetActive(activateCraft);
		}

		public XElement GenerateXml(bool createRigidBodyGroups)
		{
			XElement xElement = new XElement("Parts");
			XElement xElement2 = new XElement("Connections");
			List<string> list = new List<string>();
			foreach (PartData part in _parts)
			{
				xElement.Add(part.GenerateXml());
				foreach (PartConnection partConnection in part.PartConnections)
				{
					string item = partConnection.PartA.Id.ToString() + partConnection.PartB.Id;
					if (!list.Contains(item))
					{
						xElement2.Add(partConnection.GenerateXml());
						list.Add(item);
					}
				}
			}
			XElement xElement3 = new XElement("Assembly", xElement, xElement2);
			if (createRigidBodyGroups)
			{
				xElement3.Add(GenerateBodiesXml());
			}
			return xElement3;
		}

		public void GetOtherSymmetricParts(PartData part, IList<PartData> symmetricParts)
		{
			if (part.SymmetryId == 0)
			{
				return;
			}
			IReadOnlyList<PartData> symmetricParts2 = GetSymmetricParts(part.SymmetryId);
			for (int i = 0; i < symmetricParts2.Count; i++)
			{
				if (symmetricParts2[i] != part)
				{
					symmetricParts.Add(symmetricParts2[i]);
				}
			}
		}

		public PooledObject<List<PartData>> GetOtherSymmetricParts(PartData part, out List<PartData> symmetricParts)
		{
			PooledObject<List<PartData>> result = CollectionPool<List<PartData>, PartData>.Get(out symmetricParts);
			GetOtherSymmetricParts(part, symmetricParts);
			return result;
		}

		public PartData GetPartById(int partId)
		{
			if (_partDictionary.TryGetValue(partId, out var value))
			{
				return value;
			}
			if (_disabledParts.TryGetValue(partId, out var value2))
			{
				return value2;
			}
			return null;
		}

		public IReadOnlyList<PartData> GetSymmetricParts(uint symmetryId)
		{
			if (!_symmetricParts.TryGetValue(symmetryId, out var value))
			{
				return Array.Empty<PartData>();
			}
			return value;
		}

		public IReadOnlyList<PartData> GetSymmetricParts(PartData part)
		{
			return GetSymmetricParts(part.SymmetryId);
		}

		public void GetSymmetricParts(PartData part, IList<PartData> symmetricParts)
		{
			symmetricParts.AddRange(GetSymmetricParts(part));
		}

		public void LinkSymmetricParts(IList<PartData> parts, bool forceSymmetryEnabled)
		{
			if (!_availableSymmetryIds.TryPop(out var result))
			{
				result = _nextSymmetryId++;
			}
			if (_symmetricParts.TryGetValue(result, out var value))
			{
				UnityEngine.Debug.LogError($"Unable to link symmetric parts because symmetric parts already exist for symmetry id '{result}'");
				return;
			}
			value = new List<PartData>(parts.Count);
			for (int i = 0; i < parts.Count; i++)
			{
				PartData partData = parts[i];
				if (partData.SymmetryDisabled && !forceSymmetryEnabled)
				{
					UnityEngine.Debug.LogError("Unable to link symmetric parts because one or more of the parts have symmetry disabled.");
					return;
				}
				if (partData.SymmetryId != 0)
				{
					UnityEngine.Debug.LogError("Unable to link symmetric parts because one or more of the parts already have an existing symmetry id.");
					return;
				}
				value.Add(partData);
			}
			for (int j = 0; j < value.Count; j++)
			{
				value[j].SymmetryId = result;
				if (forceSymmetryEnabled)
				{
					value[j].SymmetryDisabled = false;
				}
			}
			_symmetricParts.Add(result, value);
		}

		public void RemovePart(PartData part)
		{
			if (_partDictionary.ContainsKey(part.Id))
			{
				if (part.SymmetryId != 0)
				{
					UnlinkSymmetricParts(part.SymmetryId, disableSymmetry: false);
				}
				_parts.Remove(part);
				_idProvider.Unregister(part.Id);
				_partDictionary.Remove(part.Id);
				{
					foreach (PartData part2 in _parts)
					{
						foreach (PartModifierData modifier in part2.Modifiers)
						{
							if (modifier is IPartIDChangedListener partIDChangedListener)
							{
								partIDChangedListener.OnPartRemoved(part);
							}
						}
					}
					return;
				}
			}
			UnityEngine.Debug.LogErrorFormat("Assembly does not contain part: {0} ({1})", part.Id, part.PartType.Name);
		}

		public void UnlinkAllSymmetricParts(bool disableSymmetry)
		{
			uint[] array = _symmetricParts.Keys.ToArray();
			foreach (uint symmetryId in array)
			{
				UnlinkSymmetricParts(symmetryId, disableSymmetry);
			}
		}

		public void UnlinkSymmetricParts(uint symmetryId, bool disableSymmetry)
		{
			if (!_symmetricParts.TryGetValue(symmetryId, out var value))
			{
				UnityEngine.Debug.LogError($"Unable to unlink symmetric parts because no symmetric parts exist for symmetry id '{symmetryId}'");
				return;
			}
			for (int i = 0; i < value.Count; i++)
			{
				PartData partData = value[i];
				if (partData.SymmetryId != symmetryId)
				{
					UnityEngine.Debug.LogError($"While unlinking symmetric parts, part with id '{partData.Id}' had a symmetry id of '{partData.SymmetryId}' while in a symmetric part group for symmetry id '{symmetryId}'");
				}
				else if (partData.SymmetryDisabled)
				{
					UnityEngine.Debug.LogError($"While unlinking symmetric parts, part with id '{partData.Id}' and symmetry id '{partData.SymmetryId}' was found with symmetry already disabled.");
				}
				partData.SymmetryId = 0u;
				if (disableSymmetry)
				{
					partData.SymmetryDisabled = disableSymmetry;
				}
			}
			_symmetricParts.Remove(symmetryId);
		}

		private static bool AreBodiesConnectedWithJoint(BodyScript bodyA, BodyScript bodyB)
		{
			foreach (BodyJoint joint in bodyA.Joints)
			{
				if ((joint.BodyA == bodyA || joint.BodyA == bodyB) && (joint.BodyB == bodyA || joint.BodyB == bodyB))
				{
					return true;
				}
			}
			return false;
		}

		private static PreStartInitializationPlan BuildPreStartInitializationPlan(AircraftScript craftScript, Assembly assembly)
		{
			using (Profile.CreateGameObjects.BuildInitializationPlan.Auto())
			{
				PreStartInitializationPlan preStartInitializationPlan = new PreStartInitializationPlan(craftScript);
				foreach (BodyScript body in craftScript.Bodies)
				{
					body.BuildPreStartInitializationPlan(preStartInitializationPlan);
				}
				foreach (PartData part in assembly.Parts)
				{
					part.PartScript.BuildPreStartInitializationPlan(preStartInitializationPlan);
				}
				return preStartInitializationPlan;
			}
		}

		private static PreStartInitializationPlan BuildPreStartInitializationPlan(AircraftScript craftScript, PartScript part)
		{
			using (Profile.CreateGameObjects.ExecuteInitializeDelegate.Auto())
			{
				PreStartInitializationPlan preStartInitializationPlan = new PreStartInitializationPlan(craftScript);
				part.BuildPreStartInitializationPlan(preStartInitializationPlan);
				return preStartInitializationPlan;
			}
		}

		private static ConfigurableJoint CreateJoint(BodyScript jointBody, Rigidbody connectedBody, Vector3 worldJointPosition, Vector3 worldJointAxis, bool hingeJoint, bool enableCollision, float breakTorque)
		{
			ConfigurableJoint configurableJoint = jointBody.gameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.connectedBody = connectedBody;
			configurableJoint.axis = jointBody.transform.InverseTransformDirection(worldJointAxis);
			configurableJoint.anchor = jointBody.transform.InverseTransformPoint(worldJointPosition);
			if (hingeJoint)
			{
				configurableJoint.autoConfigureConnectedAnchor = true;
				configurableJoint.xMotion = ConfigurableJointMotion.Locked;
				configurableJoint.yMotion = ConfigurableJointMotion.Locked;
				configurableJoint.zMotion = ConfigurableJointMotion.Locked;
				configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
				configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
				configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
				configurableJoint.angularXDrive = new JointDrive
				{
					maximumForce = 400000f,
					positionDamper = 10f,
					positionSpring = 400000f
				};
			}
			else
			{
				configurableJoint.autoConfigureConnectedAnchor = true;
				configurableJoint.xMotion = ConfigurableJointMotion.Free;
				configurableJoint.yMotion = ConfigurableJointMotion.Free;
				configurableJoint.zMotion = ConfigurableJointMotion.Free;
				configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
				configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
				configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
				JointDrive jointDrive = new JointDrive
				{
					maximumForce = 400000f,
					positionSpring = 400000f,
					positionDamper = 0f
				};
				configurableJoint.xDrive = jointDrive;
				configurableJoint.yDrive = jointDrive;
				configurableJoint.zDrive = jointDrive;
				configurableJoint.rotationDriveMode = RotationDriveMode.XYAndZ;
				JointDrive jointDrive2 = new JointDrive
				{
					maximumForce = 400000f,
					positionSpring = 400000f,
					positionDamper = 0f
				};
				configurableJoint.targetRotation = Quaternion.identity;
				configurableJoint.targetAngularVelocity = Vector3.zero;
				configurableJoint.angularXDrive = jointDrive2;
				configurableJoint.angularYZDrive = jointDrive2;
				configurableJoint.enableCollision = enableCollision;
				if (breakTorque > 0f)
				{
					configurableJoint.breakTorque = breakTorque;
				}
				configurableJoint.secondaryAxis = Vector3.up;
			}
			return configurableJoint;
		}

		private static List<BodyJoint> CreateJointsForRigidBodies(AircraftScript aircraftScript)
		{
			List<BodyJoint> list = new List<BodyJoint>();
			Dictionary<PartConnection, bool> dictionary = new Dictionary<PartConnection, bool>();
			foreach (BodyScript body3 in aircraftScript.Bodies)
			{
				foreach (PartData part in body3.RigidBodyGroup.Parts)
				{
					foreach (PartConnection partConnection in part.PartConnections)
					{
						if (dictionary.ContainsKey(partConnection))
						{
							continue;
						}
						dictionary[partConnection] = true;
						if (!IsPartInRigidBody(body3.RigidBodyGroup, partConnection.PartA) || !IsPartInRigidBody(body3.RigidBodyGroup, partConnection.PartB))
						{
							BodyScript body = partConnection.PartA.PartScript.Body;
							BodyScript body2 = partConnection.PartB.PartScript.Body;
							if (!AreBodiesConnectedWithJoint(body, body2) || (RequiresPhysicsJoint(partConnection) && !aircraftScript.Aircraft.LegacyJointIdentification))
							{
								BodyJoint item = CreateBodyJoint(partConnection, body, body2);
								list.Add(item);
							}
						}
					}
				}
			}
			return list;
		}

		private static Vector3 GetAttachPointPosition(Vector3 p, PartData part)
		{
			if (part.PartScale.HasValue)
			{
				return new Vector3(p.x * part.PartScale.Value.x, p.y * part.PartScale.Value.y, p.z * part.PartScale.Value.z);
			}
			return p;
		}

		private static Vector3 GetCenterOfAttachPoints(List<AttachPointData> attachPoints)
		{
			Vector3 zero = Vector3.zero;
			foreach (AttachPointData attachPoint in attachPoints)
			{
				zero += attachPoint.Position;
			}
			return zero / attachPoints.Count;
		}

		private static bool IsPartInRigidBody(RigidBodyGroup rigidBodyGroup, PartData part)
		{
			foreach (PartData part2 in rigidBodyGroup.Parts)
			{
				if (part2.Id == part.Id)
				{
					return true;
				}
			}
			return false;
		}

		private static void ReportProgress(IAircraftLoadingStatus status, int part, int total)
		{
			if (status != null)
			{
				if (_progressPart != part)
				{
					_progressPart = part;
					_progressCounter = 0;
				}
				_progressCounter++;
				float t = Mathf.Clamp01((float)_progressCounter / (float)total);
				float percentage = 0f;
				switch (part)
				{
				case 0:
					percentage = 0f;
					break;
				case 1:
					percentage = 0.01f;
					break;
				case 2:
					percentage = 0.02f;
					break;
				case 3:
					percentage = Mathf.Lerp(0.05f, 0.5f, t);
					break;
				case 4:
					percentage = Mathf.Lerp(0.5f, 0.55f, t);
					break;
				case 5:
					percentage = Mathf.Lerp(0.55f, 0.95f, t);
					break;
				case 6:
					percentage = Mathf.Lerp(0.95f, 1f, t);
					break;
				}
				status.OnLoadingProgress(percentage);
			}
		}

		private static bool RequiresPhysicsJoint(PartConnection connection)
		{
			if (connection.AttachPointsA.Count == 1 && connection.AttachPointsB.Count == 1)
			{
				if (!connection.AttachPointsA[0].RequiresPhysicsJoint)
				{
					return connection.AttachPointsB[0].RequiresPhysicsJoint;
				}
				return true;
			}
			return false;
		}

		private static void RunPreStartInitialization(PreStartInitializationPlan plan)
		{
			if (RunPreStartInitialization(plan, 0f, null).Status == UniTaskStatus.Pending)
			{
				UnityEngine.Debug.LogError("Attempted to run the pre-start initialization plan synchronously, but the task has not completed.");
			}
		}

		private static async UniTask RunPreStartInitialization(PreStartInitializationPlan plan, float maxTimePerFrame, Action<AircraftScript> checkForAbort, IAircraftLoadingStatus status = null)
		{
			bool enableDebugLogs = false;
			if (DebugInput.GetKey(KeyCode.RightAlt))
			{
				enableDebugLogs = true;
				maxTimePerFrame = 0f;
			}
			bool async = maxTimePerFrame > 0f;
			AircraftScript craftScript = plan.CraftScript;
			CraftLoadContext loadContext = plan.LoadContext;
			Stopwatch sw = ((async || enableDebugLogs) ? Stopwatch.StartNew() : null);
			List<(int Order, List<PreStartInitializationDelegate> List)> initDelegateLists;
			using (CollectionPool<List<(int, List<PreStartInitializationDelegate>)>, (int, List<PreStartInitializationDelegate>)>.Get(out initDelegateLists))
			{
				initDelegateLists.AddRange(plan.GetInitializationDelegates());
				int startFrame = 0;
				if (enableDebugLogs)
				{
					startFrame = Time.frameCount;
					UnityEngine.Debug.Log($"{Time.frameCount}: Executing pre-start initialization plan: {initDelegateLists.Count} phases, {initDelegateLists.Sum(((int Order, List<PreStartInitializationDelegate> List) x) => x.List.Count)} instances");
				}
				foreach (var initDelegateList in initDelegateLists)
				{
					List<UniTask> initTasks;
					using (CollectionPool<List<UniTask>, UniTask>.Get(out initTasks))
					{
						int phaseStartFrame = 0;
						if (enableDebugLogs)
						{
							phaseStartFrame = Time.frameCount;
							UnityEngine.Debug.Log($"{Time.frameCount}: Executing pre-start initialization plan order '{initDelegateList.Order}' ({initDelegateList.List.Count} instances)");
						}
						foreach (PreStartInitializationDelegate item2 in initDelegateList.List)
						{
							using (Profile.CreateGameObjects.ExecuteInitializeDelegate.Auto())
							{
								try
								{
									UniTask item = item2(craftScript, loadContext, async);
									initTasks.Add(item);
								}
								catch (Exception exception)
								{
									UnityEngine.Debug.LogException(exception);
								}
							}
							if (async && (float)sw.ElapsedMilliseconds > maxTimePerFrame)
							{
								await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
								checkForAbort(craftScript);
								sw.Restart();
							}
						}
						if (async)
						{
							await UniTask.WhenAll(initTasks);
						}
						else
						{
							int num = 0;
							foreach (UniTask item3 in initTasks)
							{
								if (item3.Status == UniTaskStatus.Pending)
								{
									num++;
								}
							}
							if (num > 0)
							{
								UnityEngine.Debug.LogError($"Failures occurred executing pre-start initialization plan synchronously. {num} initialization tasks are still pending");
							}
						}
						if (enableDebugLogs)
						{
							UnityEngine.Debug.Log($"{Time.frameCount}: Completed pre-start initialization plan order '{initDelegateList.Order}' ({Time.frameCount - phaseStartFrame} frames)");
						}
						ReportProgress(status, 6, initDelegateLists.Count);
					}
					initTasks = null;
				}
				if (enableDebugLogs)
				{
					UnityEngine.Debug.Log($"{Time.frameCount}: Completed pre-start initialization plan: " + $"{initDelegateLists.Count} phases, " + $"{initDelegateLists.Sum(((int Order, List<PreStartInitializationDelegate> List) x) => x.List.Count)} instances " + $"({Time.frameCount - startFrame} frames{(async ? string.Empty : $", {(double)sw.Elapsed.Ticks / (double)Stopwatch.Frequency * 1000.0:F2}ms")})");
				}
			}
		}

		private void AddPartToLookup(PartData part)
		{
			if (!_partDictionary.ContainsKey(part.Id))
			{
				_partDictionary[part.Id] = part;
				return;
			}
			throw new Exception($"Assembly already contains part with ID of {part.Id}");
		}

		private XElement GenerateBodiesXml()
		{
			XElement xElement = new XElement("Bodies");
			List<PartData> list = _parts.ToList();
			List<IList<PartData>> list2 = new List<IList<PartData>>();
			while (list.Count > 0)
			{
				List<PartData> parts = new PartGraph(list[0], breakOnRigidBodyBoundary: true).Parts;
				list2.Add(parts);
				foreach (PartData item in parts)
				{
					list.Remove(item);
				}
			}
			foreach (IList<PartData> item2 in list2)
			{
				string text = string.Empty;
				foreach (PartData item3 in item2)
				{
					text = text + item3.Id + ",";
				}
				text = text.TrimEnd(',');
				xElement.Add(new XElement("Body", new XAttribute("partIds", text), new XAttribute("position", Vector3.zero.ToXAttributeValue()), new XAttribute("rotation", Vector3.zero.ToXAttributeValue()), new XAttribute("velocity", Vector3.zero.ToXAttributeValue()), new XAttribute("angularVelocity", Vector3.zero.ToXAttributeValue())));
			}
			return xElement;
		}

		private void InitializePartSymmetry(XElement assemblyXml, int craftXmlVersion)
		{
			for (int i = 0; i < _parts.Count; i++)
			{
				PartData partData = _parts[i];
				if (partData.SymmetryId != 0)
				{
					if (partData.SymmetryDisabled)
					{
						UnityEngine.Debug.LogError($"Part with id '{partData.Id}' has a symmetry id of '{partData.SymmetryId}' but the part has symmetry disabled");
					}
					if (!_symmetricParts.TryGetValue(partData.SymmetryId, out var value))
					{
						_symmetricParts.Add(partData.SymmetryId, value = new List<PartData>());
					}
					value.Add(partData);
				}
			}
			List<uint> value2;
			using (CollectionPool<List<uint>, uint>.Get(out value2))
			{
				List<uint> value3;
				using (CollectionPool<List<uint>, uint>.Get(out value3))
				{
					foreach (KeyValuePair<uint, List<PartData>> symmetricPart in _symmetricParts)
					{
						if (symmetricPart.Value.Count == 1)
						{
							UnityEngine.Debug.LogError($"Part with id '{symmetricPart.Value[0].Id}' was in symmetric group '{symmetricPart.Key}' by itself. This symmetry group will be removed.");
							symmetricPart.Value[0].SymmetryId = 0u;
							value3.Add(symmetricPart.Key);
						}
						else
						{
							value2.Add(symmetricPart.Key);
						}
					}
					for (int j = 0; j < value3.Count; j++)
					{
						_symmetricParts.Remove(value3[j]);
					}
					uint num = 1u;
					value2.Sort();
					for (int k = 0; k < value2.Count; k++)
					{
						uint num2 = value2[k];
						while (num < num2)
						{
							_availableSymmetryIds.Push(num++);
						}
						num++;
					}
					_nextSymmetryId = num;
					if (craftXmlVersion > 20 || _symmetricParts.Count != 0)
					{
						return;
					}
					foreach (PartData part in _parts)
					{
						part.SymmetryDisabled = true;
					}
				}
			}
		}
	}
}
