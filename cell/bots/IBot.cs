﻿namespace Cell.Bots
{
	public interface IBot
	{
		void Do(Board board);
		void SetPlayer(Player player);
		Player GetPlayer();
	}
}
