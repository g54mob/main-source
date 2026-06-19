namespace Battlehub.RTHandles
{
	public static class RuntimeTools
	{
		private static RuntimeTool m_current;

		private static RuntimePivotRotation m_pivotRotation;

		public static bool IsLocked { get; set; }

		public static bool IsDragDrop { get; set; }

		public static bool IsSceneGizmoSelected { get; set; }

		public static RuntimeTool Current
		{
			get
			{
				return m_current;
			}
			set
			{
				if (m_current != value)
				{
					m_current = value;
					if (RuntimeTools.ToolChanged != null)
					{
						RuntimeTools.ToolChanged();
					}
				}
			}
		}

		public static RuntimePivotRotation PivotRotation
		{
			get
			{
				return m_pivotRotation;
			}
			set
			{
				if (m_pivotRotation != value)
				{
					m_pivotRotation = value;
					if (RuntimeTools.PivotRotationChanged != null)
					{
						RuntimeTools.PivotRotationChanged();
					}
				}
			}
		}

		public static event RuntimeToolChanged ToolChanged;

		public static event RuntimePivotRotationChanged PivotRotationChanged;
	}
}
