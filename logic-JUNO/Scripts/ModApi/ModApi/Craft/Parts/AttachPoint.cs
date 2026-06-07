using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Settings.Core;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	[Serializable]
	public class AttachPoint
	{
		public delegate void AttachPointDelegate(AttachPoint attachPoint);

		[SerializeField]
		[Tooltip("A value indicating whether this attach point can connect to another attach point with its normal pointing in the wrong direction. This requieres that the attach point also supports AllowRotation.")]
		private bool _allowInvertedConnection;

		[SerializeField]
		[Tooltip("A value indicating whether the attach point allows rotation.")]
		private bool _allowRotation;

		[SerializeField]
		[Tooltip("A value indicating whether this attach point can receive attachments. This will usually be true. An example of an attach point which would be false is the auto-rotating fuselage attach point. That attach point is used to attach the fuselage to other pieces, but we don't want pieces attaching themselves to that point...other pieces attach to the fuselage via its surface attach point.")]
		private bool _canReceive;

		[SerializeField]
		[Tooltip("A value indicating whether this attach point can cast rays looking for connections when its part is being moved in the designer. This is usually true, but for surface attach points and in some special cases this can be false.")]
		private bool _canSeek;

		[SerializeField]
		[Tooltip("The attach point's connection type, which determines what attach points this attach point can connect to.")]
		private AttachPointConnectionType _connectionType;

		[SerializeField]
		[Tooltip("Whether crew can move through this attach point.")]
		private bool _crewTraversable;

		[SerializeField]
		[Tooltip("A value indicating whether to disable collisions for a physics joint created at this attach point. This only applies if the attach point is not a Fused type. If this flag is different between the two attach points making up a joint, then the physics joint will be created with collisions disabled.")]
		private bool _disableJointCollisions;

		[SerializeField]
		[Tooltip("The attach point's display name.")]
		private string _displayName;

		private bool _enabled = true;

		[SerializeField]
		[Tooltip("A value indicating whether this attach point can carry fuel. Used when automatically identifying fuel tanks connected to a fuel source modifier.")]
		private bool _fuelLine;

		private bool _hasUpVectorOverride;

		[SerializeField]
		[Tooltip("A value indicating whether this attach point is hidden.")]
		private bool _hidden;

		[SerializeField]
		[Tooltip("A value indicating whether to ignore connections with surface attach points.")]
		private bool _ignoreSurfaces;

		[SerializeField]
		[Tooltip("The type of the joint created by this attach point.")]
		private JointType _jointType;

		[SerializeField]
		[Tooltip("The local joint axis.")]
		private Vector3 _localJointAxis;

		[SerializeField]
		[Tooltip("The position.")]
		private Vector3 _position;

		[SerializeField]
		[Tooltip("The radius, which is used by adaptive fuselage meshes to automatically adapt to the radius of the attach point. If the radius is zero, then the fuselage meshes will not attempt to auto-adapt to this attach point.")]
		private float _radius;

		[SerializeField]
		[Tooltip("A value indicating whether to cast the ray from the cursor instead of from the attach point. Some parts that auto-rotate are easier to use if the ray cast is from the cursor, such as the fuel tank.")]
		private bool _rayCastFromCursor;

		[SerializeField]
		[Tooltip("The render queue that connected parts should be placed in when connecting to this attach point.")]
		private PartMeshRenderQueue _renderQueue;

		[SerializeField]
		[Tooltip("A value indicating whether this attach point requires the physics joint to be on the rigid body containing this part.")]
		private bool _requiresPhysicsJoint;

		[SerializeField]
		[Tooltip("The rotation.")]
		private Vector3 _rotation;

		[SerializeField]
		[Tooltip("The scale.")]
		private float _scale = 1f;

		[SerializeField]
		[Tooltip("The surface collider, if one is used for this attach point. This field overrides the 'Surface Collider Name' field if set.")]
		private Collider _surfaceCollider;

		[SerializeField]
		[Tooltip("The surface collider name, if one is used for this attach point. This property is unused if the 'Surface Collider' field is set.")]
		private string _surfaceColliderName;

		[SerializeField]
		[Tooltip("The attach point's tag.")]
		private string _tag;

		[SerializeField]
		[Tooltip("The up vector to use when attaching.")]
		private Vector3 _upVectorOverride = Vector3.zero;

		public bool AllowInvertedConnection
		{
			get
			{
				return _allowInvertedConnection;
			}
			private set
			{
				_allowInvertedConnection = value;
			}
		}

		public bool AllowRotation
		{
			get
			{
				return _allowRotation;
			}
			set
			{
				_allowRotation = value;
			}
		}

		public bool AllowSymmetry => IsSurfaceAttachPoint;

		public AttachPointScript AttachPointScript { get; set; }

		public bool CanReceive
		{
			get
			{
				return _canReceive;
			}
			private set
			{
				_canReceive = value;
			}
		}

		public bool CanSeek
		{
			get
			{
				return _canSeek;
			}
			private set
			{
				_canSeek = value;
			}
		}

		public AttachPointConnectionType ConnectionType
		{
			get
			{
				return _connectionType;
			}
			private set
			{
				_connectionType = value;
			}
		}

		public bool CrewTraversable
		{
			get
			{
				return _crewTraversable;
			}
			private set
			{
				_crewTraversable = value;
			}
		}

		public bool DisableJointCollisions
		{
			get
			{
				return _disableJointCollisions;
			}
			private set
			{
				_disableJointCollisions = value;
			}
		}

		public string DisplayName { get; private set; }

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				if (_enabled != value)
				{
					_enabled = value;
					this.EnabledChanged?.Invoke(this);
				}
			}
		}

		public bool FuelLine
		{
			get
			{
				return _fuelLine;
			}
			private set
			{
				_fuelLine = value;
			}
		}

		public bool Hidden
		{
			get
			{
				return _hidden;
			}
			private set
			{
				_hidden = value;
			}
		}

		public int Id { get; private set; }

		public bool IgnoreSurfaces
		{
			get
			{
				BoolSetting boolSetting = Game.Instance.Settings?.Game.Designer.EnableSurfaceAttachments;
				if (boolSetting == null || (bool)boolSetting)
				{
					return _ignoreSurfaces;
				}
				return true;
			}
			set
			{
				_ignoreSurfaces = value;
			}
		}

		public bool IsAvailable
		{
			get
			{
				if (IsAvailableForManualConnection)
				{
					return Enabled;
				}
				return false;
			}
		}

		public bool IsAvailableForManualConnection
		{
			get
			{
				if (NumPartConnections != 0)
				{
					return IsSurfaceAttachPoint;
				}
				return true;
			}
		}

		public bool IsCustomized { get; set; }

		public bool IsSurfaceAttachPoint => !string.IsNullOrEmpty(Surface);

		public Vector3? JointPosition { get; private set; }

		public JointType JointType
		{
			get
			{
				return _jointType;
			}
			set
			{
				_jointType = value;
			}
		}

		public Vector3 LocalJointAxis
		{
			get
			{
				return _localJointAxis;
			}
			private set
			{
				_localJointAxis = value;
			}
		}

		public int MirrorId { get; set; }

		public string Name { get; private set; }

		public int NumPartConnections => PartConnections.Count;

		public List<PartConnection> PartConnections { get; private set; }

		public Vector3 Position
		{
			get
			{
				return _position + PositionOffset;
			}
			set
			{
				_position = value;
			}
		}

		public Vector3 PositionOffset { get; set; }

		public float Radius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = value;
			}
		}

		public bool RayCastFromCursor
		{
			get
			{
				return _rayCastFromCursor;
			}
			private set
			{
				_rayCastFromCursor = value;
			}
		}

		public PartMeshRenderQueue RenderQueue
		{
			get
			{
				return _renderQueue;
			}
			private set
			{
				_renderQueue = value;
			}
		}

		public bool RequiresPhysicsJoint
		{
			get
			{
				return _requiresPhysicsJoint;
			}
			private set
			{
				_requiresPhysicsJoint = value;
			}
		}

		public Vector3 Rotation
		{
			get
			{
				return _rotation + RotationOffset;
			}
			set
			{
				_rotation = value;
			}
		}

		public Vector3 RotationOffset { get; set; }

		public float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
				if (AttachPointScript?.transform != null)
				{
					AttachPointScript.transform.localScale = Vector3.one * _scale;
				}
			}
		}

		public string Surface
		{
			get
			{
				return _surfaceColliderName;
			}
			set
			{
				_surfaceColliderName = value;
			}
		}

		public string Tag
		{
			get
			{
				return _tag;
			}
			private set
			{
				_tag = value;
			}
		}

		public Vector3? UpVectorOverride
		{
			get
			{
				if (_hasUpVectorOverride)
				{
					return _upVectorOverride;
				}
				return null;
			}
		}

		public event AttachPointDelegate EnabledChanged;

		public AttachPoint(int id, XElement element)
		{
			PartConnections = new List<PartConnection>();
			Id = id;
			Name = Utilities.GetStringAttribute(element, "name", null);
			DisplayName = Utilities.GetStringAttribute(element, "displayName", null);
			if (string.IsNullOrEmpty(DisplayName))
			{
				DisplayName = Name.Replace("AttachPoint", string.Empty);
			}
			Tag = Utilities.GetStringAttribute(element, "tag", null);
			Position = Utilities.GetVectorAttribute(element, "position", Vector3.zero);
			PositionOffset = Utilities.GetVectorAttribute(element, "positionOffset", Vector3.zero);
			if (element.Attribute("jointPosition") != null)
			{
				JointPosition = Utilities.GetVectorAttribute(element, "jointPosition", Vector3.zero);
			}
			else
			{
				JointPosition = null;
			}
			Rotation = Utilities.GetVectorAttribute(element, "rotation", Vector3.zero);
			RotationOffset = Utilities.GetVectorAttribute(element, "rotationOffset", Vector3.zero);
			AllowRotation = Utilities.GetBoolAttribute(element, "allowRotation", defaultValue: false);
			AllowInvertedConnection = Utilities.GetBoolAttribute(element, "allowInvertedConnection", defaultValue: false);
			_upVectorOverride = element.GetVector3Attribute("upOverride", Vector3.zero);
			_hasUpVectorOverride = _upVectorOverride.sqrMagnitude > 0f;
			CanReceive = Utilities.GetBoolAttribute(element, "canReceive", defaultValue: true);
			CanSeek = Utilities.GetBoolAttribute(element, "canSeek", defaultValue: true);
			Surface = Utilities.GetStringAttribute(element, "surface", string.Empty);
			IgnoreSurfaces = Utilities.GetBoolAttribute(element, "ignoreSurfaces", defaultValue: false);
			FuelLine = Utilities.GetBoolAttribute(element, "fuelLine", defaultValue: false);
			Radius = Utilities.GetFloatAttribute(element, "radius", 0f);
			RayCastFromCursor = Utilities.GetBoolAttribute(element, "rayCastFromCursor", defaultValue: false);
			JointType = Utilities.GetEnumAttribute(element, "jointType", JointType.Fused);
			RenderQueue = Utilities.GetEnumAttribute(element, "renderQueue", PartMeshRenderQueue.Default);
			LocalJointAxis = Utilities.GetVectorAttribute(element, "localJointAxis", Vector3.forward);
			RequiresPhysicsJoint = Utilities.GetBoolAttribute(element, "requiresPhysicsJoint", defaultValue: false);
			DisableJointCollisions = Utilities.GetBoolAttribute(element, "disableJointCollisions", defaultValue: false);
			ConnectionType = Utilities.GetEnumAttribute(element, "connectionType", AttachPointConnectionType.Normal);
			CrewTraversable = Utilities.GetBoolAttribute(element, "crewTraversable", defaultValue: false);
			Hidden = Utilities.GetBoolAttribute(element, "hidden", defaultValue: false);
		}

		private AttachPoint()
		{
			_canReceive = true;
			_canSeek = true;
			_connectionType = AttachPointConnectionType.Normal;
			_crewTraversable = false;
			_jointType = JointType.Fused;
			_renderQueue = PartMeshRenderQueue.Default;
			_localJointAxis = Vector3.forward;
		}

		public XElement GenerateXml(GameObject attachPointGameObject, GameObject prefab)
		{
			XElement xElement = new XElement("AttachPoint");
			xElement.Add(new XAttribute("name", attachPointGameObject.name));
			if (!string.IsNullOrEmpty(_tag))
			{
				xElement.Add(new XAttribute("tag", _tag));
			}
			if (!string.IsNullOrEmpty(_displayName))
			{
				xElement.Add(new XAttribute("displayName", _displayName));
			}
			string text = _surfaceColliderName;
			if (_surfaceCollider != null)
			{
				text = _surfaceCollider.gameObject.name;
				if (prefab != null && Utilities.FindObjectsMyselfOrChildren<Transform>(text, prefab).Count != 1)
				{
					Debug.LogError("Attach point is set to surface collider but the name is not unique");
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				xElement.Add(new XAttribute("surface", text));
				xElement.Add(new XAttribute("canSeek", _canSeek));
			}
			else
			{
				xElement.Add(new XAttribute("position", Utilities.Vector3ToString(attachPointGameObject.transform.localPosition)));
				xElement.Add(new XAttribute("rotation", Utilities.Vector3ToString(attachPointGameObject.transform.localRotation.eulerAngles)));
				xElement.Add(new XAttribute("positionOffset", Utilities.Vector3ToString(PositionOffset)));
				xElement.Add(new XAttribute("rotationOffset", Utilities.Vector3ToString(RotationOffset)));
				xElement.Add(new XAttribute("allowRotation", _allowRotation));
				xElement.Add(new XAttribute("allowInvertedConnection", _allowInvertedConnection));
				xElement.Add(new XAttribute("canReceive", _canReceive));
				xElement.Add(new XAttribute("canSeek", _canSeek));
				xElement.Add(new XAttribute("ignoreSurfaces", _ignoreSurfaces));
				if (_jointType != JointType.Fused)
				{
					xElement.Add(new XAttribute("jointType", _jointType));
				}
				if (!Utilities.CompareVector3s(_localJointAxis, Vector3.forward))
				{
					xElement.Add(new XAttribute("localJointAxis", Utilities.Vector3ToString(_localJointAxis)));
				}
				if (_radius > 0f)
				{
					xElement.Add(new XAttribute("radius", _radius));
				}
			}
			if (_connectionType != AttachPointConnectionType.Normal)
			{
				xElement.Add(new XAttribute("connectionType", _connectionType));
			}
			if (_crewTraversable)
			{
				xElement.Add(new XAttribute("crewTraversable", _crewTraversable));
			}
			if (_fuelLine)
			{
				xElement.Add(new XAttribute("fuelLine", _fuelLine));
			}
			if (_disableJointCollisions)
			{
				xElement.Add(new XAttribute("disableJointCollisions", _disableJointCollisions));
			}
			if (_rayCastFromCursor)
			{
				xElement.Add(new XAttribute("rayCastFromCursor", _rayCastFromCursor));
			}
			if (_requiresPhysicsJoint)
			{
				xElement.Add(new XAttribute("requiresPhysicsJoint", _requiresPhysicsJoint));
			}
			if (_renderQueue != PartMeshRenderQueue.Default)
			{
				xElement.Add(new XAttribute("renderQueue", _renderQueue));
			}
			if (_hidden)
			{
				xElement.Add(new XAttribute("hidden", _hidden));
			}
			if (_upVectorOverride.sqrMagnitude > 0f)
			{
				xElement.Add(new XAttribute("upOverride", Utilities.Vector3ToString(_upVectorOverride)));
			}
			return xElement;
		}

		public void RemoveConnection(PartConnection partConnection)
		{
			PartConnections.Remove(partConnection);
		}

		public void RestoreCustomizedSettings(XElement xml)
		{
			IsCustomized = true;
			_position = xml.GetVector3Attribute("position", _position);
			_rotation = xml.GetVector3Attribute("rotation", _rotation);
			_scale = xml.GetFloatAttribute("scale", _scale);
			PositionOffset = xml.GetVector3Attribute("positionOffset", PositionOffset);
			RotationOffset = xml.GetVector3Attribute("rotationOffset", RotationOffset);
			_enabled = xml.GetBoolAttribute("enabled", _enabled);
			_ignoreSurfaces = xml.GetBoolAttribute("ignoreSurfaces", _ignoreSurfaces);
			_allowRotation = xml.GetBoolAttribute("allowRotation", _allowRotation);
			_jointType = xml.GetEnumAttribute("jointType", _jointType);
			_connectionType = xml.GetEnumAttribute("connectionType", _connectionType);
			_crewTraversable = xml.GetBoolAttribute("crewTraversable", _crewTraversable);
		}

		public void SaveCustomizedSettings(XElement xml)
		{
			xml.SetAttributeValue("id", Id);
			xml.SetAttribute("position", _position);
			xml.SetAttribute("rotation", _rotation);
			xml.SetAttributeValue("scale", _scale);
			xml.SetAttribute("positionOffset", PositionOffset);
			xml.SetAttribute("rotationOffset", RotationOffset);
			xml.SetAttributeValue("enabled", _enabled);
			xml.SetAttributeValue("ignoreSurfaces", _ignoreSurfaces);
			xml.SetAttributeValue("allowRotation", _allowRotation);
			xml.SetAttributeValue("jointType", _jointType);
			xml.SetAttributeValue("connectionType", _connectionType);
			xml.SetAttributeValue("crewTraversable", _crewTraversable);
		}
	}
}
