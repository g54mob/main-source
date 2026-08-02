using UnityEngine;

namespace HQFPSTemplate.Surfaces
{
	public class SurfaceIdentity : MonoBehaviour
	{
		[SerializeField]
		private SurfaceInfo m_Surface;

		public SurfaceInfo Surface
		{
			get
			{
				return m_Surface;
			}
			set
			{
				m_Surface = value;
			}
		}
	}
}
