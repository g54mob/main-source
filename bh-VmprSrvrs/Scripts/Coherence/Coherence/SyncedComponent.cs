using System.Collections.Generic;

namespace Coherence
{
	public class SyncedComponent
	{
		public string ComponentName;

		public bool NeedCachedProperty;

		public string Property;

		public string PropertyType;

		public string UnityComponentType;

		public bool OverrideSetter;

		public bool OverrideGetter;

		public int FieldMasks;

		public List<ComponentMember> MembersInfo;

		public string BakeConditional;

		public string FieldMasksString => null;

		public SyncedComponent(string name, bool needsInitializer, string property, string propertyType, string unityComponentType, bool overrideSetter, bool overrideGetter, List<ComponentMember> membersInfo, string bakeConditional)
		{
		}
	}
}
