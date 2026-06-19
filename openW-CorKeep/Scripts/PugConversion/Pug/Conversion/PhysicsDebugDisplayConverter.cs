using Unity.Physics.Authoring;

namespace Pug.Conversion
{
	public class PhysicsDebugDisplayConverter : SingleAuthoringComponentConverter<PhysicsDebugDisplayAuthoring>
	{
		protected override void Convert(PhysicsDebugDisplayAuthoring authoring)
		{
			AddComponentData(new PhysicsDebugDisplayData
			{
				DrawBroadphase = (authoring.DrawBroadphase ? 1 : 0),
				DrawColliders = (authoring.DrawColliders ? 1 : 0),
				DrawContacts = (authoring.DrawContacts ? 1 : 0),
				DrawJoints = (authoring.DrawJoints ? 1 : 0),
				DrawColliderAabbs = (authoring.DrawColliderAabbs ? 1 : 0),
				DrawColliderEdges = (authoring.DrawColliderEdges ? 1 : 0),
				DrawCollisionEvents = (authoring.DrawCollisionEvents ? 1 : 0),
				DrawMassProperties = (authoring.DrawMassProperties ? 1 : 0),
				DrawTriggerEvents = (authoring.DrawTriggerEvents ? 1 : 0)
			});
		}
	}
}
