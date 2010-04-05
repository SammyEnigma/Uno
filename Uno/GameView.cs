﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Uno
{
    partial class GameView : Form
    {

        private Game _game;
        private Hashtable _cardsViews = new Hashtable(108);




        public GameView(Game game)
        {
            InitializeComponent();

            _game = game;


            // Create picture boxes for each card, and store them in a hash table
            foreach (Card c in _game.Deck)
            {
                _cardsViews.Add(c, _createPictureBoxForCard(c));
            }
        }


        public void ReDraw()
        {
            // Remove cards that are just in the deck
            foreach(Card c in _game.Deck)
            {
                this.Controls.Remove(_cardsViews[c] as PictureBox);
            }

            int i = 0;

            foreach (Game.GamePlayer p in _game.PlayersCards.Values)
            {

                int k = 0;

                foreach (Card c in p.Cards)
                {
                    PictureBox pictureBox = _cardsViews[c] as PictureBox;

                    pictureBox.Left = k * 60 + 260;
                    pictureBox.Top = i * 137 + 80;

                    this.Controls.Add(pictureBox);
                    
                    k++;
                }

                i++;
            }
        }


        private PictureBox _createPictureBoxForCard(Card card)
        {
            PictureBox pictureBox = new PictureBox();

            pictureBox.Image = card.Image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.Transparent;

            pictureBox.Height = 80;
            pictureBox.Width = 50;
            
            return pictureBox;
        }
    }
}
