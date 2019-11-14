using Laboratorio_8_OOP_201920.Cards;
using Laboratorio_8_OOP_201920.Enums;
using System.Collections.Generic;

namespace Laboratorio_8_OOP_201920
{
    public static class Effect
    {
        private static Dictionary<EnumEffect, string> effectDescriptions = new Dictionary<EnumEffect, string>()
        {
            { EnumEffect.bitingFrost, "Sets the strength of all melee cards to 1 for both players" },
            { EnumEffect.impenetrableFog, "Sets the strength of all range cards to 1 for both players" },
            { EnumEffect.torrentialRain, "Sets the strength of all longRange cards to 1 for both players" },
            { EnumEffect.clearWeather, "Removes all Weather Card (Biting Frost, Impenetrable Fog and Torrential Rain) effects" },
            { EnumEffect.moraleBoost, "Adds +1 to all units in the row (excluding itself)" },
            { EnumEffect.spy, "Place on your opponent's battlefield (counts towards opponent's total) and draw 2 cards from your deck" },
            { EnumEffect.tightBond, "Place next to a card with the same name to double the strength of both cards" },
            { EnumEffect.buff, "Doubles the strength of all unit cards in that row. Limited to 1 per row" },
            { EnumEffect.none, "None" },
        };

        public static string GetEffectDescription(EnumEffect e)
        {
            return effectDescriptions[e];
        }

        public static void ApplyEffect(Card playedCard, Player activePlayer, Player opponent, Board board)
        {
            //Recomendación: Utilice switch(playedCard.CardEffect) para definir los distintos efectos.
            switch (playedCard.CardEffect)
            {
                case EnumEffect.bitingFrost:
                    for (int i = 0; i < 2; i++)
                    {
                        if (board.PlayerCards[i].ContainsKey(EnumType.melee))
                        {
                            foreach (CombatCard card in board.PlayerCards[i][EnumType.melee])
                            {
                                card.AttackPoints = 1;
                            }
                        }
                    }
                    break;

                case EnumEffect.impenetrableFog:
                    for (int i = 0; i < 2; i++)
                    {
                        if (board.PlayerCards[i].ContainsKey(EnumType.range))
                        {
                            foreach (CombatCard card in board.PlayerCards[i][EnumType.range])
                            {
                                card.AttackPoints = 1;
                            }
                        }
                    }
                    break;

                case EnumEffect.torrentialRain:
                    for (int i = 0; i < 2; i++)
                    {
                        if (board.PlayerCards[i].ContainsKey(EnumType.longRange))
                        {
                            foreach (CombatCard card in board.PlayerCards[i][EnumType.longRange])
                            {
                                card.AttackPoints = 1;
                            }
                        }
                    }
                    break;

                case EnumEffect.clearWeather:
                    board.WeatherCards = new List<SpecialCard>();
                    break;

                case EnumEffect.none:
                    break;

            }
        }
    }
}
