using System.Collections.Generic;
using SQLite;
using Synty.SidekickCharacters.Enums;
using UnityEngine;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_blend_shape_rig_movement")]
	public class SidekickBlendShapeRigMovement
	{
		public static readonly Dictionary<CharacterPartType, string> PART_TYPE_JOINT_MAP;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("part_type")]
		public CharacterPartType PartType { get; set; }

		[Column("blend_type")]
		public BlendShapeType BlendType { get; set; }

		[Column("max_offset_x")]
		public float MaxOffsetX { get; set; }

		[Column("max_offset_y")]
		public float MaxOffsetY { get; set; }

		[Column("max_offset_z")]
		public float MaxOffsetZ { get; set; }

		[Column("max_rotation_x")]
		public float MaxRotationX { get; set; }

		[Column("max_rotation_y")]
		public float MaxRotationY { get; set; }

		[Column("max_rotation_z")]
		public float MaxRotationZ { get; set; }

		[Column("max_scale_x")]
		public float MaxScaleX { get; set; }

		[Column("max_scale_y")]
		public float MaxScaleY { get; set; }

		[Column("max_scale_z")]
		public float MaxScaleZ { get; set; }

		[Ignore]
		public Vector3 MaxOffset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[Ignore]
		public Quaternion MaxRotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		[Ignore]
		public Vector3 MaxScale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public SidekickBlendShapeRigMovement()
		{
		}

		private SidekickBlendShapeRigMovement(CharacterPartType partType, BlendShapeType blendType)
		{
		}

		public static List<SidekickBlendShapeRigMovement> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static Dictionary<CharacterPartType, Dictionary<BlendShapeType, SidekickBlendShapeRigMovement>> GetAllForProcessing(DatabaseManager dbManager)
		{
			return null;
		}

		public static SidekickBlendShapeRigMovement GetByPartTypeAndBlendType(DatabaseManager dbManager, CharacterPartType partType, BlendShapeType blendType)
		{
			return null;
		}

		public Vector3 GetBlendedOffsetValue(float blendValue)
		{
			return default(Vector3);
		}

		public Quaternion GetBlendedRotationValue(float blendValue)
		{
			return default(Quaternion);
		}

		public Vector3 GetBlendedScaleValue(float blendValue)
		{
			return default(Vector3);
		}

		public int Save(DatabaseManager dbManager)
		{
			return 0;
		}

		public void Delete(DatabaseManager dbManager)
		{
		}
	}
}
