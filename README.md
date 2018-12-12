# CS425 Final Project Report

## Gameplay

The game is a chasing game. The main character is running away from a monster that is chasing him. The goal of the game
is to collect materials, create an arrow with those materials, and kill the monster behind you. If the character runs
into too many obstacles without dodging or breaking them, the game ends in a loss. 

You can see the character's life count at the top left of the screen and you can see the needed materials at the top
right of the screen. Whenever you gather the correct materials, you'll get one chance at shooting the monster with an arrow.
If you miss with that arrow, you must gather the required materials again for another chance. Every time you gather the correct
material, a green chackmark appears over that material in the UI. The character is no able to shoot until he has the right
materials gathered. 

- Controls:

	The left and right arrow keys are used to move left and right.
	The top arrow key is used to break the materials in front of you.
	The bottom arrow key is used to shoot the monster behind you 
	(this is only possible if you have all the materials)
	Press R to restart the game

## Technical Part

The engine used for this project is Unity. The only things I imported had to deal with the characters sprites. I got
most of them from the unity asset store for free, and drew the rest myself. 

The technical components in this game are content generation and AI.

- Content generation:

	The content generation happens in spawning the obstacles that come down the screen. The randomness determines
	how many obstacles spawn at a time (1 or 2 since there has to be at least one open slot left) and which obstacles
	spawn (it can be either a bush, sign, tree trunk, or rock). The variety in the materials that spawn add on to 
	the collection aspect of the game.

- AI:

	The monster has behavior programmed in that allows him to dodge the obstacles by himself. He has a sensor
	that determines when the obstacles are coming and logic that lets him decide to go to a random
	available spot. This logic is implemented to make it harder to kill the monster when the character has
	an arrow ready. Since the monster will be dodging to a random open spot, it is harder to hit, which
	would have been easier if the monster was just following the character's movement exactly.