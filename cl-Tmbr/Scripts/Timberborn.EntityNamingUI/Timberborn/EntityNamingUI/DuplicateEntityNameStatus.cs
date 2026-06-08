using System;
using Timberborn.BaseComponentSystem;
using Timberborn.EntityNaming;
using Timberborn.Localization;
using Timberborn.StatusSystem;

namespace Timberborn.EntityNamingUI
{
	internal class DuplicateEntityNameStatus : BaseComponent, IAwakableComponent, IStartableComponent
	{
		private static readonly string DuplicateNameLocKey = "Status.Naming.DuplicateName";

		private static readonly string DuplicateNameShortLocKey = "Status.Naming.DuplicateName.Short";

		private readonly ILoc _loc;

		private UniquelyNamedEntity _uniquelyNamedEntity;

		private StatusToggle _statusToggle;

		public DuplicateEntityNameStatus(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			_uniquelyNamedEntity = GetComponent<UniquelyNamedEntity>();
			_statusToggle = StatusToggle.CreatePriorityStatusWithAlertAndFloatingIcon("GenericError", _loc.T(DuplicateNameLocKey), _loc.T(DuplicateNameShortLocKey));
		}

		public void Start()
		{
			UpdateStatus();
			_uniquelyNamedEntity.IsUniqueChanged += OnIsUniqueChanged;
			GetComponent<StatusSubject>().RegisterStatus(_statusToggle);
		}

		private void OnIsUniqueChanged(object sender, EventArgs e)
		{
			UpdateStatus();
		}

		private void UpdateStatus()
		{
			_statusToggle.Toggle(!_uniquelyNamedEntity.IsUnique);
		}
	}
}
