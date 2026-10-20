# 3DGameUnityA2

# How to play
Open the MainMenu scene first then press Play. Collect 100 points to win by picking up the coins and killing enemies.
coins: 5 points
Red Enemy: 5 points
Blue Enemy: 10 points
Green Enemy: 20 points

# Controls
| Input | Action |
|---|---|
| <kbd>W</kbd> <kbd>A</kbd> <kbd>S</kbd> <kbd>D</kbd> | Move |
| <kbd>Left Click</kbd> | Shoot a paintball where the player is facing |
| <kbd>Mouse</kbd> | Click menu buttons |
The game started from the paintball project made in class.

# Added by me for the assignment:

IDamageable Interface for anything that can take damage. Enemies call TakeDamage() without knowing it is the player.

ChaserTarget: enemeies that chases and damages the player

PickupObject: is and abstract class. Handles spinning, object life and detecting the player. There are two types of pick up objects: One that heal and one that add points.

Win and lose conditions: You win when you get a score of 100, you lose when your health is 0

GameManager: Update the health and score HUD

MainMenuManager: MainMenu, WinMenu, GameOverMenu scenes.

Isometric camera that follows the player

