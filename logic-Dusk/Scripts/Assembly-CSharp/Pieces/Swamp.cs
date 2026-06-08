namespace Pieces
{
	public class Swamp : Piece
	{
		public override float PieceHeight
		{
			get
			{
				return 0.14f;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			rotatesToCamera = false;
			isSpellPiece = true;
		}
	}
}
