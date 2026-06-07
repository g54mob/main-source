using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Exit Zone")]
[TypeIcon(typeof(BoxCollider))]
[UnitSubtitle("Player exits a zone of trigger collider(s)")]
[UnitCategory("Movement")]
public class ExitZoneUnit : EnterZoneUnit
{
	protected override string DoneFieldName => "Exited";

	protected override bool WantedState => false;
}
