# Unity_FPS
This Unity project consists of several interconnected scripts that form a basic game framework:

    MainMenuManager: Handles main menu interactions with methods to start the game and quit the application using SceneManager.

    GameManager: Manages game logic including spawning enemies in waves, updating round information, and controlling game flow. It features methods for ending the game, restarting, and returning to the main menu. UI elements like round numbers and survival stats are dynamically updated during gameplay.

    PlayerManager: Manages player health and responds to damage events. It updates the UI with current health status and triggers the game over screen when health drops below zero.

    EnemyManager: Controls enemy behavior such as movement towards the player, attacking, and taking damage. It communicates with the GameManager to track enemy counts and trigger game events upon enemy defeat.

    WeaponManager: Implements player shooting mechanics, using raycasting to detect and damage enemies within a specified range. It includes visual effects for shooting and handles input from the player.

These scripts work together to create a basic game where players navigate rounds, fend off enemies, and manage health while interacting through menus and shooting mechanics facilitated by Unity's powerful engine capabilities.

