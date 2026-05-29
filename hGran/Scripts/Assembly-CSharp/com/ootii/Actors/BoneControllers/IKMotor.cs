using com.ootii.Base;

namespace com.ootii.Actors.BoneControllers
{
	public abstract class IKMotor : BaseObject
	{
		public bool _IsEnabled;

		public bool _IsEditorEnabled;

		public bool _IsDebugEnabled;

		public bool _IsFixedUpdateEnabled;

		public float _FixedUpdateFPS;

		public float _Weight;

		public float _BoneWeight;

		public virtual bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsEditorEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsDebugEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsFixedUpdateEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual float FixedUpdateFPS
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float Weight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float BoneWeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public IKMotor()
		{
		}
	}
}
