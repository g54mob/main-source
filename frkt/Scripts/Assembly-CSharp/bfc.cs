using Infrastructure.Project.Installers.AssetsHandlers.SFX;
using UnityEngine;

public interface bfc
{
	void ipf(WhooshSFXType a, float? b = null, float? c = null, float d = 0f, float e = 1f, float f = 500f, bool g = true, Vector3 h = default(Vector3), Quaternion i = default(Quaternion), Transform j = null, bool k = true);

	void ipg(ImpactSFXType a, float? b = null, float? c = null, float d = 0f, float e = 1f, float f = 500f, bool g = true, Vector3 h = default(Vector3), Quaternion i = default(Quaternion), Transform j = null, bool k = true);

	void iph(WeaponSFXType a, float? b = null, float? c = null, float d = 0f, float e = 1f, float f = 500f, bool g = true, Vector3 h = default(Vector3), Quaternion i = default(Quaternion), Transform j = null, bool k = true);

	void ipi(ToolsSFXType a, float? b = null, float? c = null, float d = 0f, float e = 1f, float f = 500f, bool g = true, Vector3 h = default(Vector3), Quaternion i = default(Quaternion), Transform j = null, bool k = true);
}
