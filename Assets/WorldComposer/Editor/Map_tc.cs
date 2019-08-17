using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using System.Reflection;

[Serializable]
public class Map_tc : EditorWindow
{
	public string install_path;
	public Texture2D texture;
	public bool display_text;
	public string text; 
	public float rotAngle;
	public float label_old;
	public bool scroll;
	public int scroll_mode;
	public Vector2 mouse_position;
	public Vector2 mouse_position_old;
	public Vector2 mouse_move;
	public Event key;
	public bool button0;
	public bool button2;
	public int count_curve;
	public Vector2 offmap1;
	public Vector2 offmap2;
	public Vector2 offmap3;
	public Vector2 offmap4;
	public Vector2 offmap;
	public Rect hFileRect1;
	public Rect hFileRect2;
	public Rect iFileRect1;
	public Rect iFileRect2;
	public bool content_checked;
	public Vector2 offset;
	public Vector2 pixel3;
	public Vector2 pixel4;
	public Color[] pixels;
	public Vector2 offset2;
	public float time1;
	public GameObject Global_Settings_Scene;
	public global_settings_tc global_script;
	public GameObject TerrainComposer_Scene;
	public GameObject TerrainComposer_Parent;
	public EditorWindow tc_script;
	public Info_tc info_window;
	public bool terraincomposer;
	public Material material;
	public bool zooming;
	public double zoom;
	public double zoom1;
	public double zoom2;
	public double zoom3;
	public double zoom4;
	public double zoom_step;
	public double zoom1_step;
	public double zoom2_step;
	public double zoom3_step;
	public double zoom4_step;
	public double zoom_pos;
	public double zoom_pos1;
	public double zoom_pos2;
	public double zoom_pos3;
	public double zoom_pos4;
	public bool request1;
	public bool request2;
	public bool request3;
	public bool request4;
	public bool request_load1;
	public bool request_load2;
	public bool request_load3;
	public bool request_load4;
	public Rect screen_rect;
	public Rect screen_rect2;
	public Rect map_parameters_rect;
	public Rect regions_rect;
	public Rect areas_rect;
	public Rect heightmap_export_rect;
	public Rect image_export_rect;
	public Rect image_editor_rect;
	public Rect converter_rect;
	public Rect settings_rect;
	public Rect create_terrain_rect;
	public Rect help_rect;
	public Rect update_rect;
	public bool animate;
	public latlong_class latlong_animate;
	public Vector2 animate_pixel;
	public float animate_time_start;
	public bool script_set;
	public float tt1;
	public int gui_y;
	public int gui_y2;
	public int gui_height;
	public int guiWidth1;
	public int guiWidth2;
	public int guiWidth3;
	public int guiAreaHeight;
	public map_region_class current_region;
	public map_area_class current_area;
	public map_region_class create_region;
	public map_area_class create_area;
	public map_area_class convert_area;
	public Texture2D convert_texture;
	public tile_class convert_tile;
	public map_region_class export_heightmap_region;
	public map_area_class export_heightmap_area;
	public map_region_class export_image_region;
	public map_area_class export_image_area;
	public map_area_class import_image_area;
	public bool gui_changed_old;
	public map_area_class requested_area;
	public latlong_class latlong_mouse;
	public latlong_class latlong_center;
	public latlong_area_class latlong_area;
	public FileStream fs;
	public byte[] bytes;
	public Vector2 export_p1;
	public Vector2 export_p2;
	public float width_p1;
	public float height_p1;
	public terrain_region_class terrain_region;
	public bool colormap;
	public string[] heightmap_resolution_list;
	public int heightmap_resolution_select;
	public string[] image_resolution_list;
	public int image_resolution_select;
	public string path_old;
	public bool import_settings_call;
	public bool import_jpg_call;
	public bool import_png_call;
	public string import_jpg_path;
	public string import_png_path;
	public bool map_scrolling;
	public bool area_rounded;
	public bool generate_manual;
	public int old_fontSize;
	public FontStyle old_fontStyle;
	public float save_global_time;
	public bool focus;
	public Texture button_settings;
	public Texture button_help;
	public Texture button_heightmap;
	public Texture button_update;
	public Texture button_terrain;
	public Texture button_map;
	public Texture button_region;
	public Texture button_edit;
	public Texture button_image;
	public Texture button_converter;
	public gui_class wc_gui;
	public Vector2 area_size_old;
	public string notify_text;
	public int notify_frame;
	public Vector2 scrollPos;
	public ulong combine_width;
	public ulong combine_height;
	public ulong combine_length;
	public map_area_class combine_area;
	public string combine_import_filename;
	public string combine_import_path;
	public byte[] combine_byte;
	public FileStream combine_import_file;
	public FileStream combine_export_file;
	public string combine_export_path;
	public string combine_export_filename;
	public int combine_x;
	public int combine_y;
	public int combine_y1;
	public float combine_time;
	public bool combine_generate;
	public bool slice_generate;
	public float combine_progress;
	public bool combine_call;
	public Color[] combine_pixels;
	public Vector3 terrain_size;
	public GameObject terrain_parent;
	public float frames;
	public float auto_speed_time;
	public bool generate;
	public int generate_speed;
	public float generate_time_start;
	public float[,] heights;
	public float heightmap_x;
	public float heightmap_y;
	public float heightmap_res_x;
	public float heightmap_res_y;
	public int heightmap_resolution;
	public int heightmap_break_x_value;
	public int heightmap_count_terrain;
	public float tarframe;
	public int h_local_x;
	public int h_local_y;
	public raw_file_class raw_file;
	public Vector2 conversion_step;
	public bool create_terrain_loop;
	public bool apply_import_settings;
	public int import_settings_count;
	public int create_terrain_count;
	public int create_splat_count;
	public int x_old;

	public Map_tc()
	{
		this.install_path = string.Empty;
		this.rotAngle = (float)90;
		this.scroll_mode = 1;
		this.guiWidth1 = 120;
		this.guiWidth2 = 335;
		this.convert_tile = new tile_class();
		this.terrain_region = new terrain_region_class();
		this.colormap = true;
		this.heightmap_resolution_list = new string[]
		{
			"33",
			"65",
			"129",
			"257",
			"513",
			"1025",
			"2049",
			"4097"
		};
		this.image_resolution_list = new string[]
		{
			"32",
			"64",
			"128",
			"256",
			"512",
			"1024",
			"2048",
			"4096"
		};
		this.wc_gui = new gui_class(3);
		this.notify_text = string.Empty;
		this.generate_speed = 10000;
		this.tarframe = (float)30;
		this.raw_file = new raw_file_class();
	}

	[MenuItem("Window/World Composer")]
	public static void ShowWindow()
	{
		EditorWindow window = EditorWindow.GetWindow(typeof(Map_tc));
		window.titleContent = new GUIContent("World");
	}

	public void OnEnable()
	{
		this.install_path = this.GetInstallPath();
		if (Drawing_tc1.lineMaterial == null)
		{
			Drawing_tc1.lineMaterial = (((Material)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Drawing_tc.mat", typeof(Material))) as Material);
		}
		this.Get_TerrainComposer_Scene();
		this.load_button_textures();
		if (Type.GetType("TerrainComposer") != null)
		{
			this.terraincomposer = true;
		}
		else
		{
			this.terraincomposer = false;
		}
		this.content_startup();
		this.request_map();
	}

	public string GetInstallPath()
	{
		string assetPath = AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this));
		int length = assetPath.LastIndexOf("/Editor");
		return assetPath.Substring(0, length);
	}

	public void Get_TerrainComposer_Scene()
	{
		this.load_global_settings();
	}

	public void OnInspectorUpdate()
	{
		if (this.focus)
		{
			this.Repaint();
		}
		if (this.global_script && this.global_script.map.preimage_edit.generate)
		{
			this.Repaint();
		}
	}

	public void OnFocus()
	{
		this.focus = true;
		this.install_path = this.GetInstallPath();
		this.Get_TerrainComposer_Scene();
		this.init_paths();
	}

	public void OnLostFocus()
	{
		this.focus = false;
	}

	public void OnDisable()
	{
		if (this.tc_script != null)
		{
			this.tc_script.Repaint();
		}
	}

	public void OnDestroy()
	{
		save_global_settings();
		stop_all_elevation_pull();
		stop_all_image_pull();
	}

	public void OnGUI()
	{
		key = Event.current;
		if (!global_script)
		{
			if (key.type == EventType.Repaint)
			{
				Get_TerrainComposer_Scene();
			}
		}
		else
		{
			this.gui_y = 0;
			this.gui_y2 = 0;
			this.guiWidth2 = 335;
			this.guiWidth3 = 359;
			int num = 0;
			int num2 = 0;
			if (this.global_script.map.region_select > this.global_script.map.region.Count - 1)
			{
				this.global_script.map.region_select = this.global_script.map.region.Count - 1;
			}
			this.current_region = this.global_script.map.region[this.global_script.map.region_select];
			if (this.current_region.area_select > this.current_region.area.Count - 1)
			{
				this.current_region.area_select = this.current_region.area.Count - 1;
			}
			this.current_area = this.current_region.area[this.current_region.area_select];
			if (this.global_script.map.warnings && this.current_area != null && (this.current_area.heightmap_resolution.x > (float)4096 || this.current_area.heightmap_resolution.y > (float)4096))
			{
				if (this.notify_text.Length != 0)
				{
					this.notify_text += "\n\n";
				}
				this.notify_text = "The heightmap resolution is bigger then 4096, please keep in mind the Unity terrain performance and the 50k transaction limit of Bing, exceeding this amount by magnitudes within 24 hours might block your Bing key." + "\nMake your heightmap a lower resolution in 'Heightmap Export' -> 'Heightmap Zoom' -> Clicking the '-' button.\n\nPlease read page 7 in the WC manual, after reading and understanding you can disable the warnings in the 'Settings' tab -> Show Warnings";
			}
			if (!this.global_script.tex2)
			{
				this.global_script.tex2 = new Texture2D(1, 1);
				this.global_script.tex2.SetPixel(0, 0, this.global_script.map.backgroundColor);
				this.global_script.tex2.Apply();
			}
			if (!this.global_script.tex3)
			{
				this.global_script.tex3 = new Texture2D(1, 1);
				this.global_script.tex3.SetPixel(0, 0, this.global_script.map.titleColor);
				this.global_script.tex3.Apply();
			}
			if (!this.global_script.tex4)
			{
				this.global_script.tex4 = new Texture2D(1, 1);
				this.global_script.tex4.SetPixel(0, 0, Color.yellow);
				this.global_script.tex4.Apply();
			}
			GUI.color = Color.white;
			if (this.key.keyCode == KeyCode.F5 && this.key.type == EventType.KeyDown)
			{
				this.request_map();
			}
			this.latlong_mouse = this.global_script.pixel_to_latlong(new Vector2(this.key.mousePosition.x - this.position.width / (float)2 + this.offmap.x, this.key.mousePosition.y - this.position.height / (float)2 - this.offmap.y), this.global_script.map_latlong_center, this.zoom);
			this.latlong_center = this.global_script.pixel_to_latlong(new Vector2(this.offmap.x, -this.offmap.y), this.global_script.map_latlong_center, this.zoom);
			if (this.global_script.map4 && this.global_script.map_zoom_old > 3 && !this.global_script.map.button_image_editor)
			{
				num = (int)((this.zoom_pos4 + (double)1) * (double)this.global_script.map4.width * (double)4 * (double)2);
				num2 = (int)((this.zoom_pos4 + (double)1) * (double)this.global_script.map4.height * (double)4 * (double)2);
				if ((float)num < this.position.width * (float)12)
				{
					EditorGUI.DrawPreviewTexture(new Rect((float)((double)(-(double)this.offmap4.x) - this.zoom_pos4 * (double)((float)(this.global_script.map4.width * 2 * 2) + this.offmap4.x) - (double)2400 - (double)((float)800 - this.position.width / (float)2)), (float)((double)this.offmap4.y - this.zoom_pos4 * (double)((float)3200 - this.offmap4.y) - (double)2800 - (double)((float)400 - this.position.height / (float)2)), (float)num, (float)num2), this.global_script.map4);
				}
			}
			if (this.global_script.map3 && this.global_script.map_zoom_old > 2 && !this.global_script.map.button_image_editor)
			{
				if (this.global_script.map_zoom <= this.global_script.map_zoom_old + 2 || !this.global_script.map_load4 || this.global_script.map_load3)
				{
					num = (int)((this.zoom_pos3 + (double)1) * (double)this.global_script.map3.width * (double)4);
					num2 = (int)((this.zoom_pos3 + (double)1) * (double)this.global_script.map3.height * (double)4);
					if ((float)num < this.position.width * (float)12)
					{
						EditorGUI.DrawPreviewTexture(new Rect((float)((double)(-(double)this.offmap3.x) - this.zoom_pos3 * (double)((float)(this.global_script.map3.width * 2) + this.offmap3.x) - (double)800 - (double)((float)800 - this.position.width / (float)2)), (float)((double)this.offmap3.y - this.zoom_pos3 * (double)((float)1600 - this.offmap3.y) - (double)1200 - (double)((float)400 - this.position.height / (float)2)), (float)num, (float)num2), this.global_script.map3);
					}
				}
			}
			if (this.global_script.map0)
			{
				if ((this.global_script.map_zoom <= this.global_script.map_zoom_old + 2 || !this.global_script.map_load3) && (this.global_script.map_zoom <= this.global_script.map_zoom_old + 3 || !this.global_script.map_load4 || this.global_script.map_combine))
				{
					EditorGUI.DrawPreviewTexture(new Rect((float)((double)(-(double)this.offmap1.x) - this.zoom_pos1 * (double)((float)(this.global_script.map0.width / 2) + this.offmap1.x) - (double)((float)800 - this.position.width / (float)2)), (float)((double)this.offmap1.y - this.zoom_pos1 * (double)((float)400 - this.offmap1.y) - (double)((float)400 - this.position.height / (float)2)), (float)((double)this.global_script.map0.width + this.zoom_pos1 * (double)this.global_script.map0.width), (float)((double)this.global_script.map0.height + this.zoom_pos1 * (double)this.global_script.map0.height)), this.global_script.map0);
				}
			}
			this.zoom = (double)(Mathf.Log((float)(this.zoom_pos1 + (double)1), (float)2) + (float)this.global_script.map_zoom_old);
			if (!this.global_script.map.button_image_editor)
			{
				for (int i = 0; i < this.global_script.map.region.Count; i++)
				{
					this.current_region = this.global_script.map.region[i];
					for (int j = 0; j < this.current_region.area.Count; j++)
					{
						if (this.current_region.area[j].created)
						{
							this.pixel3 = this.global_script.latlong_to_pixel(this.current_region.area[j].upper_left, this.global_script.map_latlong_center, this.zoom, new Vector2(this.position.width, this.position.height));
							if (this.current_region.area[j].select == 1)
							{
								this.latlong_area = this.global_script.calc_latlong_area_rounded(this.current_region.area[j].upper_left, this.latlong_mouse, (double)this.current_region.area[j].image_zoom, this.current_region.area[j].resolution, this.key.shift, 8);
								this.current_region.area[j].lower_right = this.latlong_area.latlong2;
							}
							this.current_region.area[j].tiles = this.global_script.calc_latlong_area_tiles(this.current_region.area[j].upper_left, this.current_region.area[j].lower_right, (double)this.current_region.area[j].image_zoom, this.current_region.area[j].resolution);
							this.pixel4 = this.global_script.latlong_to_pixel(this.current_region.area[j].lower_right, this.global_script.map_latlong_center, this.zoom, new Vector2(this.position.width, this.position.height));
							float num3 = this.pixel4.x - this.pixel3.x;
							float num4 = this.pixel4.y - this.pixel3.y;
							Color color = default(Color);
							if (j == this.current_region.area_select && i == this.global_script.map.region_select)
							{
								this.current_area.size = this.global_script.calc_latlong_area_size(this.current_area.upper_left, this.current_area.lower_right, this.current_area.center);
								color = Color.yellow;
								this.area_rounded = this.global_script.draw_latlong_raster(this.current_region.area[j].upper_left, this.current_region.area[j].lower_right, this.offmap, (double)this.current_region.area[j].image_zoom, this.zoom, this.current_region.area[j].resolution, new Rect((float)0, (float)0, this.position.width, this.position.height), new Color((float)1, (float)1, (float)0, 0.5f), 2);
								if (this.current_region.area[j].export_heightmap_active || this.current_region.area[j].export_image_active)
								{
									color = new Color((float)1, (float)1, (float)1, (float)1);
								}
								else if (this.current_region.area[j].export_heightmap_call || this.current_region.area[j].export_image_call)
								{
									color = new Color((float)1, 0.5f, (float)0, (float)1);
								}
								this.global_script.DrawRect(new Rect(-this.offmap.x + this.pixel3.x, this.offmap.y + this.pixel3.y, num3, num4), color, (float)2, new Rect((float)0, (float)0, this.position.width, this.position.height));
								color = Color.yellow;
								if (this.key.button == 0 && this.key.isMouse && this.key.type == 0 && this.current_area.start_tile_enabled && new Rect(this.pixel3.x, this.pixel3.y, num3, num4).Contains(this.key.mousePosition))
								{
									this.current_area.start_tile.x = (int)Mathf.Floor((this.key.mousePosition.x - this.pixel3.x) / (num3 / (float)this.current_area.tiles.x));
									this.current_area.start_tile.y = (int)Mathf.Floor((this.key.mousePosition.y - this.pixel3.y) / (num4 / (float)this.current_area.tiles.y));
									this.current_area.start_tile_enabled = false;
									this.Repaint();
								}
								if (this.global_script.map.mode == 2 && !this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate && (this.export_image_area != this.current_area) || (!this.current_area.export_image_active && !this.current_area.export_heightmap_active))
								{
									this.Repaint();
									if (this.current_area.start_tile.x > this.current_area.tiles.x - 1)
									{
										this.current_area.start_tile.x = this.current_area.tiles.x - 1;
									}
									else if (this.current_area.start_tile.x < 0)
									{
										this.current_area.start_tile.x = 0;
									}
									if (this.current_area.start_tile.y > this.current_area.tiles.y - 1)
									{
										this.current_area.start_tile.y = this.current_area.tiles.y - 1;
									}
									else if (this.current_area.start_tile.y < 0)
									{
										this.current_area.start_tile.y = 0;
									}
									if (!this.current_area.resize)
									{
										EditorGUIUtility.AddCursorRect(new Rect(this.pixel3.x - (float)10, this.pixel3.y + (float)20, (float)20, num4 - (float)40), MouseCursor.ResizeHorizontal);
										EditorGUIUtility.AddCursorRect(new Rect(this.pixel3.x + num3 - (float)10, this.pixel3.y + (float)20, (float)20, num4 - (float)40), MouseCursor.ResizeHorizontal);
										EditorGUIUtility.AddCursorRect(new Rect(this.pixel3.x + num3 / (float)2 - (float)20, this.pixel3.y + num4 / (float)2 - (float)20, (float)40, (float)40), MouseCursor.Link);
										EditorGUIUtility.AddCursorRect(new Rect(this.pixel3.x + (float)20, this.pixel3.y - (float)10, num3 - (float)40, (float)20), MouseCursor.ResizeVertical);
										EditorGUIUtility.AddCursorRect(new Rect(this.pixel3.x + (float)20, this.pixel3.y + num4 - (float)10, num3 - (float)40, (float)20), MouseCursor.ResizeVertical);
										EditorGUIUtility.AddCursorRect(new Rect(this.pixel3.x - (float)20, this.pixel3.y - (float)20, (float)40, (float)40), MouseCursor.ResizeUpLeft);
										EditorGUIUtility.AddCursorRect(new Rect(this.pixel3.x + num3 - (float)20, this.pixel3.y - (float)20, (float)40, (float)40), MouseCursor.ResizeUpRight);
										EditorGUIUtility.AddCursorRect(new Rect(this.pixel3.x - (float)20, this.pixel3.y - (float)20 + num4, (float)40, (float)40), MouseCursor.ResizeUpRight);
										EditorGUIUtility.AddCursorRect(new Rect(this.pixel3.x + num3 - (float)20, this.pixel3.y - (float)20 + num4, (float)40, (float)40), MouseCursor.ResizeUpLeft);
									}
									if (this.key.button == 0 && this.key.isMouse)
									{
										if (this.key.type == EventType.MouseDown)
										{
											if (!this.current_area.resize)
											{
												if (new Rect(this.pixel3.x - (float)10, this.pixel3.y + (float)20, (float)20, num4 - (float)40).Contains(this.key.mousePosition))
												{
													this.current_area.resize_left = true;
													this.current_area.resize = true;
												}
												else if (new Rect(this.pixel3.x + num3 - (float)10, this.pixel3.y + (float)20, (float)20, num4 - (float)40).Contains(this.key.mousePosition))
												{
													this.current_area.resize_right = true;
													this.current_area.resize = true;
												}
												else if (new Rect(this.pixel3.x + (float)20, this.pixel3.y - (float)10, num3 - (float)40, (float)20).Contains(this.key.mousePosition))
												{
													this.current_area.resize_top = true;
													this.current_area.resize = true;
												}
												else if (new Rect(this.pixel3.x + (float)20, this.pixel3.y + num4 - (float)10, num3 - (float)40, (float)20).Contains(this.key.mousePosition))
												{
													this.current_area.resize_bottom = true;
													this.current_area.resize = true;
												}
												else if (new Rect(this.pixel3.x - (float)20, this.pixel3.y - (float)20, (float)40, (float)40).Contains(this.key.mousePosition))
												{
													this.current_area.resize_topLeft = true;
													this.current_area.resize = true;
												}
												else if (new Rect(this.pixel3.x + num3 - (float)20, this.pixel3.y - (float)20, (float)40, (float)40).Contains(this.key.mousePosition))
												{
													this.current_area.resize_topRight = true;
													this.current_area.resize = true;
												}
												else if (new Rect(this.pixel3.x - (float)20, this.pixel3.y - (float)20 + num4, (float)40, (float)40).Contains(this.key.mousePosition))
												{
													this.current_area.resize_bottomLeft = true;
													this.current_area.resize = true;
												}
												else if (new Rect(this.pixel3.x + num3 - (float)20, this.pixel3.y - (float)20 + num4, (float)40, (float)40).Contains(this.key.mousePosition))
												{
													this.current_area.resize_bottomRight = true;
													this.current_area.resize = true;
												}
												else if (new Rect(this.pixel3.x + num3 / (float)2 - (float)20, this.pixel3.y + num4 / (float)2 - (float)20, (float)40, (float)40).Contains(this.key.mousePosition))
												{
													this.current_area.resize_center = true;
													this.current_area.resize = true;
												}
											}
										}
										else if (this.key.type == EventType.MouseUp)
										{
											this.current_area.resize_left = false;
											this.current_area.resize_right = false;
											this.current_area.resize_top = false;
											this.current_area.resize_bottom = false;
											this.current_area.resize_topLeft = false;
											this.current_area.resize_topRight = false;
											this.current_area.resize_bottomLeft = false;
											this.current_area.resize_bottomRight = false;
											this.current_area.resize_center = false;
											this.current_area.resize = false;
											this.global_script.map.elExt_check_assign = true;
											this.requested_area = this.current_area;
											this.get_elevation_info(this.current_area.center);
										}
									}
									this.calc_heightmap_settings(this.current_area);
									if (!this.current_area.terrain_heightmap_resolution_changed)
									{
										this.calc_terrain_heightmap_resolution();
									}
									if (this.current_area.resize_left)
									{
										EditorGUIUtility.AddCursorRect(new Rect((float)0, (float)0, this.position.width, this.position.height), MouseCursor.ResizeHorizontal);
										this.latlong_area = this.global_script.calc_latlong_area_rounded(new latlong_class(this.current_area.upper_left.latitude, this.latlong_mouse.longitude), this.current_area.lower_right, (double)this.current_area.image_zoom, this.current_area.resolution, this.key.shift, 1);
										this.current_area.upper_left.longitude = this.latlong_area.latlong1.longitude;
									}
									else if (this.current_area.resize_right)
									{
										EditorGUIUtility.AddCursorRect(new Rect((float)0, (float)0, this.position.width, this.position.height), MouseCursor.ResizeHorizontal);
										this.latlong_area = this.global_script.calc_latlong_area_rounded(this.current_area.upper_left, new latlong_class(this.current_area.lower_right.latitude, this.latlong_mouse.longitude), (double)this.current_area.image_zoom, this.current_area.resolution, this.key.shift, 2);
										this.current_area.lower_right.longitude = this.latlong_area.latlong2.longitude;
									}
									else if (this.current_area.resize_top)
									{
										EditorGUIUtility.AddCursorRect(new Rect((float)0, (float)0, this.position.width, this.position.height), MouseCursor.ResizeVertical);
										this.latlong_area = this.global_script.calc_latlong_area_rounded(new latlong_class(this.latlong_mouse.latitude, this.current_area.upper_left.longitude), this.current_area.lower_right, (double)this.current_area.image_zoom, this.current_area.resolution, this.key.shift, 3);
										this.current_area.upper_left.latitude = this.latlong_area.latlong1.latitude;
									}
									else if (this.current_area.resize_bottom)
									{
										EditorGUIUtility.AddCursorRect(new Rect((float)0, (float)0, this.position.width, this.position.height), MouseCursor.ResizeVertical);
										this.latlong_area = this.global_script.calc_latlong_area_rounded(this.current_area.upper_left, new latlong_class(this.latlong_mouse.latitude, this.current_area.lower_right.longitude), (double)this.current_area.image_zoom, this.current_area.resolution, this.key.shift, 4);
										this.current_area.lower_right.latitude = this.latlong_area.latlong2.latitude;
									}
									else if (this.current_area.resize_topLeft)
									{
										EditorGUIUtility.AddCursorRect(new Rect((float)0, (float)0, this.position.width, this.position.height), MouseCursor.ResizeUpLeft);
										this.latlong_area = this.global_script.calc_latlong_area_rounded(this.latlong_mouse, this.current_area.lower_right, (double)this.current_area.image_zoom, this.current_area.resolution, this.key.shift, 5);
										this.current_area.upper_left = this.latlong_area.latlong1;
									}
									else if (this.current_area.resize_topRight)
									{
										EditorGUIUtility.AddCursorRect(new Rect((float)0, (float)0, this.position.width, this.position.height), MouseCursor.ResizeUpRight);
										this.latlong_area = this.global_script.calc_latlong_area_rounded(new latlong_class(this.latlong_mouse.latitude, this.current_area.upper_left.longitude), new latlong_class(this.current_area.lower_right.latitude, this.latlong_mouse.longitude), (double)this.current_area.image_zoom, this.current_area.resolution, this.key.shift, 6);
										this.current_area.upper_left.latitude = this.latlong_area.latlong1.latitude;
										this.current_area.lower_right.longitude = this.latlong_area.latlong2.longitude;
									}
									else if (this.current_area.resize_bottomLeft)
									{
										EditorGUIUtility.AddCursorRect(new Rect((float)0, (float)0, this.position.width, this.position.height), MouseCursor.ResizeUpRight);
										this.latlong_area = this.global_script.calc_latlong_area_rounded(new latlong_class(this.current_area.upper_left.latitude, this.latlong_mouse.longitude), new latlong_class(this.latlong_mouse.latitude, this.current_area.lower_right.longitude), (double)this.current_area.image_zoom, this.current_area.resolution, this.key.shift, 7);
										this.current_area.upper_left.longitude = this.latlong_area.latlong1.longitude;
										this.current_area.lower_right.latitude = this.latlong_area.latlong2.latitude;
									}
									else if (this.current_area.resize_bottomRight)
									{
										EditorGUIUtility.AddCursorRect(new Rect((float)0, (float)0, this.position.width, this.position.height), MouseCursor.ResizeUpLeft);
										this.latlong_area = this.global_script.calc_latlong_area_rounded(this.current_area.upper_left, this.latlong_mouse, (double)this.current_area.image_zoom, this.current_area.resolution, this.key.shift, 8);
										this.current_area.lower_right = this.latlong_area.latlong2;
									}
									else if (this.current_area.resize_center)
									{
										EditorGUIUtility.AddCursorRect(new Rect((float)0, (float)0, this.position.width, this.position.height), MouseCursor.Link);
										this.global_script.calc_latlong_area_from_center(this.current_area, this.latlong_mouse, (double)this.current_area.image_zoom, new Vector2((float)(this.current_area.resolution * this.current_area.tiles.x), (float)(this.current_area.resolution * this.current_area.tiles.y)));
									}
								}
								if (this.current_area.start_tile.x != 0 || this.current_area.start_tile.y != 0)
								{
									this.export_p1.x = this.pixel3.x + num3 / (float)this.current_area.tiles.x * (float)this.current_area.start_tile.x;
									this.export_p1.y = this.pixel3.y + num4 / (float)this.current_area.tiles.y * (float)this.current_area.start_tile.y;
									this.width_p1 = num3 / (float)this.current_area.tiles.x;
									this.height_p1 = num4 / (float)this.current_area.tiles.y;
									this.global_script.DrawRect(new Rect(-this.offmap.x + this.export_p1.x, this.offmap.y + this.export_p1.y, this.width_p1, this.height_p1), new Color((float)1, (float)0, (float)0, (float)1), (float)2, new Rect((float)0, (float)0, this.position.width, this.position.height));
								}
							}
							else
							{
								if (this.current_region.area[j].export_heightmap_active || this.current_region.area[j].export_image_active)
								{
									color = new Color((float)1, (float)1, (float)1, (float)1);
								}
								else if (this.current_region.area[j].export_heightmap_call || this.current_region.area[j].export_image_call)
								{
									color = new Color((float)1, 0.5f, (float)0, (float)1);
								}
								else
								{
									color = Color.green;
								}
								this.global_script.DrawRect(new Rect(-this.offmap.x + this.pixel3.x, this.offmap.y + this.pixel3.y, num3, num4), color, (float)2, new Rect((float)0, (float)0, this.position.width, this.position.height));
								color = Color.green;
							}
							this.current_region.area[j].center = this.global_script.calc_latlong_center(this.current_region.area[j].upper_left, this.current_region.area[j].lower_right, this.zoom, new Vector2(this.position.width, this.position.height));
							Vector2 vector = this.global_script.latlong_to_pixel(this.current_region.area[j].center, this.global_script.map_latlong_center, this.zoom, new Vector2(this.position.width, this.position.height));
							float num5 = num3 / (float)175 - 0.7f;
							float num6 = num4 / (float)175 - 0.7f;
							if (num5 > (float)1)
							{
								num5 = (float)1;
							}
							if (num6 > (float)1)
							{
								num6 = (float)1;
							}
							float fontSize = 0f;
							if (this.zoom > (double)12)
							{
								fontSize = (float)(this.zoom + (this.zoom - (double)12) * (double)3);
							}
							else
							{
								fontSize = (float)12;
							}
							if (num5 / (float)2 > (float)0)
							{
								this.global_script.drawText((this.current_region.area[j].size.x / (double)1000).ToString("F3") + " (Km)", new Vector2(-this.offmap.x + this.pixel3.x + num3 / (float)2, this.offmap.y + this.pixel3.y), true, new Color((float)1, (float)0, (float)0, num5), new Color(color.r, color.g, color.b, num5 / (float)2), (float)0, fontSize, false, 2);
								this.global_script.drawText((this.current_region.area[j].size.y / (double)1000).ToString("F3") + " (Km)", new Vector2(-this.offmap.x + this.pixel3.x - (float)30, this.offmap.y + this.pixel3.y + num4 / (float)2), true, new Color((float)1, (float)0, (float)0, num6), new Color(color.r, color.g, color.b, num6 / (float)2), (float)-90, fontSize, false, 4);
								if (this.current_area.resize && !this.current_area.resize_center && j == this.current_region.area_select && i == this.global_script.map.region_select)
								{
									this.global_script.drawText(this.current_region.area[j].tiles.x.ToString() + "x" + this.current_region.area[j].tiles.y.ToString(), this.key.mousePosition + new Vector2((float)10, (float)20), true, new Color((float)1, (float)0, (float)0, (float)1), color + new Color((float)0, (float)0, (float)0, -0.5f), (float)0, (float)12, true, 3);
								}
								else
								{
									this.global_script.drawText(this.current_region.area[j].tiles.x.ToString() + "x" + this.current_region.area[j].tiles.y.ToString(), new Vector2(this.pixel4.x - this.offmap.x, this.pixel4.y + this.offmap.y), true, new Color((float)1, (float)0, (float)0, num5), new Color(color.r, color.g, color.b, num5 / (float)2), (float)0, (float)12, true, 5);
								}
							}
							Vector2 vector2 = this.global_script.drawText(this.current_region.area[j].name, new Vector2(-this.offmap.x + this.pixel3.x, this.offmap.y + this.pixel3.y), true, new Color((float)1, (float)0, (float)0, (float)1), color + new Color((float)0, (float)0, (float)0, -0.5f), (float)0, fontSize, true, 3);
							if (this.key.button == 0 && this.key.type == 0 && new Rect(-this.offmap.x + this.pixel3.x, this.offmap.y + this.pixel3.y - vector2.y, vector2.x, vector2.y).Contains(this.key.mousePosition))
							{
								this.global_script.map.region_select = i;
								this.global_script.map.region[i].area_select = j;
								this.Repaint();
							}
							if (this.global_script.map.export_heightmap_active)
							{
								for (int k = 0; k < this.global_script.map.elExt.Count; k++)
								{
									this.export_p1 = this.global_script.latlong_to_pixel(this.global_script.map.elExt[k].latlong_area.latlong1, this.global_script.map_latlong_center, this.zoom, new Vector2(this.position.width, this.position.height));
									this.export_p2 = this.global_script.latlong_to_pixel(this.global_script.map.elExt[k].latlong_area.latlong2, this.global_script.map_latlong_center, this.zoom, new Vector2(this.position.width, this.position.height));
									this.width_p1 = this.export_p2.x - this.export_p1.x;
									this.height_p1 = this.export_p2.y - this.export_p1.y;
									if (this.global_script.map.elExt[k].error == 1)
									{
										this.global_script.DrawRect(new Rect(-this.offmap.x + this.export_p1.x, this.offmap.y + this.export_p1.y, this.width_p1, this.height_p1), new Color(0.8f, (float)0, (float)0, (float)1), (float)2, new Rect((float)0, (float)0, this.position.width, this.position.height));
									}
									else if (this.global_script.map.elExt[k].error == 2)
									{
										this.global_script.DrawRect(new Rect(-this.offmap.x + this.export_p1.x, this.offmap.y + this.export_p1.y, this.width_p1, this.height_p1), new Color(0.8f, (float)0, 0.8f, (float)1), (float)2, new Rect((float)0, (float)0, this.position.width, this.position.height));
									}
									else
									{
										this.global_script.DrawRect(new Rect(-this.offmap.x + this.export_p1.x, this.offmap.y + this.export_p1.y, this.width_p1, this.height_p1), new Color(0.95f, 0.62f, 0.04f, (float)1), (float)2, new Rect((float)0, (float)0, this.position.width, this.position.height));
									}
								}
							}
							if (this.global_script.map.export_image_active)
							{
								for (int l = 0; l < this.global_script.map.texExt.Count; l++)
								{
									this.export_p1 = this.global_script.latlong_to_pixel(this.global_script.map.texExt[l].latlong_area.latlong1, this.global_script.map_latlong_center, this.zoom, new Vector2(this.position.width, this.position.height));
									this.export_p2 = this.global_script.latlong_to_pixel(this.global_script.map.texExt[l].latlong_area.latlong2, this.global_script.map_latlong_center, this.zoom, new Vector2(this.position.width, this.position.height));
									this.width_p1 = this.export_p2.x - this.export_p1.x;
									this.height_p1 = this.export_p2.y - this.export_p1.y;
									if (this.global_script.map.texExt[l].error == 1)
									{
										this.global_script.DrawRect(new Rect(-this.offmap.x + this.export_p1.x, this.offmap.y + this.export_p1.y, this.width_p1, this.height_p1), new Color(0.8f, (float)0, (float)0, (float)1), (float)2, new Rect((float)0, (float)0, this.position.width, this.position.height));
									}
									else
									{
										this.global_script.DrawRect(new Rect(-this.offmap.x + this.export_p1.x, this.offmap.y + this.export_p1.y, this.width_p1, this.height_p1), Color.green, (float)2, new Rect((float)0, (float)0, this.position.width, this.position.height));
									}
								}
							}
							Drawing_tc1.DrawLine(new Vector2((float)((double)(vector.x - (float)10 - this.offmap.x) + ((double)7 - this.zoom / (double)2.7f) / (double)1), (float)((double)(vector.y - (float)10 + this.offmap.y) + ((double)7 - this.zoom / (double)2.7f) / (double)1)), new Vector2((float)((double)(vector.x + (float)10 - this.offmap.x) - ((double)7 - this.zoom / (double)2.7f) / (double)1), (float)((double)(vector.y + (float)10 + this.offmap.y) - ((double)7 - this.zoom / (double)2.7f) / (double)1)), color, (float)1, false, new Rect((float)0, (float)0, this.position.width, this.position.height));
							Drawing_tc1.DrawLine(new Vector2((float)((double)(vector.x - (float)10 - this.offmap.x) + ((double)7 - this.zoom / (double)2.7f) / (double)1), (float)((double)(vector.y + (float)10 + this.offmap.y) - ((double)7 - this.zoom / (double)2.7f) / (double)1)), new Vector2((float)((double)(vector.x + (float)10 - this.offmap.x) - ((double)7 - this.zoom / (double)2.7f) / (double)1), (float)((double)(vector.y - (float)10 + this.offmap.y) + ((double)7 - this.zoom / (double)2.7f) / (double)1)), color, (float)1, false, new Rect((float)0, (float)0, this.position.width, this.position.height));
						}
					}
				}
			}

			this.current_region = this.global_script.map.region[this.global_script.map.region_select];
			if (this.current_region.area.Count > 0 && this.global_script.map.mode == 1)
			{
				if (this.key.button == 0 && this.key.isMouse && this.key.type == EventType.MouseDown && !this.check_in_rect())
				{
					if (this.current_area.select == 0)
					{
						this.current_area.upper_left = this.latlong_mouse;
						this.current_area.select = 1;
						this.current_area.created = true;
						this.requested_area = this.current_area;
						this.global_script.map.elExt_check_assign = true;
						this.get_elevation_info(this.current_area.upper_left);
						this.current_area.start_tile_enabled = false;
						this.current_area.start_tile.x = 0;
						this.current_area.start_tile.y = 0;
					}
					else
					{
						this.pick_done();
					}
				}
				if (this.key.button == 1)
				{
					this.current_area.select = 0;
					this.current_area.created = false;
					this.current_area.reset();
				}
				if (this.current_area.select == 1)
				{
					this.calc_heightmap_settings(this.current_area);
					if (!this.current_area.terrain_heightmap_resolution_changed)
					{
						this.calc_terrain_heightmap_resolution();
					}
					this.Repaint();
				}
			}
			if (this.global_script.map.mode != 1 && this.key.button == 1 && this.key.type == EventType.MouseDown && this.global_script.map.elExt_check_loaded)
			{
				this.get_elevation_info(this.latlong_mouse);
			}
			Drawing_tc1.DrawLine(new Vector2(this.position.width / (float)2, this.position.height / (float)2 - (float)10), new Vector2(this.position.width / (float)2, this.position.height / (float)2 + (float)10), Color.green, (float)1, false, new Rect((float)0, (float)0, this.position.width, this.position.height));
			Drawing_tc1.DrawLine(new Vector2(this.position.width / (float)2 - (float)10, this.position.height / (float)2), new Vector2(this.position.width / (float)2 + (float)10, this.position.height / (float)2), Color.green, (float)1, false, new Rect((float)0, (float)0, this.position.width, this.position.height));
			GUI.color = this.global_script.map.titleColor;
			EditorGUI.DrawPreviewTexture(new Rect((float)0, (float)0, (float)1422, (float)24), this.global_script.tex2);
			if (this.global_script.map.button_parameters || this.global_script.map.button_region || this.global_script.map.button_heightmap_export || this.global_script.map.button_image_export || this.global_script.map.button_settings || this.global_script.map.button_image_editor || this.global_script.map.button_update)
			{
				GUI.color = this.global_script.map.titleColor;
				if (this.global_script.map.button_image_editor)
				{
					EditorGUI.DrawPreviewTexture(new Rect((float)0, (float)24, (float)(this.guiWidth2 + 348), (float)19), this.global_script.tex2);
				}
				else
				{
					EditorGUI.DrawPreviewTexture(new Rect((float)0, (float)24, (float)this.guiWidth2, (float)19), this.global_script.tex2);
				}
			}
			GUI.color = new Color((float)1, (float)1, (float)1, this.global_script.map.alpha);
			int num7 = 0;
			if (this.global_script.map.button_image_editor)
			{
				num7 += 113 + this.global_script.map.preimage_edit.edit_color.Count * 18;
				if (this.current_area.preimage_save_new)
				{
					num7 += 60;
				}
			}
			if (global_script.map.button_parameters && global_script.map.key_edit)
			{
				GUI.color = this.global_script.map.backgroundColor;
                EditorGUI.DrawPreviewTexture(new Rect(guiWidth3, num7 + 45 - scrollPos.y, 799, 58), global_script.tex2);
                GUI.color = Color.red;
				EditorGUI.LabelField(new Rect(guiWidth3, (float)(num7 + 45) - this.scrollPos.y, this.position.width, (float)70), "You need to create a free Bing key. Read the WorldComposer manual in the TerrainComposer folder how to do this.\nIf you are in Webplayer build mode, read the troubleshooting in the WorldComposer manual to get it working.\nAfter you entered the key, press F5 to refresh. Then press the 'K' button in Map Parameters to hide the key and this text.\nThen follow the steps on page 6 of the manual to export and create a terrain.", EditorStyles.boldLabel);
				if (this.global_script.map.button_update)
				{
					num7 += 86;
				}
				for (int m = 0; m < this.global_script.map.bingKey.Count; m++)
				{
					GUI.color = this.global_script.map.backgroundColor;
					EditorGUI.DrawPreviewTexture(new Rect(guiWidth3, (float)num7 + (float)m * 19.9f + (float)220 - (float)96 - (float)(this.global_script.map.bingKey.Count * 0) - this.scrollPos.y, (float)this.global_script.label_width("Key" + m.ToString() + " -> '" + this.global_script.map.bingKey[m].key + "'", true), (float)17), this.global_script.tex2);
					GUI.color = Color.red;
					EditorGUI.LabelField(new Rect(guiWidth3, (float)num7 + (float)m * 19.9f + (float)220 - (float)96 - (float)(this.global_script.map.bingKey.Count * 0) - this.scrollPos.y, this.position.width, (float)50), "Key" + m.ToString() + " -> '" + this.global_script.map.bingKey[m].key + "'", EditorStyles.boldLabel);
				}
				if (this.global_script.map.button_update)
				{
					num7 -= 86;
				}
				GUI.color = Color.white;
			}
			if (this.global_script.map.path_display)
			{
				GUI.color = this.global_script.map.backgroundColor;
				EditorGUI.DrawPreviewTexture(new Rect(this.heightmap_export_rect.x + (float)this.guiWidth2 + (float)25, this.heightmap_export_rect.y + (float)60 + (float)num7 + (float)46 - this.scrollPos.y, (float)this.global_script.label_width(this.current_area.export_heightmap_path, true), (float)20), this.global_script.tex2);
				GUI.color = this.global_script.map.color;
				EditorGUI.LabelField(new Rect(this.heightmap_export_rect.x + (float)this.guiWidth2 + (float)25, this.heightmap_export_rect.y + (float)61 + (float)num7 + (float)46 - this.scrollPos.y, (float)this.global_script.label_width(this.current_area.export_heightmap_path, true), (float)20), new GUIContent(this.current_area.export_heightmap_path), EditorStyles.boldLabel);
			}
			if (this.global_script.map.path_display)
			{
				GUI.color = this.global_script.map.backgroundColor;
				EditorGUI.DrawPreviewTexture(new Rect(this.image_export_rect.x + (float)this.guiWidth2 + (float)25, this.image_export_rect.y + (float)num7 + (float)117 + (float)43 - this.scrollPos.y, (float)this.global_script.label_width(this.current_area.export_image_path, true), (float)20), this.global_script.tex2);
				GUI.color = this.global_script.map.color;
				EditorGUI.LabelField(new Rect(this.image_export_rect.x + (float)this.guiWidth2 + (float)25, this.image_export_rect.y + (float)num7 + (float)118 + (float)43 - this.scrollPos.y, (float)this.global_script.label_width(this.current_area.export_image_path, true), (float)20), new GUIContent(this.current_area.export_image_path), EditorStyles.boldLabel);
				GUI.color = Color.white;
			}
			EditorGUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUI.backgroundColor = new Color((float)1, (float)1, (float)1, 0.75f);
			if (this.global_script.map.button_parameters)
			{
				GUI.backgroundColor = Color.green;
			}
			else
			{
				GUI.backgroundColor = Color.white;
			}
			if (GUILayout.Button(new GUIContent("Map Parameters", this.button_map, "This shows the actual position on the map, with latitude/longitude and zoom level."), new GUILayoutOption[]
			{
				GUILayout.Width((float)150),
				GUILayout.Height((float)19)
			}))
			{
				this.global_script.map.button_parameters = !this.global_script.map.button_parameters;
			}
			if (this.global_script.map.button_region)
			{
				GUI.backgroundColor = Color.green;
			}
			else
			{
				GUI.backgroundColor = Color.white;
			}
			if (GUILayout.Button(new GUIContent("Regions", this.button_region, "This shows the Region window.\nA region can contain multiple areas and can be used for keeping good overview."), new GUILayoutOption[]
			{
				GUILayout.Width((float)120),
				GUILayout.Height((float)19)
			}))
			{
				this.global_script.map.button_region = !this.global_script.map.button_region;
			}
			if (this.global_script.map.button_heightmap_export)
			{
				GUI.backgroundColor = Color.green;
			}
			else
			{
				GUI.backgroundColor = Color.white;
			}
			if (GUILayout.Button(new GUIContent("Heightmap Export", this.button_heightmap, "This shows the Heightmap Export window.\nWith it you can export the heigthmap of an area."), new GUILayoutOption[]
			{
				GUILayout.Width((float)150),
				GUILayout.Height((float)19)
			}))
			{
				this.global_script.map.button_heightmap_export = !this.global_script.map.button_heightmap_export;
			}
			if (this.global_script.map.button_image_export)
			{
				GUI.backgroundColor = Color.green;
			}
			else
			{
				GUI.backgroundColor = Color.white;
			}
			if (GUILayout.Button(new GUIContent("Image Export", this.button_image, "This shows the Image Export window.\nWith it you can export the satellite images of an area."), new GUILayoutOption[]
			{
				GUILayout.Width((float)150),
				GUILayout.Height((float)19)
			}))
			{
				this.global_script.map.button_image_export = !this.global_script.map.button_image_export;
			}
			if (this.global_script.map.button_image_editor)
			{
				GUI.backgroundColor = Color.green;
			}
			else
			{
				GUI.backgroundColor = Color.white;
			}
			if (this.global_script.map.preimage_edit.generate && this.global_script.map.preimage_edit.mode == 2)
			{
				GUI.backgroundColor = GUI.backgroundColor + new Color((float)1, -0.5f, (float)-1);
			}
			if (GUILayout.Button(new GUIContent("Image Editor", this.button_edit, "This shows the Image Editor window.\nThis is for removing shadows from the exported satellite images.\nHow this works is explain in the manual on page 11."), new GUILayoutOption[]
			{
				GUILayout.Width((float)150),
				GUILayout.Height((float)19)
			}))
			{
				this.global_script.map.button_image_editor = !this.global_script.map.button_image_editor;
				if (this.global_script.map.button_image_editor)
				{
					this.image_generate_begin();
				}
				else
				{
					if (this.global_script.map.preimage_edit.generate && this.global_script.map.preimage_edit.mode == 1)
					{
						this.global_script.map.preimage_edit.generate = false;
					}
					this.image_map2();
					this.request_map3();
					this.request_map4();
				}
			}
            if (this.global_script.map.button_settings)
			{
				GUI.backgroundColor = Color.green;
			}
			else
			{
				GUI.backgroundColor = Color.white;
			}
			if (GUILayout.Button(new GUIContent("Settings", this.button_settings, "This shows the Settings window."), new GUILayoutOption[]
			{
				GUILayout.Width((float)120),
				GUILayout.Height((float)19)
			}))
			{
				this.global_script.map.button_settings = !this.global_script.map.button_settings;
			}
			if (this.global_script.map.button_create_terrain)
			{
				GUI.backgroundColor = Color.green;
			}
			else
			{
				GUI.backgroundColor = Color.white;
			}
			if (GUILayout.Button(new GUIContent("Create Terrain", this.button_terrain, "This shows the Create Terrain window.\nWith it you can create terrains from exported area."), new GUILayoutOption[]
			{
				GUILayout.Width((float)150),
				GUILayout.Height((float)19)
			}))
			{
				this.global_script.map.button_create_terrain = !this.global_script.map.button_create_terrain;
			}
			if (this.global_script.map.button_converter)
			{
				GUI.backgroundColor = Color.green;
			}
			else
			{
				GUI.backgroundColor = Color.white;
			}
			if (GUILayout.Button(new GUIContent("Converter", this.button_converter, "This shows the Converter window.\nWith it you can convert an ascii heightmap to a raw 16 bit heightmap, which is the format WorldComposer can use."), new GUILayoutOption[]
			{
				GUILayout.Width((float)150),
				GUILayout.Height((float)19)
			}))
			{
				this.global_script.map.button_converter = !this.global_script.map.button_converter;
			}
			if (this.global_script.map.button_help)
			{
				GUI.backgroundColor = Color.green;
			}
			else
			{
				GUI.backgroundColor = Color.white;
			}
			if (GUILayout.Button(new GUIContent("Help", this.button_help, "This shows how to navigate the map."), new GUILayoutOption[]
			{
				GUILayout.Width((float)120),
				GUILayout.Height((float)19)
			}))
			{
				this.global_script.map.button_help = !this.global_script.map.button_help;
			}
			if (this.global_script.map.button_update)
			{
				GUI.backgroundColor = Color.green;
			}
			else
			{
				GUI.backgroundColor = Color.white;
			}
			if (GUILayout.Button(new GUIContent("Update", this.button_update, "This shows the Update window. \nHere you can download and import the latest version of WorldComposer."), new GUILayoutOption[]
			{
				GUILayout.Width((float)120),
				GUILayout.Height((float)19)
			}))
			{
				this.global_script.map.button_update = !this.global_script.map.button_update;
			}
			EditorGUILayout.EndHorizontal();
			GUI.backgroundColor = Color.white;
			EditorGUILayout.BeginHorizontal(new GUILayoutOption[0]);
			EditorGUILayout.Toggle(this.global_script.map_load, new GUILayoutOption[]
			{
				GUILayout.Width((float)25)
			});
			EditorGUILayout.Toggle(this.global_script.map_load2, new GUILayoutOption[]
			{
				GUILayout.Width((float)25)
			});
			EditorGUILayout.Toggle(this.global_script.map_load3, new GUILayoutOption[]
			{
				GUILayout.Width((float)25)
			});
			EditorGUILayout.Toggle(this.global_script.map_load4, new GUILayoutOption[]
			{
				GUILayout.Width((float)25)
			});
			EditorGUILayout.EndHorizontal();
			this.gui_y += 43;
			this.wc_gui.y = (float)64;
			this.wc_gui.x = (float)0;
			this.wc_gui.column[0] = (float)3;
			this.wc_gui.column[1] = (float)(this.guiWidth1 + 3);
			if (this.global_script.map.button_image_editor)
			{
				this.image_editor_rect = new Rect((float)0, (float)this.gui_y, (float)(this.guiWidth2 + 348), (float)(109 + (this.global_script.map.preimage_edit.edit_color.Count * 19 + Convert.ToInt32(this.current_area.preimage_save_new) * 36 + this.gui_height)));
				this.drawGUIBox(this.image_editor_rect, "Combined Raw Image Editor", this.global_script.map.backgroundColor, this.global_script.map.titleColor, this.global_script.map.color);
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)this.guiWidth1, (float)18, false, true), "Color Rules", EditorStyles.boldLabel);
				this.wc_gui.y = this.wc_gui.y + (float)2;
				GUI.color = Color.white;
				if (GUI.Button(this.wc_gui.getRect(0, (float)4, (float)25, (float)15, true, false), new GUIContent("+", "Add a rule."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.preimage_edit.edit_color.Add(new image_edit_class());
					if (this.key.shift)
					{
						this.global_script.map.preimage_edit.copy_color(this.global_script.map.preimage_edit.edit_color.Count - 1, this.global_script.map.preimage_edit.edit_color.Count - 2);
					}
					this.image_generate_begin();
				}
				if (GUI.Button(this.wc_gui.getRect(0, (float)25, (float)15, true, false), new GUIContent("-", "Remove this rule."), EditorStyles.miniButtonMid) && this.global_script.map.preimage_edit.edit_color.Count > 1)
				{
					if (this.key.control)
					{
						Undo.RecordObject(this.global_script, "Erase Color Range");
						this.global_script.map.preimage_edit.edit_color.RemoveAt(this.global_script.map.preimage_edit.edit_color.Count - 1);
						this.image_generate_begin();
						this.Repaint();
						return;
					}
					this.notify_text = "Control click the '-' button to erase";
				}
				GUI.color = this.global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)2, (float)25, (float)19, true, false), "Act");
				GUI.color = Color.white;
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				this.global_script.map.preimage_edit.active = EditorGUI.Toggle(this.wc_gui.getRect(0, (float)2, (float)25, (float)19, true, true), this.global_script.map.preimage_edit.active);
				for (int n = 0; n < this.global_script.map.preimage_edit.edit_color.Count; n++)
				{
					this.wc_gui.x = (float)4;
					this.global_script.map.preimage_edit.edit_color[n].color1_start = EditorGUI.ColorField(this.wc_gui.getRect(0, (float)0, (float)55, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].color1_start);
					this.global_script.map.preimage_edit.edit_color[n].color1_end = EditorGUI.ColorField(this.wc_gui.getRect(0, (float)4, (float)55, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].color1_end);
					if (this.global_script.map.preimage_edit.edit_color[n].output != image_output_enum.content)
					{
						this.global_script.map.preimage_edit.edit_color[n].curve1 = EditorGUI.CurveField(this.wc_gui.getRect(0, (float)4, (float)50, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].curve1);
						this.global_script.map.preimage_edit.edit_color[n].solid_color = EditorGUI.Toggle(this.wc_gui.getRect(0, (float)6, (float)25, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].solid_color);
						EditorGUI.LabelField(this.wc_gui.getRect(0, (float)-4, (float)20, (float)18, true, false), "->", EditorStyles.boldLabel);
						this.global_script.map.preimage_edit.edit_color[n].color2_start = EditorGUI.ColorField(this.wc_gui.getRect(0, (float)4, (float)55, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].color2_start);
						this.global_script.map.preimage_edit.edit_color[n].color2_end = EditorGUI.ColorField(this.wc_gui.getRect(0, (float)4, (float)55, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].color2_end);
						this.global_script.map.preimage_edit.edit_color[n].curve2 = EditorGUI.CurveField(this.wc_gui.getRect(0, (float)4, (float)50, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].curve2);
						this.global_script.map.preimage_edit.edit_color[n].strength = EditorGUI.FloatField(this.wc_gui.getRect(0, (float)4, (float)50, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].strength);
						this.global_script.map.preimage_edit.edit_color[n].output = (image_output_enum)EditorGUI.EnumPopup(this.wc_gui.getRect(0, (float)4, (float)75, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].output);
						this.global_script.map.preimage_edit.edit_color[n].active = EditorGUI.Toggle(this.wc_gui.getRect(0, (float)4, (float)25, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].active);
					}
					else
					{
						this.global_script.map.preimage_edit.edit_color[n].solid_color = EditorGUI.Toggle(this.wc_gui.getRect(0, (float)6, (float)25, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].solid_color);
						GUI.color = this.global_script.map.color;
						EditorGUI.LabelField(this.wc_gui.getRect(0, (float)-4, (float)40, (float)18, true, false), "Edge", EditorStyles.boldLabel);
						GUI.color = Color.white;
						this.global_script.map.preimage_edit.edit_color[n].color2_start = EditorGUI.ColorField(this.wc_gui.getRect(0, (float)4, (float)55, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].color2_start);
						GUI.color = this.global_script.map.color;
						EditorGUI.LabelField(this.wc_gui.getRect(0, (float)2, (float)50, (float)18, true, false), "Radius", EditorStyles.boldLabel);
						GUI.color = Color.white;
						this.gui_changed_old = GUI.changed;
						GUI.changed = false;
						this.global_script.map.preimage_edit.radiusSelect = EditorGUI.IntField(this.wc_gui.getRect(0, (float)4, (float)48, (float)18, true, false), this.global_script.map.preimage_edit.radiusSelect);
						if (GUI.changed)
						{
							if (this.global_script.map.preimage_edit.radiusSelect < 50)
							{
								this.global_script.map.preimage_edit.radiusSelect = 50;
							}
							else if (this.global_script.map.preimage_edit.radiusSelect > 2000)
							{
								this.global_script.map.preimage_edit.radiusSelect = 2000;
							}
						}
						GUI.changed = this.gui_changed_old;
						GUI.color = this.global_script.map.color;
						EditorGUI.LabelField(this.wc_gui.getRect(0, (float)2, (float)55, (float)18, true, false), "Repeat", EditorStyles.boldLabel);
						GUI.color = Color.white;
						this.gui_changed_old = GUI.changed;
						GUI.changed = false;
						this.global_script.map.preimage_edit.repeatAmount = EditorGUI.IntField(this.wc_gui.getRect(0, (float)4, (float)35, (float)18, true, false), this.global_script.map.preimage_edit.repeatAmount);
						if (GUI.changed)
						{
							if (this.global_script.map.preimage_edit.repeatAmount < 2)
							{
								this.global_script.map.preimage_edit.repeatAmount = 2;
							}
							else if (this.global_script.map.preimage_edit.repeatAmount > 20)
							{
								this.global_script.map.preimage_edit.repeatAmount = 20;
							}
						}
						GUI.changed = this.gui_changed_old;
						this.global_script.map.preimage_edit.edit_color[n].output = (image_output_enum)EditorGUI.EnumPopup(this.wc_gui.getRect(0, (float)4, (float)75, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].output);
						this.global_script.map.preimage_edit.edit_color[n].active = EditorGUI.Toggle(this.wc_gui.getRect(0, (float)4, (float)25, (float)18, true, false), this.global_script.map.preimage_edit.edit_color[n].active);
					}
					if (this.global_script.map.preimage_edit.edit_color.Count > 1)
					{
						if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)25, (float)16, true, false), new GUIContent("<", "Swap this rule with previous rule."), EditorStyles.miniButtonMid) && n > 0)
						{
							this.global_script.map.preimage_edit.swap_color(n - 1, n);
							this.image_generate_begin();
							this.Repaint();
						}
						if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)25, (float)16, true, false), new GUIContent(">", "Swap this rule with next rule."), EditorStyles.miniButtonMid) && n < this.global_script.map.preimage_edit.edit_color.Count - 1)
						{
							this.global_script.map.preimage_edit.swap_color(n, n + 1);
							this.image_generate_begin();
							this.Repaint();
						}
					}
					if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)25, (float)16, true, false), new GUIContent("+", "Insert a rule."), EditorStyles.miniButtonMid))
					{
						this.global_script.map.preimage_edit.edit_color.Insert(n + 1, new image_edit_class());
						if (this.key.shift)
						{
							this.global_script.map.preimage_edit.copy_color(n + 1, n);
						}
						this.image_generate_begin();
					}
					if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)25, (float)16, true, true), new GUIContent("-", "Remove this rule."), EditorStyles.miniButtonMid) && this.global_script.map.preimage_edit.edit_color.Count > 1)
					{
						if (this.key.control)
						{
							Undo.RecordObject(this.global_script, "Erase Color Range");
							this.global_script.map.preimage_edit.edit_color.RemoveAt(n);
							this.image_generate_begin();
							this.Repaint();
							return;
						}
						this.notify_text = "Control click the '-' button to erase";
					}
					this.wc_gui.y = this.wc_gui.y + (float)3;
				}
				if (GUI.changed)
				{
					this.image_generate_begin();
				}
				GUI.changed = this.gui_changed_old;
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)23;
				this.current_area.preimage_save_new = false;
				if (!this.global_script.map.preimage_edit.generate || this.global_script.map.preimage_edit.mode != 2)
				{
					if (GUI.Button(this.wc_gui.getRect(0, (float)70, (float)18, true, false), new GUIContent("Apply", "Apply the rules to the combined raw image.")))
					{
						this.save_global_settings();
						Application.runInBackground = true;
						this.convert_area = this.current_area;
						if (this.convert_textures_begin(this.convert_area))
						{
							this.convert_area.preimage_count = 0;
						}
						return;
					}
				}
				else if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)70, (float)18, true, false), new GUIContent("Stop", "Stop the execution of the image processing.")))
				{
					Application.runInBackground = false;
                    if (global_script.map.preimage_edit.inputBuffer != null) { global_script.map.preimage_edit.inputBuffer.file.Close(); }
                    if (global_script.map.preimage_edit.outputBuffer != null) { global_script.map.preimage_edit.outputBuffer.file.Close(); }
                    this.global_script.map.preimage_edit.loop = false;
					this.global_script.map.preimage_edit.generate = false;
				}
				if (!this.global_script.map.preimage_edit.loop_active)
				{
					GUI.backgroundColor = Color.red;
				}
				if (GUI.Button(this.wc_gui.getRect(0, (float)4, (float)55, (float)16, true, false), new GUIContent("Pause", "Pause the image processing."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.preimage_edit.loop_active = !this.global_script.map.preimage_edit.loop_active;
				}
				if ((!this.global_script.map.preimage_edit.generate || this.global_script.map.preimage_edit.mode != 2) && GUI.Button(this.wc_gui.getRect(0, (float)4, (float)55, (float)16, true, false), new GUIContent("Refresh", "Refresh the preview of after image processing."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.preimage_edit.generate = false;
					this.image_generate_begin();
				}
				GUI.backgroundColor = Color.white;
				if (this.global_script.map.preimage_edit.generate && this.global_script.map.preimage_edit.mode == 2)
				{
					this.global_script.map.preimage_edit.progress = (float)this.global_script.map.preimage_edit.repeat * 1f / (float)this.global_script.map.preimage_edit.repeatAmount + (float)(this.global_script.map.preimage_edit.tile.y * this.global_script.map.preimage_edit.inputBuffer.tiles.x + this.global_script.map.preimage_edit.tile.x) * 1f / ((float)(this.global_script.map.preimage_edit.inputBuffer.tiles.x * this.global_script.map.preimage_edit.inputBuffer.tiles.y) * 1f) / ((float)this.global_script.map.preimage_edit.repeatAmount * 1f);
					EditorGUI.ProgressBar(this.wc_gui.getRect(0, (float)4, (float)521, (float)19, false, false), this.global_script.map.preimage_edit.progress, (this.global_script.map.preimage_edit.progress * (float)100).ToString("F0") + "%");
				}
				else
				{
					GUI.color = this.global_script.map.color;
				}
				if (this.global_script.map.preimage_edit.time < (float)0)
				{
					this.global_script.map.preimage_edit.time = (float)0;
				}
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)6, (float)70, (float)19, false, false), this.sec_to_timeMin(this.global_script.map.preimage_edit.time, true));
				this.wc_gui.y = this.wc_gui.y + (float)19;
			}
			else if (this.global_script.map.preimage_edit.generate && this.global_script.map.preimage_edit.mode == 2)
			{
				this.global_script.map.preimage_edit.progress = (float)this.global_script.map.preimage_edit.repeat * 1f / (float)this.global_script.map.preimage_edit.repeatAmount + (float)(this.global_script.map.preimage_edit.tile.y * this.global_script.map.preimage_edit.inputBuffer.tiles.x + this.global_script.map.preimage_edit.tile.x) * 1f / ((float)(this.global_script.map.preimage_edit.inputBuffer.tiles.x * this.global_script.map.preimage_edit.inputBuffer.tiles.y) * 1f) / ((float)this.global_script.map.preimage_edit.repeatAmount * 1f);
				EditorGUI.ProgressBar(new Rect((float)(this.guiWidth2 + 15), (float)23, (float)490, (float)19), this.global_script.map.preimage_edit.progress, (this.global_script.map.preimage_edit.progress * (float)100).ToString("F0") + "%");
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 17), (float)23, (float)100, (float)19), this.sec_to_timeMin(this.global_script.map.preimage_edit.time, true));
			}
			GUILayout.BeginArea(new Rect((float)0, (float)this.gui_y, (float)Screen.width, (float)(Screen.height - this.gui_y)));
			this.scrollPos = GUI.BeginScrollView(new Rect((float)0, (float)0, (float)(this.guiWidth2 + 15), (float)(Screen.height - this.gui_y - 23)), this.scrollPos, new Rect((float)0, (float)0, (float)this.guiWidth2, (float)(this.guiAreaHeight - 1)));
			this.gui_y = 0;
			if (this.global_script.map.button_update)
			{
				this.wc_gui.x = (float)0;
				this.wc_gui.y = (float)(this.gui_y + 20);
				this.update_rect = new Rect((float)0, (float)this.gui_y, (float)this.guiWidth2, (float)(86 + this.gui_height));
				this.drawGUIBox(this.update_rect, "Update", this.global_script.map.backgroundColor, this.global_script.map.titleColor, this.global_script.map.color);
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Updates", EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				int num8 = this.read_check();
				GUI.color = Color.white;
				this.wc_gui.y = this.wc_gui.y + (float)2;
				num8 = EditorGUI.Popup(this.wc_gui.getRect(1, (float)0, (float)206, (float)19, false, true), num8, this.global_script.settings.update);
				if (GUI.changed)
				{
					this.write_check(num8.ToString());
				}
				GUI.changed = this.gui_changed_old;
				this.wc_gui.x = (float)0;
				GUI.color = this.global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Current Version", EditorStyles.boldLabel);
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)80, (float)19, false, false), "Final " + this.read_version().ToString("F3"));
				GUI.color = Color.white;
				if (this.info_window)
				{
					GUI.backgroundColor = Color.green;
				}
				if (GUI.Button(this.wc_gui.getRect(1, (float)126, (float)80, (float)18, false, true), new GUIContent("Info", "Shows the release notes.")))
				{
					this.create_info_window();
				}
				GUI.backgroundColor = Color.white;
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)1;
				GUI.color = this.global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Available Version", EditorStyles.boldLabel);
				if (this.global_script.settings.new_version == (float)0 || this.global_script.settings.wc_loading == 1)
				{
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)80, (float)19, false, false), "---");
				}
				else
				{
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)80, (float)19, false, false), "Final " + this.global_script.settings.new_version.ToString("F3"));
				}
				if (this.global_script.settings.wc_loading == 1)
				{
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)120, (float)70, (float)16, false, false), "Checking...");
				}
				if (this.global_script.settings.wc_loading == 2)
				{
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)120, (float)70, (float)16, false, true), "Downloading...");
				}
				GUI.color = Color.white;
				if ((this.global_script.settings.wc_loading == 0 || this.global_script.settings.wc_loading == 3) && !this.global_script.settings.update_version && !this.global_script.settings.update_version2 && GUI.Button(this.wc_gui.getRect(1, (float)126, (float)80, (float)18, false, true), new GUIContent("Check Now", "Checks for the latest WorldCompose version.")))
				{
					this.check_content_version();
				}
				if (this.global_script.settings.update_version && this.global_script.settings.wc_loading == 0)
				{
					if (GUI.Button(this.wc_gui.getRect(1, (float)126, (float)80, (float)18, false, true), new GUIContent("Download", "Download the latest WorldComposer version.")))
					{
						this.content_version();
						this.global_script.settings.update_version = false;
					}
				}
				else if (this.global_script.settings.update_version2 && GUI.Button(this.wc_gui.getRect(1, (float)126, (float)80, (float)19, false, true), new GUIContent("Import", "Import the latest WorldComposer version.")))
				{
					this.import_contents(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/WorldComposer.unitypackage", true);
				}
			}
			if (this.global_script.map.button_parameters)
			{
				this.wc_gui.x = (float)0;
				this.wc_gui.y = (float)(this.gui_y + 23);
				if (this.global_script.map.key_edit)
				{
					this.gui_height += 38 + this.global_script.map.bingKey.Count * 19;
				}
				this.map_parameters_rect = new Rect((float)0, (float)this.gui_y, (float)this.guiWidth2, (float)(137 + this.gui_height));
				this.drawGUIBox(this.map_parameters_rect, "Map Parameters", this.global_script.map.backgroundColor, this.global_script.map.titleColor, this.global_script.map.color);
				if (this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls > 45000)
				{
					GUI.color = Color.red;
				}
				else
				{
					GUI.color = this.global_script.map.color;
				}
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Transactions", EditorStyles.boldLabel);
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)150, (float)19, true, false), "Key" + this.global_script.map.bingKey_selected + " = " + this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls.ToString() + " (" + this.calc_24_hours() + ")");
				GUI.color = Color.white;
				if (GUI.Button(this.wc_gui.getRect(1, (float)4, (float)42, (float)18, false, true), new GUIContent("Reset", "Reset the transaction counter for the Bing key.\nYou can use 50K transaction for 1 Bing key within 24 hours.\nIf you exceed this amount your Bing key can be blocked by Microsoft.\nYou can use multiple Bing keys if you used up one for the day."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.bingKey[this.global_script.map.bingKey_selected].reset();
				}
				this.wc_gui.x = (float)0;
				GUI.color = this.global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Map Type", EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				this.global_script.map.type = (map_type_enum)EditorGUI.EnumPopup(this.wc_gui.getRect(1, (float)0, (float)150, (float)19, true, false), this.global_script.map.type);
				if (GUI.changed)
				{
					this.request_map();
				}
				GUI.changed = this.gui_changed_old;
				if (GUI.Button(this.wc_gui.getRect(1, (float)4, (float)25, (float)16, true, false), new GUIContent("K", "This is the Bing key editor more, which allows you to view and add more Bing keys."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.key_edit = !this.global_script.map.key_edit;
				}
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				if (!this.global_script.map.active)
				{
					GUI.color = Color.red;
				}
				this.global_script.map.active = EditorGUI.Toggle(this.wc_gui.getRect(1, (float)4, (float)25, (float)19, false, true), this.global_script.map.active);
				if (GUI.changed && this.global_script.map.active)
				{
					this.request_map();
				}
				GUI.changed = gui_changed_old;
				if (this.global_script.map.key_edit)
				{
					this.wc_gui.x = (float)0;
					if (GUI.Button(this.wc_gui.getRect(0, (float)4, (float)25, (float)16, true, false), new GUIContent("+", "Add a Bing key to the end."), EditorStyles.miniButtonMid))
					{
						this.global_script.map.bingKey.Add(new map_key_class());
						this.global_script.map.bingKey[this.global_script.map.bingKey.Count - 1].key = "Enter your Key here";
						this.global_script.map.bingKey[this.global_script.map.bingKey.Count - 1].reset();
					}
					if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)25, (float)16, false, true), new GUIContent("-", "Remove the Bing key from the end."), EditorStyles.miniButtonMid) && this.global_script.map.bingKey.Count > 1)
					{
						if (this.key.control)
						{
							Undo.RecordObject(this.global_script, "Erase Bing Key");
							this.global_script.map.bingKey.RemoveAt(this.global_script.map.bingKey.Count - 1);
							this.Repaint();
							return;
						}
						this.notify_text = "Control click the '-' button to erase";
					}
					this.wc_gui.y = this.wc_gui.y + (float)3;
					for (int m = 0; m < this.global_script.map.bingKey.Count; m++)
					{
						this.wc_gui.x = (float)0;
						GUI.color = global_script.map.color;
						EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Bing Key " + m.ToString() + " ->", EditorStyles.boldLabel);
						GUI.color = Color.white;
						this.global_script.map.bingKey[m].key = EditorGUI.TextField(this.wc_gui.getRect(1, (float)0, (float)170, (float)18, true, false), this.global_script.map.bingKey[m].key);
						this.wc_gui.y = this.wc_gui.y + (float)1;
						if (GUI.Button(this.wc_gui.getRect(1, (float)4, (float)25, (float)16, false, true), new GUIContent("-", "Remove this Bing key."), EditorStyles.miniButtonMid) && this.global_script.map.bingKey.Count > 1)
						{
							if (this.key.control)
							{
								Undo.RecordObject(this.global_script, "Erase Bing Key");
								this.global_script.map.bingKey.RemoveAt(m);
								this.Repaint();
								return;
							}
							this.notify_text = "Control click the '-' button to erase";
						}
						this.wc_gui.y = this.wc_gui.y + (float)3;
					}
					this.wc_gui.x = (float)0;
					GUI.color = global_script.map.color;
					EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Key Selected", EditorStyles.boldLabel);
					GUI.color = Color.white;
					this.global_script.map.bingKey_selected = EditorGUI.IntField(this.wc_gui.getRect(1, (float)0, (float)50, (float)18, false, true), this.global_script.map.bingKey_selected);
					this.wc_gui.y = this.wc_gui.y + (float)1;
					if (this.global_script.map.bingKey_selected > this.global_script.map.bingKey.Count - 1)
					{
						this.global_script.map.bingKey_selected = this.global_script.map.bingKey.Count - 1;
					}
					if (this.global_script.map.bingKey_selected < 0)
					{
						this.global_script.map.bingKey_selected = 0;
					}
				}
				GUI.color = global_script.map.color;
				this.wc_gui.x = (float)0;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Latitude ", EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				if (this.global_script.map.manual_edit)
				{
					GUI.color = Color.white;
					this.latlong_center.latitude = (double)EditorGUI.FloatField(this.wc_gui.getRect(1, (float)0, (float)150, (float)19, false, false), (float)this.latlong_center.latitude);
				}
				else
				{
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)150, (float)19, false, false), this.latlong_center.latitude.ToString("F7"));
				}
				if (GUI.changed)
				{
					this.global_script.map_latlong_center = this.latlong_center;
				}
				GUI.changed = gui_changed_old;
				GUI.color = Color.white;
				if (GUI.Button(this.wc_gui.getRect(0, (float)(this.guiWidth1 + 154), (float)25, (float)16, false, true), new GUIContent("E", "Type in a manual latitude/longitude to go to that location on the map."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.manual_edit = !this.global_script.map.manual_edit;
				}
				this.wc_gui.y = this.wc_gui.y + (float)3;
				this.wc_gui.x = (float)0;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Longitude ", EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				if (this.global_script.map.manual_edit)
				{
					GUI.color = Color.white;
					this.latlong_center.longitude = (double)EditorGUI.FloatField(this.wc_gui.getRect(1, (float)0, (float)150, (float)19, false, true), (float)this.latlong_center.longitude);
				}
				else
				{
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)150, (float)19, false, true), this.latlong_center.longitude.ToString("F7"));
				}
				if (GUI.changed)
				{
					this.global_script.map_latlong_center = this.latlong_center;
				}
				GUI.changed = gui_changed_old;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Zoom ", EditorStyles.boldLabel);
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)400, (float)19, false, true), this.zoom.ToString("F2"));
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Mouse ", EditorStyles.boldLabel);
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)400, (float)19, false, true), this.latlong_mouse.latitude.ToString("F5") + ", " + this.latlong_mouse.longitude.ToString("F5"));
			}
			if (this.global_script.map.button_region)
			{
				this.wc_gui.x = (float)0;
				this.wc_gui.y = (float)(this.gui_y + 23);
				if (this.global_script.map.region_popup_edit)
				{
					this.gui_height += 19;
				}
				this.regions_rect = new Rect((float)0, (float)this.gui_y, (float)this.guiWidth2, (float)(63 + this.gui_height));
				this.drawGUIBox(this.regions_rect, "Regions", this.global_script.map.backgroundColor, this.global_script.map.titleColor, this.global_script.map.color);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				this.global_script.map.region_select = EditorGUI.Popup(this.wc_gui.getRect(0, (float)0, (float)(this.guiWidth1 + 126), (float)19, true, false), this.global_script.map.region_select, this.global_script.map.region_popup);
				if (GUI.changed)
				{
					GUI.FocusControl("GoButton");
				}
				GUI.changed = gui_changed_old;
				if (GUI.Button(this.wc_gui.getRect(0, (float)4, (float)25, (float)16, true, false), new GUIContent("E", "Rename this region name."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.region_popup_edit = !this.global_script.map.region_popup_edit;
					if (!this.global_script.map.region_popup_edit)
					{
						GUI.FocusControl("GoButton");
					}
				}
				if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)25, (float)16, true, false), new GUIContent("+", "Add a new region.\nThe location of the region will be that of the current center location on the map."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.region.Add(new map_region_class(this.global_script.map.region.Count + 1));
					this.global_script.map.region[this.global_script.map.region.Count - 1].center = this.global_script.map_latlong_center;
					this.global_script.map.region_select = this.global_script.map.region.Count - 1;
					this.global_script.map.make_region_popup();
					this.current_region = this.global_script.map.region[this.global_script.map.region.Count - 1];
					this.add_area(this.current_region, 0, "Untitled");
				}
				if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)25, (float)16, false, true), new GUIContent("-", "Remove this region."), EditorStyles.miniButtonMid) && this.global_script.map.region.Count > 1)
				{
					if (this.key.control)
					{
						Undo.RecordObject(this.global_script, "Region Erase");
						this.global_script.map.region.RemoveAt(this.global_script.map.region_select);
						if (this.global_script.map.region_select > 0)
						{
							this.global_script.map.region_select = this.global_script.map.region_select - 1;
						}
						this.current_region = this.global_script.map.region[this.global_script.map.region_select];
						this.global_script.map.make_region_popup();
						this.Repaint();
						return;
					}
					this.notify_text = "Control click the '-' button to erase";
				}
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)3;
				if (this.global_script.map.disable_region_popup_edit && this.key.type == EventType.Layout)
				{
					this.global_script.map.disable_region_popup_edit = false;
					this.global_script.map.region_popup_edit = false;
					GUI.UnfocusWindow();
					this.Repaint();
				}
				if (this.global_script.map.region_popup_edit)
				{
					this.gui_changed_old = GUI.changed;
					GUI.changed = false;
					GUI.color = Color.white;
					this.current_region.name = EditorGUI.TextField(this.wc_gui.getRect(0, (float)2, (float)210, (float)19, false, true), this.current_region.name);
					if (GUI.changed)
					{
						if (this.current_region.name == string.Empty)
						{
							this.current_region.name = "Untitled" + this.global_script.map.region_select.ToString();
						}
						this.global_script.map.make_region_popup();
					}
					GUI.changed = gui_changed_old;
					if (this.key.keyCode == KeyCode.Return)
					{
						this.global_script.map.disable_region_popup_edit = true;
						GUI.FocusControl("GoButton");
					}
				}
				GUI.color = global_script.map.color;
				this.wc_gui.x = (float)0;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Lat/Long", EditorStyles.boldLabel);
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)122, (float)19, true, false), this.current_region.center.latitude.ToString("F4") + ", " + this.current_region.center.longitude.ToString("F4"));
				GUI.SetNextControlName("GoButton");
				GUI.color = Color.white;
				if (GUI.Button(this.wc_gui.getRect(1, (float)8, (float)30, (float)16, true, false), new GUIContent("Go", "Set the center location on the map to the location of this region."), EditorStyles.miniButtonMid))
				{
					this.stop_download();
					this.latlong_animate = this.current_region.center;
					this.animate_time_start = Time.realtimeSinceStartup;
					this.animate = true;
				}
				if (GUI.Button(this.wc_gui.getRect(1, (float)0, (float)45, (float)16, false, true), new GUIContent("<Set>", "Set the location of the region to the current center location of the map."), EditorStyles.miniButtonMid) && this.key.shift)
				{
					this.current_region.center = this.global_script.map_latlong_center;
				}
				this.wc_gui.y = this.wc_gui.y + (float)30;
				if (this.global_script.map.area_popup_edit)
				{
					this.gui_height = 19;
				}
				this.areas_rect = new Rect((float)0, (float)this.gui_y, (float)(this.guiWidth2 + 1), (float)(155 + this.gui_height));
				if (this.current_area.manual_area)
				{
					this.areas_rect.height = this.areas_rect.height + (float)80;
				}
				this.drawGUIBox(this.areas_rect, "Areas", this.global_script.map.backgroundColor, this.global_script.map.titleColor, this.global_script.map.color);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				this.wc_gui.x = (float)0;
				this.current_region.area_select = EditorGUI.Popup(this.wc_gui.getRect(0, (float)0, (float)(this.guiWidth1 + 126), (float)19, true, false), this.current_region.area_select, this.current_region.area_popup);
				if (GUI.changed)
				{
					GUI.FocusControl("GoButton2");
				}
				GUI.changed = gui_changed_old;
				if (GUI.Button(this.wc_gui.getRect(0, (float)4, (float)25, (float)16, true, false), new GUIContent("E", "Change this area name"), EditorStyles.miniButtonMid))
				{
					this.global_script.map.area_popup_edit = !this.global_script.map.area_popup_edit;
					if (!this.global_script.map.area_popup_edit)
					{
						GUI.FocusControl("GoButton2");
					}
				}
				if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)25, (float)16, true, false), new GUIContent("+", "Add a new area."), EditorStyles.miniButtonMid))
				{
					this.add_area(this.current_region, this.current_region.area.Count - 1, "Untitled");
				}
				if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)25, (float)16, false, true), new GUIContent("-", "Remove this area."), EditorStyles.miniButtonMid) && this.current_region.area.Count > 1)
				{
					if (this.key.control)
					{
						Undo.RecordObject(this.global_script, "Area Erase");
						this.current_region.area.RemoveAt(this.current_region.area_select);
						if (this.current_region.area_select > 0)
						{
							this.current_region.area_select = this.current_region.area_select - 1;
						}
						this.current_region.make_area_popup();
						this.Repaint();
						return;
					}
					this.notify_text = "Control click the '-' button to erase";
				}
				this.wc_gui.y = this.wc_gui.y + (float)3;
				if (this.global_script.map.disable_area_popup_edit && this.key.type == EventType.Layout)
				{
					this.global_script.map.disable_area_popup_edit = false;
					this.global_script.map.area_popup_edit = false;
					GUI.UnfocusWindow();
					this.Repaint();
				}
				if (this.current_region.area.Count > 0)
				{
					if (this.global_script.map.area_popup_edit)
					{
						this.gui_changed_old = GUI.changed;
						GUI.changed = false;
						GUI.color = Color.white;
						this.wc_gui.x = (float)0;
						this.current_area.name = EditorGUI.TextField(this.wc_gui.getRect(0, (float)2, (float)210, (float)19, false, true), this.current_area.name);
						if (GUI.changed)
						{
							if (current_area.name == string.Empty)
							{
								this.current_area.name = "Untitled" + this.current_region.area_select.ToString();
							}
							this.current_region.make_area_popup();
							if (!this.current_area.preimage_path_changed)
							{
								this.current_area.preimage_path = this.current_area.name;
							}
							if (!this.current_area.export_heightmap_changed)
							{
								this.current_area.export_heightmap_filename = this.current_area.name;
							}
							if (!this.current_area.export_image_changed)
							{
								this.current_area.export_image_filename = this.current_area.name;
							}
							if (!this.current_area.export_terrain_changed)
							{
								this.current_area.terrain_scene_name = "_" + this.current_area.name;
								this.current_area.terrain_scene_name = this.current_area.name;
							}
						}
						GUI.changed = gui_changed_old;
						if (this.key.keyCode == KeyCode.Return)
						{
							this.global_script.map.disable_area_popup_edit = true;
							GUI.FocusControl("GoButton2");
						}
						GUI.color = global_script.map.color;
					}
					this.wc_gui.x = (float)0;
					GUI.color = global_script.map.color;
					EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Center", EditorStyles.boldLabel);
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)122, (float)19, true, false), this.current_area.center.latitude.ToString("G6") + ", " + this.current_area.center.longitude.ToString("G6"));
					GUI.SetNextControlName("GoButton");
					GUI.color = Color.white;
					if (GUI.Button(this.wc_gui.getRect(1, (float)8, (float)30, (float)16, true, false), new GUIContent("Go", "Set the center location on the map to the center of this area."), EditorStyles.miniButtonMid))
					{
						if (this.current_area.tiles.x != 0 && this.current_area.tiles.y != 0)
						{
							this.stop_download();
							this.latlong_animate = this.current_area.center;
							this.animate_time_start = Time.realtimeSinceStartup;
							this.animate = true;
						}
						else
						{
							this.notify_text = "The area is not created. Use the 'Pick' button to create an area";
						}
					}
					if (GUI.Button(this.wc_gui.getRect(1, (float)0, (float)45, (float)16, false, true), new GUIContent("<Set>", "Set the center of the area to the center location on the map."), EditorStyles.miniButtonMid))
					{
						if (this.key.shift)
						{
							if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
							{
								this.global_script.calc_latlong_area_from_center(this.current_area, this.latlong_center, (double)this.current_area.image_zoom, new Vector2((float)(this.current_area.resolution * this.current_area.tiles.x), (float)(this.current_area.resolution * this.current_area.tiles.y)));
							}
							else
							{
								this.notify_text = "It is not possible to relocate the area while exporting";
							}
						}
						else
						{
							this.notify_text = "Shift click <Set> to change center of area to center of current map view";
						}
					}
					GUI.color = global_script.map.color;
					this.wc_gui.x = (float)0;
					this.wc_gui.y = this.wc_gui.y + (float)3;
					EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Upper Left", EditorStyles.boldLabel);
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)this.guiWidth1, (float)19, true, false), this.current_area.upper_left.latitude.ToString("G6") + ", " + this.current_area.upper_left.longitude.ToString("G6"));
					GUI.color = Color.white;
					GUI.SetNextControlName("GoButton");
					if (GUI.Button(this.wc_gui.getRect(1, (float)10, (float)30, (float)16, true, false), new GUIContent("Go", "Set the center location on the map to this area upper left location."), EditorStyles.miniButtonMid))
					{
						if (this.current_area.tiles.x != 0 && this.current_area.tiles.y != 0)
						{
							this.stop_download();
							this.latlong_animate = this.current_area.upper_left;
							this.animate_time_start = Time.realtimeSinceStartup;
							this.animate = true;
						}
						else
						{
							this.notify_text = "The area is not created. Use the 'Pick' button to create an area";
						}
					}
					if (this.global_script.map.mode == 1)
					{
						GUI.backgroundColor = Color.green;
					}
					else if (this.current_area.tiles.x == 0 && this.current_area.tiles.y == 0)
					{
						GUI.backgroundColor = Color.red;
					}
					if (GUI.Button(this.wc_gui.getRect(1, (float)0, (float)45, (float)16, false, true), new GUIContent("Pick", "Select a new location for this area.\nFirst mouse click is for the upper left location of the area.\nSecond mouse click is for the lower right location of the area."), EditorStyles.miniButtonMid))
					{
						if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
						{
							if (this.global_script.map.mode != 1)
							{
								this.global_script.map.mode = 1;
							}
							else
							{
								this.global_script.map.mode = 0;
								if (this.current_area.select == 1)
								{
									this.pick_done();
								}
							}
						}
						else
						{
							this.notify_text = "It is not possible to repick the area while exporting";
						}
					}
					this.wc_gui.x = (float)0;
					this.wc_gui.y = this.wc_gui.y + (float)3;
					GUI.backgroundColor = Color.white;
					if (this.current_area.manual_area)
					{
						GUI.color = global_script.map.color;
						EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Latitude", EditorStyles.boldLabel);
						GUI.color = Color.white;
						this.current_area.upper_left.latitude = (double)EditorGUI.FloatField(this.wc_gui.getRect(1, (float)0, (float)160, (float)19, false, true), (float)this.current_area.upper_left.latitude);
						this.wc_gui.x = (float)0;
						GUI.color = global_script.map.color;
						EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Longitude", EditorStyles.boldLabel);
						GUI.color = Color.white;
						this.current_area.upper_left.longitude = (double)EditorGUI.FloatField(this.wc_gui.getRect(1, (float)0, (float)160, (float)19, false, true), (float)this.current_area.upper_left.longitude);
					}
					this.wc_gui.x = (float)0;
					GUI.color = global_script.map.color;
					EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Lower Right", EditorStyles.boldLabel);
					if (this.current_area.lower_right.latitude > this.current_area.upper_left.latitude)
					{
						this.current_area.lower_right.latitude = this.current_area.upper_left.latitude;
					}
					if (this.current_area.lower_right.longitude < this.current_area.upper_left.longitude)
					{
						this.current_area.lower_right.longitude = this.current_area.upper_left.longitude;
					}
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)122, (float)19, true, false), this.current_area.lower_right.latitude.ToString("G6") + ", " + this.current_area.lower_right.longitude.ToString("G6"));
					GUI.SetNextControlName("GoButton");
					GUI.color = Color.white;
					if (GUI.Button(this.wc_gui.getRect(1, (float)8, (float)30, (float)16, true, false), new GUIContent("Go", "Set the center location of the map to the lower right location of this area."), EditorStyles.miniButtonMid))
					{
						if (this.current_area.tiles.x != 0 && this.current_area.tiles.y != 0)
						{
							this.stop_download();
							this.latlong_animate = this.current_area.lower_right;
							this.animate_time_start = Time.realtimeSinceStartup;
							this.animate = true;
						}
						else
						{
							this.notify_text = "The area is not created. Use the 'Pick' button to create an area";
						}
					}
					if (this.global_script.map.mode == 2)
					{
						GUI.backgroundColor = Color.green;
					}
					if (GUI.Button(this.wc_gui.getRect(1, (float)0, (float)45, (float)16, false, true), new GUIContent("Resize", "Resize this area."), EditorStyles.miniButtonMid))
					{
						if (this.global_script.map.mode == 1)
						{
							this.notify_text = "Fist click 1 more time in the WC map to select the lower right of your area.";
						}
						else if (this.current_area.created)
						{
							if (this.global_script.map.mode == 2)
							{
								this.global_script.map.mode = 0;
							}
							else
							{
								this.global_script.map.mode = 2;
							}
						}
						else
						{
							this.notify_text = "You need to create an area first with 'Pick'";
						}
					}
					GUI.backgroundColor = Color.white;
					GUI.color = global_script.map.color;
					this.wc_gui.y = this.wc_gui.y + (float)3;
					if (this.current_area.manual_area)
					{
						this.wc_gui.x = (float)0;
						GUI.color = global_script.map.color;
						EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Latitude", EditorStyles.boldLabel);
						GUI.color = Color.white;
						this.current_area.lower_right.latitude = (double)EditorGUI.FloatField(this.wc_gui.getRect(1, (float)0, (float)160, (float)16, false, true), (float)this.current_area.lower_right.latitude);
						this.wc_gui.x = (float)0;
						GUI.color = global_script.map.color;
						EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Longitude", EditorStyles.boldLabel);
						GUI.color = Color.white;
						this.current_area.lower_right.longitude = (double)EditorGUI.FloatField(this.wc_gui.getRect(1, (float)0, (float)160, (float)19, false, true), (float)this.current_area.lower_right.longitude);
					}
					GUI.color = global_script.map.color;
					this.wc_gui.x = (float)0;
					EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Size", EditorStyles.boldLabel);
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)152, (float)19, true, false), (this.current_area.size.x / (double)1000).ToString("F2") + "(km), " + (this.current_area.size.y / (double)1000).ToString("F2") + "(km)");
					GUI.color = Color.white;
					if (GUI.Button(this.wc_gui.getRect(1, (float)8, (float)45, (float)16, false, true), new GUIContent("Edit", "Edit the size of the area with manually entering latitue and longitude."), EditorStyles.miniButtonMid))
					{
						this.current_area.manual_area = !this.current_area.manual_area;
					}
					this.wc_gui.x = (float)0;
					this.wc_gui.y = this.wc_gui.y + (float)3;
					GUI.color = global_script.map.color;
					EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Height Center", EditorStyles.boldLabel);
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)150, (float)19, false, true), this.current_area.center_height.ToString() + " (m)");
					this.wc_gui.x = (float)0;
					EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Heightmap Data", EditorStyles.boldLabel);
					EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)150, (float)19, false, true), this.current_area.elevation_zoom.ToString() + " -> " + this.current_area.heightmap_scale.ToString("F2") + " (m/p)");
				}
			}
			if (this.global_script.map.button_heightmap_export)
			{
				this.wc_gui.x = (float)0;
				this.wc_gui.y = (float)(this.gui_y + 23);
				this.heightmap_export_rect = new Rect((float)0, (float)this.gui_y, (float)(this.guiWidth2 + 1), (float)(184 + this.gui_height));
				this.drawGUIBox(this.heightmap_export_rect, "Heightmap Export", this.global_script.map.backgroundColor, this.global_script.map.titleColor, this.global_script.map.color);
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Heightmap Zoom", EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				this.current_area.heightmap_zoom = EditorGUI.IntField(this.wc_gui.getRect(1, (float)2, (float)60, (float)19, true, false), this.current_area.heightmap_zoom);
				if (GUI.Button(this.wc_gui.getRect(1, (float)4, (float)25, (float)16, true, false), new GUIContent("+", "Increase the heightmap zoom level.\nThis increases the heightmap size (resolution)."), EditorStyles.miniButtonMid))
				{
					if (!this.current_area.export_heightmap_active)
					{
						this.current_area.heightmap_zoom = this.current_area.heightmap_zoom + 1;
						GUI.changed = true;
					}
					else
					{
						this.notify_text = "It is not possible to change heightmap resolution while exporting";
					}
				}
				if (GUI.Button(this.wc_gui.getRect(1, (float)0, (float)25, (float)16, true, false), new GUIContent("-", "Lower the heightmap zoom level.\nThis lower the heightmap size (resolution)."), EditorStyles.miniButtonMid))
				{
					if (!this.current_area.export_heightmap_active)
					{
						this.current_area.heightmap_zoom = this.current_area.heightmap_zoom - 1;
						GUI.changed = true;
					}
					else
					{
						this.notify_text = "It is not possible to change heightmap resolution while exporting";
					}
				}
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)12, (float)50, (float)19, true, false), new GUIContent("Manual", "Override the maximum heightmap zoom level of what Bing provides.\nThis can be used if inside the area is a more detailed resultion than the center of the area, as the maximum is sampled from the center from the area."));
				GUI.color = Color.white;
				this.current_area.heightmap_manual = EditorGUI.Toggle(this.wc_gui.getRect(1, (float)0, (float)50, (float)19, false, true), string.Empty, this.current_area.heightmap_manual);
				this.wc_gui.y = this.wc_gui.y + (float)3;
				if (GUI.changed)
				{
					if (this.current_area.heightmap_zoom < 1)
					{
						this.current_area.heightmap_zoom = 1;
					}
					else if (this.current_area.heightmap_zoom > this.current_area.elevation_zoom && !this.current_area.heightmap_manual)
					{
						this.current_area.heightmap_zoom = this.current_area.elevation_zoom;
					}
					this.calc_heightmap_settings(this.current_area);
					if (!this.current_area.terrain_heightmap_resolution_changed)
					{
						this.calc_terrain_heightmap_resolution();
					}
				}
				GUI.changed = gui_changed_old;
				this.wc_gui.x = (float)0;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Heightmap Size", EditorStyles.boldLabel);
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)400, (float)19, false, true), this.current_area.heightmap_resolution.x.ToString() + "x" + this.current_area.heightmap_resolution.y.ToString() + "  (" + this.current_area.heightmap_resolution.x * this.current_area.heightmap_resolution.y / (float)1024 + " transactions)");
				this.wc_gui.x = (float)0;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Export Path", EditorStyles.boldLabel);
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)(this.guiWidth1 + 19), (float)19, true, false), new GUIContent(this.current_area.export_heightmap_path, this.current_area.export_heightmap_path));
				GUI.color = Color.white;
				if (GUI.Button(this.wc_gui.getRect(1, (float)5, (float)61, (float)18, false, true), new GUIContent("Change", "Change the folder where the heightmap is saved to.")))
				{
					if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
					{
						if (this.current_area.export_heightmap_path.Length == 0)
						{
							this.current_area.export_heightmap_path = Application.dataPath;
						}
						this.path_old = this.current_area.export_heightmap_path;
						if (!this.key.shift)
						{
							this.current_area.export_heightmap_path = EditorUtility.OpenFolderPanel("Export Heightmap Path", this.current_area.export_heightmap_path, string.Empty);
							if (this.current_area.export_heightmap_path.Length == 0)
							{
								this.current_area.export_heightmap_path = this.path_old;
							}
						}
						else
						{
							this.current_area.export_heightmap_path = Application.dataPath;
						}
						if (this.path_old != this.current_area.export_heightmap_path)
						{
							if (this.current_area.export_heightmap_path.IndexOf(Application.dataPath) == -1)
							{
								this.notify_text = "The path should be inside your Unity project. Reselect your path.";
								this.current_area.export_heightmap_path = Application.dataPath;
							}
							this.current_area.export_heightmap_changed = true;
							if (!this.current_area.preimage_path_changed)
							{
								this.current_area.preimage_path = this.current_area.export_heightmap_path;
							}
							if (!this.current_area.export_image_changed)
							{
								this.current_area.export_image_path = this.current_area.export_heightmap_path;
							}
							if (!this.current_area.export_terrain_changed)
							{
								this.current_area.export_terrain_path = this.current_area.export_heightmap_path + "/Terrains";
							}
						}
					}
					else
					{
						this.notify_text = "It is not possible to change an export folder while exporting.";
					}
				}
				GUI.color = global_script.map.color;
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)1;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Offset", EditorStyles.boldLabel);
				this.wc_gui.x = this.wc_gui.x + (float)(this.guiWidth1 - 17);
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)15, (float)19, true, false), "X");
				GUI.color = Color.white;
				this.current_area.heightmap_offset_e.x = (float)EditorGUI.IntField(this.wc_gui.getRect(0, (float)4, (float)45, (float)18, true, false), (int)this.current_area.heightmap_offset_e.x);
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)4, (float)15, (float)19, true, false), "Y");
				GUI.color = Color.white;
				this.current_area.heightmap_offset_e.y = (float)EditorGUI.IntField(this.wc_gui.getRect(0, (float)4, (float)45, (float)18, true, false), (int)this.current_area.heightmap_offset_e.y);
				GUI.color = global_script.map.color;
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)19;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Heightmap File", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
				{
					this.current_area.export_heightmap_filename = EditorGUI.TextField(this.wc_gui.getRect(1, (float)2, (float)(this.guiWidth1 + 21), (float)18, true, false), this.current_area.export_heightmap_filename);
				}
				else
				{
					EditorGUI.TextField(this.wc_gui.getRect(1, (float)2, (float)(this.guiWidth1 + 21), (float)18, true, false), this.current_area.export_heightmap_filename);
				}
				if (GUI.changed)
				{
					this.current_area.export_heightmap_changed = true;
					if (!this.current_area.export_image_changed)
					{
						this.current_area.export_image_filename = this.current_area.export_heightmap_filename;
					}
					if (!this.current_area.terrain_name_changed)
					{
						this.current_area.terrain_scene_name = "_" + this.current_area.export_heightmap_filename;
						this.current_area.terrain_scene_name = this.current_area.export_heightmap_filename;
					}
				}
				GUI.changed = false;
				this.current_area.export_heightmap_changed = EditorGUI.Toggle(this.wc_gui.getRect(1, (float)4, (float)25, (float)19, true, false), this.current_area.export_heightmap_changed);
				if (GUI.changed && !this.current_area.export_heightmap_changed)
				{
					this.current_area.export_heightmap_path = this.current_area.export_image_path;
					this.current_area.export_heightmap_filename = this.current_area.export_image_filename;
				}
				GUI.changed = gui_changed_old;
				if (this.global_script.map.path_display)
				{
					if (GUI.Button(this.wc_gui.getRect(1, (float)8, (float)25, (float)16, false, true), new GUIContent("<", "Hide the full path text of where the heightmap is stored into."), EditorStyles.miniButtonMid))
					{
						this.global_script.map.path_display = false;
					}
				}
				else if (GUI.Button(this.wc_gui.getRect(1, (float)8, (float)25, (float)16, false, true), new GUIContent(">", "Show the full path text of where the heightmap is stored into."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.path_display = true;
				}
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)3;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), new GUIContent("Threads", "The amount of download threads that run at the same time.\nA heightmap is downloaded in small blocks, each block represent a download thread."), EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
				{
					this.global_script.map.export_elExt = EditorGUI.IntField(this.wc_gui.getRect(1, (float)2, (float)60, (float)18, false, true), this.global_script.map.export_elExt);
				}
				else
				{
					EditorGUI.IntField(this.wc_gui.getRect(1, (float)2, (float)60, (float)18, false, true), this.global_script.map.export_elExt);
					if (GUI.changed)
					{
						this.notify_text = "It is not possible to change image zoom while exporting";
					}
				}
				if (GUI.changed)
				{
					if (this.global_script.map.export_elExt < 1)
					{
						this.global_script.map.export_elExt = 1;
					}
					else if (this.global_script.map.export_elExt > 128)
					{
						this.global_script.map.export_elExt = 128;
					}
				}
				GUI.changed = gui_changed_old;
				string text = "Export\n Heightmap";
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)4;
				if (this.current_area.export_heightmap_active || this.current_area.export_heightmap_call)
				{
					text = "Stop";
				}
				GUI.color = Color.white;
				if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)38, false, false), new GUIContent(text, "This button is for starting/stopping the exporting of the heigthmap.")))
				{
					if (this.current_area.tiles.x == 0 && this.current_area.tiles.y == 0)
					{
						this.notify_text = "The area is not created. Use the 'Pick' button to create an area";
						return;
					}
					if (!this.area_rounded)
					{
						this.notify_text = "The area tiles are not rounded. Please resize the area";
						this.global_script.map.mode = 2;
					}
					else if (this.key.shift)
					{
						this.save_global_settings();
						this.start_elevation_pull_region(this.current_region);
					}
					else if (this.key.control)
					{
						this.stop_all_elevation_pull();
					}
					else
					{
						this.save_global_settings();
						this.start_elevation_pull(this.current_region, this.current_area);
					}
				}
				if (!this.global_script.map.export_heightmap_continue)
				{
					GUI.backgroundColor = Color.red;
				}
				if (GUI.Button(this.wc_gui.getRect(1, (float)3, (float)45, (float)16, true, false), new GUIContent("Pause", "Will pause the export of the heightmap."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.export_heightmap_continue = !this.global_script.map.export_heightmap_continue;
				}
				GUI.backgroundColor = Color.white;
				GUI.color = Color.white;
				if (this.global_script.map.export_heightmap_active)
				{
					this.global_script.map.export_heightmap.progress = ((float)this.global_script.map.export_heightmap.tile.x * 1f + (float)(this.global_script.map.export_heightmap.tile.y * this.global_script.map.export_heightmap.tiles.x) * 1f) / ((float)(this.global_script.map.export_heightmap.tiles.x * this.global_script.map.export_heightmap.tiles.y) * 1f);
					EditorGUI.ProgressBar(this.wc_gui.getRect(1, (float)4, (float)153, (float)19, false, false), this.global_script.map.export_heightmap.progress, (this.global_script.map.export_heightmap.progress * (float)100).ToString("F0") + "%");
				}
				else
				{
					GUI.color = global_script.map.color;
				}
				if (this.global_script.map.export_heightmap_timeEnd - this.global_script.map.export_heightmap_timeStart < (float)0)
				{
					this.global_script.map.export_heightmap_timeEnd = (this.global_script.map.export_heightmap_timeStart = (float)0);
				}
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)4, (float)100, (float)19, false, true), this.sec_to_timeMin(this.global_script.map.export_heightmap_timeEnd - this.global_script.map.export_heightmap_timeStart, true));
				this.wc_gui.x = (float)0;
				GUI.color = Color.white;
				if (File.Exists(this.current_area.export_heightmap_path + "/" + this.current_area.export_heightmap_filename + ".Raw") && fs == null && GUI.Button(this.wc_gui.getRect(1, (float)3, (float)75, (float)16, false, false), new GUIContent("Normalize", "This normalizes the heightmap.\nIn the heightmap, it will make the lowest height the black color and the highest height the white color.")))
				{
					this.current_area.normalizedHeight = this.NormalizeHeightmap(this.current_area.heightmap_resolution, this.current_area.export_heightmap_path + "/" + this.current_area.export_heightmap_filename + ".Raw");
				}
			}
			if (this.current_area.image_changed)
			{
				if (!this.current_area.terrain_heightmap_resolution_changed)
				{
					this.calc_terrain_heightmap_resolution();
				}
				this.current_area.image_changed = false;
			}
			if (this.global_script.map.button_image_export)
			{
				this.wc_gui.x = (float)0;
				this.wc_gui.y = (float)(this.gui_y + 23);
				if (this.global_script.map.export_jpg)
				{
					this.gui_height += 19;
				}
				if (this.global_script.map.export_raw)
				{
					this.gui_height += 23;
				}
				this.image_export_rect = new Rect((float)0, (float)this.gui_y, (float)(this.guiWidth2 + 1), (float)(243 + this.gui_height));
				this.drawGUIBox(this.image_export_rect, "Image Export", this.global_script.map.backgroundColor, this.global_script.map.titleColor, this.global_script.map.color);
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), new GUIContent("Image Zoom", "Higher the image zoom level.\nThis create more terrain tiles."), EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				this.current_area.image_zoom = EditorGUI.IntField(this.wc_gui.getRect(1, (float)2, (float)60, (float)18, true, false), this.current_area.image_zoom);
				if (GUI.Button(this.wc_gui.getRect(1, (float)4, (float)25, (float)16, true, false), "+", EditorStyles.miniButtonMid))
				{
					if (!this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
					{
						this.current_area.image_zoom = this.current_area.image_zoom + 1;
						GUI.changed = true;
					}
					else
					{
						this.notify_text = "It is not possible to change image zoom while exporting";
					}
				}
				if (GUI.Button(this.wc_gui.getRect(1, (float)0, (float)25, (float)16, true, true), new GUIContent("-", "Lower the image zoom level.\nThis lowers the amount of terrain tiles."), EditorStyles.miniButtonMid))
				{
					if (!this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
					{
						this.current_area.image_zoom = this.current_area.image_zoom - 1;
						GUI.changed = true;
					}
					else
					{
						this.notify_text = "It is not possible to change image zoom while exporting";
					}
				}
				if (GUI.changed)
				{
					if (this.current_area.image_zoom < 1)
					{
						this.current_area.image_zoom = 1;
					}
					else if (this.current_area.image_zoom > 19)
					{
						this.current_area.image_zoom = 19;
					}
					this.current_area.image_changed = true;
					this.check_area_resize();
				}
				GUI.changed = gui_changed_old;
				this.wc_gui.y = this.wc_gui.y + (float)3;
				this.wc_gui.x = (float)0;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Resolution", EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)60, (float)19, true, false), this.current_area.resolution.ToString());
				GUI.color = Color.white;
				if (GUI.Button(this.wc_gui.getRect(1, (float)6, (float)25, (float)16, true, false), new GUIContent("+", "This highers the image resolution."), EditorStyles.miniButtonMid))
				{
					if (!this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
					{
						this.current_area.resolution = this.current_area.resolution * 2;
						GUI.changed = true;
					}
					else
					{
						this.notify_text = "It is not possible to change image resolution while exporting";
					}
				}
				if (GUI.Button(this.wc_gui.getRect(1, (float)0, (float)25, (float)16, false, true), new GUIContent("-", "This lowers the image resolution."), EditorStyles.miniButtonMid))
				{
					if (!this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
					{
						this.current_area.resolution = this.current_area.resolution / 2;
						GUI.changed = true;
					}
					else
					{
						this.notify_text = "It is not possible to change image resolution while exporting";
					}
				}
				if (GUI.changed)
				{
					if (this.current_area.resolution < 512)
					{
						this.current_area.resolution = 512;
					}
					this.check_area_resize();
				}
				GUI.changed = gui_changed_old;
				if (this.current_area.resolution > 8192 && (this.global_script.map.export_jpg || this.global_script.map.export_png))
				{
					this.current_area.resolution = 8192;
				}
				if (!this.current_area.maxTextureSize_changed)
				{
					if (this.current_area.resolution > 4096)
					{
						this.current_area.maxTextureSize = 4096;
						this.current_area.maxTextureSize_select = 7;
					}
					else
					{
						this.current_area.maxTextureSize = this.current_area.resolution;
						this.current_area.maxTextureSize_select = (int)(Mathf.Log((float)this.current_area.maxTextureSize, (float)2) - (float)5);
					}
				}
				this.wc_gui.y = this.wc_gui.y + (float)3;
				this.wc_gui.x = (float)0;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Tiles", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.current_area.tiles.x = EditorGUI.IntField(this.wc_gui.getRect(1, (float)2, (float)45, (float)18, true, false), this.current_area.tiles.x);
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)4, (float)15, (float)19, true, false), "*", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.current_area.tiles.y = EditorGUI.IntField(this.wc_gui.getRect(1, (float)4, (float)45, (float)18, true, false), this.current_area.tiles.y);
				if (GUI.Button(this.wc_gui.getRect(1, (float)5, (float)22, (float)16, false, false), new GUIContent("R", "Reset the start export position of the image tiles."), EditorStyles.miniButtonMid))
				{
					this.current_area.start_tile.reset();
				}
				if (this.current_area.start_tile_enabled)
				{
					GUI.color = Color.green;
				}
				if (GUI.Button(this.wc_gui.getRect(1, (float)32, (float)58, (float)16, false, true), new GUIContent("Start", "Choose a start export position of the image tiles.\nThis can be used if the export was interupted or for a single tile download that can be enabled with the 'One' toggle."), EditorStyles.miniButtonMid))
				{
					this.current_area.start_tile_enabled = !this.current_area.start_tile_enabled;
				}
				this.wc_gui.y = this.wc_gui.y + (float)3;
				this.wc_gui.x = (float)0;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Offset", EditorStyles.boldLabel);
				this.wc_gui.x = this.wc_gui.x + (float)(this.guiWidth1 - 17);
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)15, (float)19, true, false), "X");
				GUI.color = Color.white;
				this.current_area.image_offset_e.x = (float)EditorGUI.IntField(this.wc_gui.getRect(0, (float)4, (float)45, (float)18, true, false), (int)this.current_area.image_offset_e.x);
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)4, (float)15, (float)19, true, false), "Y");
				GUI.color = Color.white;
				this.current_area.image_offset_e.y = (float)EditorGUI.IntField(this.wc_gui.getRect(0, (float)4, (float)45, (float)18, true, false), (int)this.current_area.image_offset_e.y);
				if (this.current_area.image_stop_one)
				{
					GUI.color = Color.red;
				}
				else
				{
					GUI.color = global_script.map.color;
				}
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)29, (float)30, (float)19, true, false), "One");
				if (this.current_area.image_stop_one)
				{
					GUI.color = Color.red;
				}
				else
				{
					GUI.color = Color.white;
				}
				this.current_area.image_stop_one = EditorGUI.Toggle(this.wc_gui.getRect(0, (float)4, (float)25, (float)19, true, false), this.current_area.image_stop_one);
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)19;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Image Size", EditorStyles.boldLabel);
				Vector2 vector3 = default(Vector2);
				vector3.x = (float)(this.current_area.resolution * this.current_area.tiles.x);
				vector3.y = (float)(this.current_area.resolution * this.current_area.tiles.y);
				if (this.global_script.map.warnings && (vector3.x > (float)16384 || vector3.y > (float)16384) && (this.global_script.map.export_jpg || this.global_script.map.export_png) && this.notify_text.IndexOf("The total") == -1)
				{
					if (this.notify_text.Length != 0)
					{
						this.notify_text += "\n\n";
					}
					this.notify_text += "The total image size is bigger then 16k, please keep the performance in mind and texture memory. You can still go to at least 64k total image resolution in Unity 5." + "\nMake your image resolution lower in 'Image Export' -> 'Image Zoom' -> Click the '-' button.\n\nPlease read page 7 in the WC manual, after reading and understanding you can disable the warnings in the 'Settings' tab -> Show Warnings";
				}
				this.area_size_old.x = vector3.x;
				this.area_size_old.y = vector3.y;
				if ((vector3.x >= (float)16384 && vector3.x <= (float)32768) || (vector3.y >= (float)16384 && vector3.y <= (float)32768))
				{
					if (this.global_script.map.export_jpg || this.global_script.map.export_png)
					{
						GUI.color = new Color((float)1, 0.5f, (float)0, (float)1);
					}
				}
				else if ((vector3.x > (float)32768 || vector3.y > (float)32768) && (this.global_script.map.export_jpg || this.global_script.map.export_png))
				{
					GUI.color = Color.red;
				}
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)300, (float)19, false, true), vector3.x.ToString() + "x" + vector3.y.ToString() + "  (" + vector3.x * vector3.y / (float)262144 + " transactions)");
				this.wc_gui.x = (float)0;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Export Path", EditorStyles.boldLabel);
				EditorGUI.LabelField(this.wc_gui.getRect(1, (float)0, (float)(this.guiWidth1 + 19), (float)19, true, false), new GUIContent(this.current_area.export_image_path, this.current_area.export_image_path));
				GUI.color = Color.white;
				if (GUI.Button(this.wc_gui.getRect(1, (float)4, (float)62, (float)18, false, true), new GUIContent("Change", "Change the folder where the images are saved to.")))
				{
					if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
					{
						if (this.current_area.export_image_path.Length == 0)
						{
							this.current_area.export_image_path = Application.dataPath;
						}
						this.path_old = this.current_area.export_image_path;
						if (this.key.shift)
						{
							this.current_area.export_image_path = Application.dataPath;
						}
						else if (this.key.alt)
						{
							this.current_area.export_image_path = this.current_area.export_heightmap_path;
						}
						else
						{
							this.current_area.export_image_path = EditorUtility.OpenFolderPanel("Export image Path", this.current_area.export_image_path, string.Empty);
							if (this.current_area.export_image_path.Length == 0)
							{
								this.current_area.export_image_path = this.path_old;
							}
						}
						if (this.path_old != this.current_area.export_image_path)
						{
							if (this.current_area.export_image_path.IndexOf(Application.dataPath) == -1)
							{
								this.notify_text = "The path should be inside your Unity project. Reselect your path.";
								this.current_area.export_image_path = Application.dataPath;
							}
							this.current_area.export_image_changed = true;
							if (!this.current_area.preimage_path_changed)
							{
								this.current_area.preimage_path = this.current_area.export_image_path;
							}
							if (!this.current_area.export_heightmap_changed)
							{
								this.current_area.export_heightmap_path = this.current_area.export_image_path;
							}
							if (!this.current_area.export_terrain_changed)
							{
								this.current_area.export_terrain_path = this.current_area.export_image_path + "/Terrains";
							}
						}
					}
					else
					{
						this.notify_text = "It is not possible to change an export folder while exporting.";
					}
				}
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)1;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Image File", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
				{
					this.current_area.export_image_filename = EditorGUI.TextField(this.wc_gui.getRect(1, (float)2, (float)(this.guiWidth1 + 21), (float)18, true, false), this.current_area.export_image_filename);
				}
				else
				{
					EditorGUI.TextField(this.wc_gui.getRect(1, (float)2, (float)(this.guiWidth1 + 21), (float)18, true, false), this.current_area.export_image_filename);
				}
				if (GUI.changed)
				{
					this.current_area.export_image_changed = true;
					if (!this.current_area.export_heightmap_changed)
					{
						this.current_area.export_heightmap_filename = this.current_area.export_image_filename;
					}
					if (!this.current_area.export_terrain_changed)
					{
						this.current_area.terrain_scene_name = "_" + this.current_area.export_image_filename;
						this.current_area.terrain_scene_name = this.current_area.export_image_filename;
					}
				}
				GUI.changed = false;
				this.current_area.export_image_changed = EditorGUI.Toggle(this.wc_gui.getRect(1, (float)4, (float)25, (float)19, true, false), this.current_area.export_image_changed);
				if (GUI.changed && !this.current_area.export_image_changed)
				{
					this.current_area.export_image_path = this.current_area.export_heightmap_path;
					this.current_area.export_image_filename = this.current_area.export_heightmap_filename;
				}
				GUI.changed = gui_changed_old;
				if (this.global_script.map.path_display)
				{
					if (GUI.Button(this.wc_gui.getRect(1, (float)8, (float)25, (float)16, false, true), new GUIContent("<", "Hide the full path text of where the images are stored into."), EditorStyles.miniButtonMid))
					{
						this.global_script.map.path_display = false;
					}
				}
				else if (GUI.Button(this.wc_gui.getRect(1, (float)8, (float)25, (float)16, false, true), new GUIContent(">", "Show the full path text of where the images are stored into."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.path_display = true;
				}
				GUI.color = global_script.map.color;
				this.wc_gui.y = this.wc_gui.y + (float)3;
				this.wc_gui.x = (float)0;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Export World File", EditorStyles.boldLabel);
				GUI.color = Color.white;
				if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
				{
					this.current_area.export_image_world_file = EditorGUI.Toggle(this.wc_gui.getRect(1, (float)2, (float)25, (float)19, false, true), this.current_area.export_image_world_file);
				}
				else
				{
					EditorGUI.Toggle(this.wc_gui.getRect(1, (float)2, (float)25, (float)19, false, true), this.current_area.export_image_world_file);
				}
				this.wc_gui.x = (float)0;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Threads", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
				{
					this.global_script.map.export_texExt = EditorGUI.IntField(this.wc_gui.getRect(1, (float)2, (float)60, (float)18, false, true), this.global_script.map.export_texExt);
				}
				else
				{
					EditorGUI.IntField(this.wc_gui.getRect(1, (float)2, (float)60, (float)18, false, true), this.global_script.map.export_texExt);
					if (GUI.changed)
					{
						this.notify_text = "It is not possible to change this while exporting";
					}
				}
				if (GUI.changed)
				{
					if (this.global_script.map.export_texExt < 1)
					{
						this.global_script.map.export_texExt = 1;
					}
					else if (this.global_script.map.export_texExt > 16)
					{
						this.global_script.map.export_texExt = 16;
					}
				}
				GUI.changed = gui_changed_old;
				this.current_area.export_image_import_settings = false;
				this.wc_gui.y = this.wc_gui.y + (float)4;
				this.wc_gui.x = (float)0;
				string text = "Export\n Images";
				if (this.current_area.export_image_active || this.current_area.export_image_call)
				{
					text = "Stop";
				}
				GUI.color = Color.white;
				if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)38, true, false), new GUIContent(text, "This button is for starting/stopping the exporting of the images.")))
				{
					if (this.global_script.map.export_jpg && this.global_script.map.export_raw)
					{
						this.notify_text = "The Jpg and Raw are selected. This mode can only be used to slice the raw combined image into Jpg images. Read page 10 in the WorldComposer manual about this.";
					}
					else
					{
						if (this.current_area.tiles.x == 0 && this.current_area.tiles.y == 0)
						{
							this.notify_text = "The area is not created. Use the 'Pick' button to create an area";
							return;
						}
						if (!this.check_area_resize())
						{
							if (this.key.shift)
							{
								this.save_global_settings();
								this.start_image_pull_region(this.current_region);
							}
							else if (this.key.control)
							{
								this.stop_image_pull_region(this.current_region);
							}
							else
							{
								this.save_global_settings();
								this.start_image_pull(this.current_region, this.current_area);
							}
						}
					}
				}
				EditorGUILayout.BeginVertical(new GUILayoutOption[0]);
				if (!this.global_script.map.export_image_continue)
				{
					GUI.backgroundColor = Color.red;
				}
				if (GUI.Button(this.wc_gui.getRect(0, (float)4, (float)45, (float)16, false, false), new GUIContent("Pause", "This pauses the image export."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.export_image_continue = !this.global_script.map.export_image_continue;
				}
				GUI.backgroundColor = Color.white;
				GUI.color = Color.white;
				if (this.global_script.map.export_image_active)
				{
					this.global_script.map.export_image.progress = ((float)this.global_script.map.export_image.tile.x * 1f + (float)(this.global_script.map.export_image.tile.y * this.global_script.map.export_image.tiles.x) * 1f) / ((float)(this.global_script.map.export_image.tiles.x * this.global_script.map.export_image.tiles.y) * 1f);
					EditorGUI.ProgressBar(this.wc_gui.getRect(0, (float)53, (float)153, (float)19, false, false), this.global_script.map.export_image.progress, (this.global_script.map.export_image.progress * (float)100).ToString("F0") + "%");
				}
				else
				{
					GUI.color = global_script.map.color;
				}
				if (this.global_script.map.export_image_timeEnd - this.global_script.map.export_image_timeStart < (float)0)
				{
					this.global_script.map.export_image_timeEnd = (this.global_script.map.export_image_timeStart = (float)0);
				}
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)53, (float)100, (float)19, false, true), this.sec_to_timeMin(this.global_script.map.export_image_timeEnd - this.global_script.map.export_image_timeStart, true));
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)4, (float)30, (float)19, true, false), "Jpg");
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
				{
					this.global_script.map.export_jpg = EditorGUI.Toggle(this.wc_gui.getRect(0, (float)4, (float)25, (float)19, true, false), this.global_script.map.export_jpg);
				}
				else
				{
					EditorGUI.Toggle(this.wc_gui.getRect(0, (float)4, (float)25, (float)19, true, false), this.global_script.map.export_jpg);
				}
				if (GUI.changed && !this.global_script.map.export_jpg && !this.global_script.map.export_raw && !this.global_script.map.export_png)
				{
					this.global_script.map.export_png = true;
				}
				GUI.changed = gui_changed_old;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)10, (float)30, (float)19, true, false), "Png");
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
				{
					this.global_script.map.export_png = EditorGUI.Toggle(this.wc_gui.getRect(0, (float)4, (float)24, (float)19, true, false), this.global_script.map.export_png);
				}
				else
				{
					EditorGUI.Toggle(this.wc_gui.getRect(0, (float)4, (float)24, (float)19, true, false), this.global_script.map.export_png);
				}
				if (GUI.changed)
				{
					if (!this.global_script.map.export_png && !this.global_script.map.export_raw && !this.global_script.map.export_jpg)
					{
						this.global_script.map.export_jpg = true;
					}
					if (this.global_script.map.export_png && this.global_script.map.export_raw)
					{
						this.global_script.map.export_raw = false;
					}
				}
				GUI.changed = gui_changed_old;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)10, (float)30, (float)19, true, false), "Raw");
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				if (!this.current_area.export_heightmap_active && !this.current_area.export_image_active && !this.combine_generate && !this.slice_generate)
				{
					this.global_script.map.export_raw = EditorGUI.Toggle(this.wc_gui.getRect(0, (float)4, (float)25, (float)19, true, true), this.global_script.map.export_raw);
				}
				else
				{
					EditorGUI.Toggle(this.wc_gui.getRect(0, (float)4, (float)25, (float)19, true, true), this.global_script.map.export_raw);
				}
				if (GUI.changed)
				{
					if (!this.global_script.map.export_raw)
					{
						if (!this.global_script.map.export_jpg)
						{
							this.global_script.map.export_jpg = true;
						}
					}
					else
					{
						this.global_script.map.export_png = false;
					}
				}
				GUI.changed = gui_changed_old;
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)3;
				GUI.color = global_script.map.color;
				if (this.global_script.map.export_jpg)
				{
					EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Jpeg Quality", EditorStyles.boldLabel);
					GUI.color = Color.white;
					this.global_script.map.export_jpg_quality = (int)EditorGUI.Slider(this.wc_gui.getRect(1, (float)4, (float)(this.guiWidth1 + 80), (float)19, false, true), (float)this.global_script.map.export_jpg_quality, (float)0, (float)100);
				}
				this.wc_gui.y = this.wc_gui.y + (float)3;
				if (this.global_script.map.export_raw)
				{
					GUI.color = Color.white;
					if (!this.combine_generate && !this.slice_generate)
					{
						if (this.global_script.map.export_jpg)
						{
							if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)120, (float)19, false, true), new GUIContent("Slice Images", "Slice the combined raw file back into single JPG images.")))
							{
								this.slice_textures_begin(this.current_area, this.current_area.export_image_path, this.current_area.export_image_filename);
							}
						}
						else if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)120, (float)19, false, true), new GUIContent("Combine Images", "Combine the exported image tiles into 1 big raw image file.\nThis file can be used by the 'Image Editor' or you can edit it in photoshop.")))
						{
							this.combine_textures_begin(this.current_area, this.current_area.export_image_path, this.current_area.export_image_filename);
						}
					}
					else
					{
						if (GUI.Button(this.wc_gui.getRect(0, (float)0, (float)120, (float)19, true, false), "Stop"))
						{
							this.combine_generate = false;
							this.slice_generate = false;
							if (this.combine_export_file != null)
							{
								this.combine_import_file.Close();
							}
							if (this.combine_export_file != null)
							{
								this.combine_export_file.Close();
							}
							Application.runInBackground = false;
						}
						this.combine_progress = (float)(this.combine_y * this.combine_area.tiles.x + this.combine_x) * 1f / ((float)(this.combine_area.tiles.x * this.combine_area.tiles.y) * 1f);
						EditorGUI.ProgressBar(this.wc_gui.getRect(0, (float)4, (float)206, (float)19, false, true), this.combine_progress, (this.combine_progress * (float)100).ToString("F0") + "%");
					}
				}
			}
			if (this.global_script.map.button_settings)
			{
				this.wc_gui.x = (float)0;
				this.wc_gui.y = (float)(this.gui_y + 23);
				this.settings_rect = new Rect((float)0, (float)this.gui_y, (float)(this.guiWidth2 + 1), (float)(200 + this.gui_height));
				this.drawGUIBox(this.settings_rect, "Settings", this.global_script.map.backgroundColor, this.global_script.map.titleColor, this.global_script.map.color);
				this.wc_gui.y = this.wc_gui.y + (float)1;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Stop all exports", EditorStyles.boldLabel);
				GUI.color = Color.white;
				if (GUI.Button(this.wc_gui.getRect(1, (float)154, (float)50, (float)18, false, true), new GUIContent("Stop", "Stops all current heightmap and image exports.")))
				{
					this.reexports();
				}
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Request Timeout", EditorStyles.boldLabel);
				GUI.color = Color.white;
				GUI.changed = false;
				this.global_script.map.timeOut = EditorGUI.IntField(this.wc_gui.getRect(1, (float)2, (float)60, (float)18, false, true), this.global_script.map.timeOut);
				if (GUI.changed)
				{
					if (this.global_script.map.timeOut < 2)
					{
						this.global_script.map.timeOut = 2;
					}
					else if (this.global_script.map.timeOut > 35)
					{
						this.global_script.map.timeOut = 35;
					}
				}
				this.wc_gui.y = this.wc_gui.y + (float)2;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Error color", EditorStyles.boldLabel);
				GUI.color = Color.white;
				GUI.changed = false;
				this.wc_gui.x = this.wc_gui.x + (float)2;
				this.global_script.map.errorColor = EditorGUI.ColorField(this.wc_gui.getRect(1, (float)0, (float)50, (float)17, false, true), this.global_script.map.errorColor);
				this.wc_gui.x = this.wc_gui.x - (float)2;
				if (GUI.changed)
				{
					this.notify_text = "This is the color that Bing sometimes returns as empty space within a satellite image. WorldComposer scans each requested image for this color and if it contains a certain amount of pixels in a row (the green export image box will turn red) it will resend the request to get a clean image. The default color is R 127,G 127, B 127. Change this only if Bing changes this color.";
				}
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Show Warnings", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.global_script.map.warnings = EditorGUI.Toggle(this.wc_gui.getRect(1, (float)2, (float)(this.guiWidth1 + 25), (float)19, false, true), this.global_script.map.warnings);
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Track Tiles", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.global_script.map.track_tile = EditorGUI.Toggle(this.wc_gui.getRect(1, (float)2, (float)(this.guiWidth1 + 25), (float)19, false, true), this.global_script.map.track_tile);
				this.wc_gui.y = this.wc_gui.y + (float)3;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Mouse Sensivity", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.global_script.map.mouse_sensivity = EditorGUI.Slider(this.wc_gui.getRect(1, (float)2, (float)(this.guiWidth1 + 84), (float)19, false, true), this.global_script.map.mouse_sensivity, (float)1, (float)10);
				this.wc_gui.x = (float)0;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Title Color", EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				this.wc_gui.x = this.wc_gui.x + (float)2;
				this.global_script.map.titleColor = EditorGUI.ColorField(this.wc_gui.getRect(1, (float)0, (float)50, (float)17, false, false), this.global_script.map.titleColor);
				this.wc_gui.x = this.wc_gui.x - (float)2;
				if (GUI.changed)
				{
					this.global_script.tex3.SetPixel(0, 0, this.global_script.map.titleColor);
					this.global_script.tex3.Apply();
				}
				GUI.changed = gui_changed_old;
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)19;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Background Color", EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				this.wc_gui.x = this.wc_gui.x + (float)2;
				this.global_script.map.backgroundColor = EditorGUI.ColorField(this.wc_gui.getRect(1, (float)0, (float)50, (float)17, false, false), this.global_script.map.backgroundColor);
				this.wc_gui.x = this.wc_gui.x - (float)2;
				if (GUI.changed)
				{
					this.global_script.tex2.SetPixel(0, 0, this.global_script.map.backgroundColor);
					this.global_script.tex2.Apply();
				}
				this.wc_gui.x = (float)0;
				this.wc_gui.y = this.wc_gui.y + (float)19;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(this.wc_gui.getRect(0, (float)0, (float)this.guiWidth1, (float)19, false, false), "Font Color", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.wc_gui.x = this.wc_gui.x + (float)2;
				this.global_script.map.color = EditorGUI.ColorField(this.wc_gui.getRect(1, (float)0, (float)50, (float)17, false, false), this.global_script.map.color);
				this.wc_gui.x = this.wc_gui.x - (float)2;
			}
			this.guiAreaHeight = this.gui_y;
			GUI.EndScrollView();
			GUILayout.EndArea();
			if (this.global_script.map.button_image_editor)
			{
				this.gui_y2 += 113 + this.global_script.map.preimage_edit.edit_color.Count * 18;
				if (this.current_area.preimage_save_new)
				{
					this.gui_y2 += 60;
				}
			}
			if (this.global_script.map.button_help)
			{
				this.keyHelp();
				this.gui_y2 += 125;
			}
			this.screen_rect2 = new Rect((float)0, (float)0, (float)0, (float)0);
			this.guiWidth2 += 10;
			this.gui_y2++;
			if (this.global_script.map.button_converter)
			{
				this.converter_rect = new Rect((float)(this.guiWidth2 + 15), (float)(42 + this.gui_y2), (float)490, (float)122);
				this.drawGUIBox(this.converter_rect, "Converter", this.global_script.map.backgroundColor, this.global_script.map.titleColor, this.global_script.map.color);
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 14), (float)(64 + this.gui_y2), (float)200, (float)20), "Source ascii heightmap", EditorStyles.boldLabel);
				if (this.global_script.map.path_display)
				{
					GUI.color = this.global_script.map.backgroundColor;
					EditorGUI.DrawPreviewTexture(new Rect((float)(this.guiWidth2 + 529), (float)(64 + this.gui_y2), (float)this.global_script.label_width(this.current_area.converter_source_path_full, true), (float)20), this.global_script.tex2);
					GUI.color = global_script.map.color;
					EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 528), (float)(65 + this.gui_y2), (float)this.global_script.label_width(this.current_area.converter_source_path_full, true), (float)20), new GUIContent(this.current_area.converter_source_path_full), EditorStyles.boldLabel);
				}
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 204), (float)(64 + this.gui_y2), (float)220, (float)20), new GUIContent(this.current_area.converter_source_path_full, this.current_area.converter_source_path_full));
				GUI.color = Color.white;
				if (GUI.Button(new Rect((float)(this.guiWidth2 + 428), (float)(64 + this.gui_y2), (float)70, (float)18), new GUIContent("Change", "Change the source ascii heightmap file.")))
				{
					this.path_old = this.current_area.converter_source_path_full;
					if (!this.key.shift)
					{
						this.current_area.converter_source_path_full = EditorUtility.OpenFilePanel("Source Ascii heightmap", this.current_area.converter_source_path_full, "asc");
						if (this.current_area.converter_source_path_full.Length == 0)
						{
							this.current_area.converter_source_path_full = this.path_old;
						}
						else
						{
							this.current_area.converter_destination_path_full = this.current_area.converter_source_path_full.Replace(".asc", ".raw");
						}
					}
					else
					{
                        current_area.converter_source_path_full = Application.dataPath;
                    }
				}
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 14), (float)(83 + this.gui_y2), (float)200, (float)20), "Destination raw heightmap", EditorStyles.boldLabel);
				if (this.global_script.map.path_display)
				{
					GUI.color = this.global_script.map.backgroundColor;
					EditorGUI.DrawPreviewTexture(new Rect((float)(this.guiWidth2 + 529), (float)(83 + this.gui_y2), (float)this.global_script.label_width(this.current_area.converter_destination_path_full, true), (float)20), this.global_script.tex2);
					GUI.color = global_script.map.color;
					EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 528), (float)(83 + this.gui_y2), (float)this.global_script.label_width(this.current_area.converter_destination_path_full, true), (float)20), new GUIContent(this.current_area.converter_destination_path_full), EditorStyles.boldLabel);
				}
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 204), (float)(83 + this.gui_y2), (float)220, (float)20), new GUIContent(this.current_area.converter_destination_path_full, this.current_area.converter_destination_path_full));
				GUI.color = Color.white;
				if (GUI.Button(new Rect((float)(this.guiWidth2 + 428), (float)(83 + this.gui_y2), (float)70, (float)18), new GUIContent("Change", "Change the destination raw heightmap file.")))
				{
					this.path_old = this.current_area.converter_destination_path_full;
					if (!this.key.shift)
					{
						int num9 = this.current_area.converter_source_path_full.LastIndexOf("/");
						string text2 = this.current_area.converter_source_path_full.Substring(num9 + 1);
						text2 = text2.Replace(".asc", ".raw");
						this.current_area.converter_destination_path_full = EditorUtility.SaveFilePanel("Destination raw heightmap", this.current_area.converter_source_path_full, text2, "raw");
						if (this.current_area.converter_destination_path_full.Length == 0)
						{
							this.current_area.converter_destination_path_full = this.path_old;
						}
					}
					else
					{
                        current_area.converter_source_path_full = Application.dataPath;
                    }
				}
				if (this.global_script.map.path_display)
				{
					if (GUI.Button(new Rect((float)(this.guiWidth2 + 471), (float)(104 + this.gui_y2), (float)25, (float)15), new GUIContent("<", "Hide the full path texts."), EditorStyles.miniButtonMid))
					{
						this.global_script.map.path_display = false;
					}
				}
				else if (GUI.Button(new Rect((float)(this.guiWidth2 + 471), (float)(104 + this.gui_y2), (float)25, (float)15), new GUIContent(">", "Show the full path texts."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.path_display = true;
				}
				if (GUI.Button(new Rect((float)(this.guiWidth2 + 18), (float)(121 + this.gui_y2), (float)130, (float)36), new GUIContent("Convert", "Convert the source ascii heightmap to destination raw heightmap.")))
				{
					if (this.current_area.converter_source_path_full.Length == 0)
					{
						this.notify_text = "Choose a source ascii file";
						return;
					}
					if (this.current_area.converter_destination_path_full.Length == 0)
					{
						this.notify_text = "Choose a destination raw file";
						return;
					}
					this.asc_convert_to_raw(this.current_area.converter_source_path_full, this.current_area.converter_destination_path_full);
				}
				this.gui_y2 += 124;
			}
			if (this.global_script.map.button_create_terrain)
			{
				int num10 = 0;
				int num11 = 0;
				if (this.current_area.import_heightmap)
				{
					num11 += 19;
				}
				if (this.terraincomposer)
				{
					num10 += 19;
				}
				num10 += 43;
				//if (this.current_area.normalizeHeightmap)
				//{
				//	this.create_terrain_rect = new Rect((float)(this.guiWidth2 + 15), (float)(42 + this.gui_y2), (float)490, (float)(320 + num10 + num11));
				//}
				//else
				//{
					this.create_terrain_rect = new Rect((float)(this.guiWidth2 + 15), (float)(42 + this.gui_y2), (float)490, (float)(340 + num10 + num11));
				//}
				this.drawGUIBox(this.create_terrain_rect, "Create Terrain", this.global_script.map.backgroundColor, this.global_script.map.titleColor, this.global_script.map.color);
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(64 + this.gui_y2), (float)200, (float)20), "Asset Path", EditorStyles.boldLabel);
				if (this.global_script.map.path_display)
				{
					GUI.color = this.global_script.map.backgroundColor;
					EditorGUI.DrawPreviewTexture(new Rect((float)(this.guiWidth2 + 529), (float)(64 + this.gui_y2), (float)this.global_script.label_width(this.current_area.export_terrain_path, true), (float)20), this.global_script.tex2);
					GUI.color = global_script.map.color;
					EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 528), (float)(65 + this.gui_y2), (float)this.global_script.label_width(this.current_area.export_terrain_path, true), (float)20), new GUIContent(this.current_area.export_terrain_path), EditorStyles.boldLabel);
				}
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 204), (float)(64 + this.gui_y2), (float)200, (float)20), new GUIContent(this.current_area.export_terrain_path, this.current_area.export_terrain_path));
				GUI.color = Color.white;
				this.gui_changed_old = GUI.changed;
				this.current_area.export_terrain_changed = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 406), (float)(64 + this.gui_y2), (float)20, (float)20), this.current_area.export_terrain_changed);
				if (GUI.changed && !this.current_area.export_terrain_changed)
				{
					this.current_area.export_terrain_path = this.current_area.export_heightmap_path + "/Terrains";
				}
				GUI.changed = gui_changed_old;
				if (GUI.Button(new Rect((float)(this.guiWidth2 + 428), (float)(64 + this.gui_y2), (float)70, (float)18), new GUIContent("Change", "Change the folder where to save the terrains to.")))
				{
					this.path_old = this.current_area.export_heightmap_path;
					if (!this.key.shift)
					{
						this.current_area.export_terrain_path = EditorUtility.OpenFolderPanel("Terrain Asset Path", this.current_area.export_terrain_path, string.Empty);
						if (this.current_area.export_terrain_path.Length == 0)
						{
							this.current_area.export_terrain_path = this.path_old;
						}
					}
					else
					{
						this.current_area.export_terrain_path = Application.dataPath;
					}
					if (this.path_old != this.current_area.export_heightmap_path)
					{
						if (this.current_area.export_terrain_path.IndexOf(Application.dataPath) == -1)
						{
							this.notify_text = "The path should be inside your Unity project. Reselect your path.";
							this.current_area.export_terrain_path = Application.dataPath;
						}
						this.current_area.export_terrain_changed = true;
						if (!this.current_area.export_image_changed)
						{
							this.current_area.export_image_path = this.current_area.export_heightmap_path;
						}
						if (!this.current_area.export_terrain_changed)
						{
							this.current_area.export_terrain_path = this.current_area.export_heightmap_path + "/Terrains";
						}
					}
				}
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(83 + this.gui_y2), (float)200, (float)20), "Asset Name", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				this.current_area.terrain_scene_name = EditorGUI.TextField(new Rect((float)(this.guiWidth2 + 204), (float)(83 + this.gui_y2), (float)200, (float)17), this.current_area.terrain_scene_name);
				if (GUI.changed)
				{
					this.current_area.terrain_name_changed = true;
				}
				GUI.changed = false;
				this.current_area.terrain_name_changed = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 406), (float)(83 + this.gui_y2), (float)20, (float)20), this.current_area.terrain_name_changed);
				if (GUI.changed && !this.current_area.terrain_name_changed)
				{
					this.current_area.terrain_scene_name = "_" + this.current_area.export_heightmap_filename;
					this.current_area.terrain_scene_name = this.current_area.export_heightmap_filename;
				}
				GUI.changed = gui_changed_old;
				if (this.global_script.map.path_display)
				{
					if (GUI.Button(new Rect((float)(this.guiWidth2 + 471), (float)(85 + this.gui_y2), (float)25, (float)15), new GUIContent("<", "Hide the full path texts."), EditorStyles.miniButtonMid))
					{
						this.global_script.map.path_display = false;
					}
				}
				else if (GUI.Button(new Rect((float)(this.guiWidth2 + 471), (float)(85 + this.gui_y2), (float)25, (float)15), new GUIContent(">", "Show the full path texts."), EditorStyles.miniButtonMid))
				{
					this.global_script.map.path_display = true;
				}
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(102 + this.gui_y2), (float)200, (float)20), "Scene Name", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				this.current_area.terrain_scene_name = EditorGUI.TextField(new Rect((float)(this.guiWidth2 + 204), (float)(102 + this.gui_y2), (float)200, (float)17), this.current_area.terrain_scene_name);
				if (GUI.changed)
				{
					this.current_area.terrain_name_changed = true;
				}
				GUI.changed = gui_changed_old;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(125 + this.gui_y2), (float)200, (float)20), "Normalize Heightmap", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.current_area.normalizeHeightmap = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 204), (float)(125 + this.gui_y2), (float)200, (float)20), this.current_area.normalizeHeightmap);
				//if (!this.current_area.normalizeHeightmap)
				//{
				//	GUI.color = global_script.map.color;
				//	this.gui_y2 += 20;
				//	EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(125 + this.gui_y2), (float)200, (float)20), "Terrain Height", EditorStyles.boldLabel);
				//	GUI.color = Color.white;
				//	this.gui_changed_old = GUI.changed;
				//	GUI.changed = false;
				//	this.current_area.terrain_height = EditorGUI.FloatField(new Rect((float)(this.guiWidth2 + 204), (float)(125 + this.gui_y2), (float)75, (float)17), this.current_area.terrain_height);
				//	if (GUI.changed && this.current_area.terrain_height < (float)1)
				//	{
				//		this.current_area.terrain_height = (float)1;
				//	}
				//	GUI.changed = gui_changed_old;
				//}
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 282), (float)(125 + this.gui_y2), (float)80, (float)20), "Scale", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.current_area.terrain_scale = EditorGUI.FloatField(new Rect((float)(this.guiWidth2 + 324), (float)(125 + this.gui_y2), (float)80, (float)17), this.current_area.terrain_scale);
				if (this.current_area.terrain_scale <= (float)0)
				{
					this.current_area.terrain_scale = (float)1;
				}
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(145 + this.gui_y2), (float)200, (float)20), "Generate Heightmap", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.current_area.do_heightmap = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 204), (float)(145 + this.gui_y2), (float)200, (float)20), this.current_area.do_heightmap);
				GUI.color = global_script.map.color;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(165 + this.gui_y2), (float)200, (float)20), "Heightmap Offset", EditorStyles.boldLabel);
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 204), (float)(165 + this.gui_y2), (float)20, (float)20), "X");
				GUI.color = Color.white;
				this.current_area.heightmap_offset_e.x = EditorGUI.FloatField(new Rect((float)(this.guiWidth2 + 220), (float)(165 + this.gui_y2), (float)80, (float)18), this.current_area.heightmap_offset_e.x);
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 304), (float)(165 + this.gui_y2), (float)20, (float)20), "Y");
				GUI.color = Color.white;
				this.current_area.heightmap_offset_e.y = EditorGUI.FloatField(new Rect((float)(this.guiWidth2 + 324), (float)(165 + this.gui_y2), (float)80, (float)18), this.current_area.heightmap_offset_e.y);
				GUI.color = global_script.map.color;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(186 + this.gui_y2 + num11), (float)200, (float)20), "Heightmap Resolution", EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				this.current_area.terrain_heightmap_resolution_select = EditorGUI.Popup(new Rect((float)(this.guiWidth2 + 204), (float)(186 + this.gui_y2 + num11), (float)200, (float)17), this.current_area.terrain_heightmap_resolution_select, this.heightmap_resolution_list);
				if (GUI.changed)
				{
					this.current_area.terrain_heightmap_resolution = (int)(Mathf.Pow((float)2, (float)(this.current_area.terrain_heightmap_resolution_select + 5)) + (float)1);
					this.current_area.terrain_heightmap_resolution_changed = true;
				}
				if (this.current_area.terrain_heightmap_resolution < 33)
				{
					this.current_area.terrain_heightmap_resolution = 33;
				}
				GUI.changed = false;
				this.current_area.terrain_heightmap_resolution_changed = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 407), (float)(186 + this.gui_y2 + num11), (float)20, (float)20), this.current_area.terrain_heightmap_resolution_changed);
				if (GUI.changed && !this.current_area.terrain_heightmap_resolution_changed)
				{
					this.calc_terrain_heightmap_resolution();
				}
				GUI.changed = gui_changed_old;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 424), (float)(186 + this.gui_y2 + num11), (float)200, (float)20), "(" + (this.current_area.heightmap_resolution.x / (float)this.current_area.tiles.x).ToString() + ")");
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(205 + this.gui_y2 + num11), (float)200, (float)20), "Satellite Images", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.current_area.do_image = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 204), (float)(205 + this.gui_y2 + num11), (float)200, (float)20), this.current_area.do_image);
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(224 + this.gui_y2 + num11), (float)200, (float)20), "Image Import Settings", EditorStyles.boldLabel);
				GUI.color = Color.white;
				if (!this.apply_import_settings)
				{
					if (GUI.Button(new Rect((float)(this.guiWidth2 + 204), (float)(224 + this.gui_y2 + num11), (float)70, (float)18), new GUIContent("Apply", "Apply the image import settings for the exported images of this area.")))
					{
						this.save_global_settings();
						this.start_image_import_settings(this.current_area);
					}
				}
				else
				{
					if (GUI.Button(new Rect((float)(this.guiWidth2 + 204), (float)(224 + this.gui_y2 + num11), (float)70, (float)18), new GUIContent("Stop", "Stop applying the image import settings.")))
					{
						this.apply_import_settings = false;
					}
					GUI.color = Color.red;
					EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 330), (float)(224 + this.gui_y2 + num11), (float)130, (float)19), (this.create_area.tiles.x * this.create_area.tiles.y - this.import_settings_count).ToString());
				}
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 278), (float)(224 + this.gui_y2 + num11), (float)130, (float)19), new GUIContent("Auto", "Automatically apply the choosen image import settings after creating the terrains."));
				GUI.color = Color.white;
				this.current_area.auto_import_settings_apply = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 310), (float)(224 + this.gui_y2 + num11), (float)25, (float)19), this.current_area.auto_import_settings_apply);
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(243 + this.gui_y2 + num11), (float)200, (float)20), "Generate Mip Maps", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.current_area.mipmapEnabled = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 204), (float)(243 + this.gui_y2 + num11), (float)200, (float)20), this.current_area.mipmapEnabled);
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(262 + this.gui_y2 + num11), (float)200, (float)20), "Filter Mode", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.current_area.filterMode = (FilterMode)EditorGUI.EnumPopup(new Rect((float)(this.guiWidth2 + 204), (float)(262 + this.gui_y2 + num11), (float)200, (float)20), this.current_area.filterMode);
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(281 + this.gui_y2 + num11), (float)200, (float)20), "Aniso Level", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.current_area.anisoLevel = (int)EditorGUI.Slider(new Rect((float)(this.guiWidth2 + 204), (float)(281 + this.gui_y2 + num11), (float)200, (float)17), (float)this.current_area.anisoLevel, (float)0, (float)9);
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(300 + this.gui_y2 + num11), (float)200, (float)20), "Max size", EditorStyles.boldLabel);
				this.gui_changed_old = GUI.changed;
				GUI.changed = false;
				GUI.color = Color.white;
				this.current_area.maxTextureSize_select = EditorGUI.Popup(new Rect((float)(this.guiWidth2 + 204), (float)(300 + this.gui_y2 + num11), (float)200, (float)20), this.current_area.maxTextureSize_select, this.image_resolution_list);
				if (GUI.changed)
				{
					this.current_area.maxTextureSize = (int)Mathf.Pow((float)2, (float)(this.current_area.maxTextureSize_select + 5));
					this.current_area.maxTextureSize_changed = true;
				}
				GUI.changed = false;
				this.current_area.maxTextureSize_changed = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 406), (float)(300 + this.gui_y2 + num11), (float)20, (float)20), this.current_area.maxTextureSize_changed);
				if (GUI.changed && !this.current_area.maxTextureSize_changed)
				{
					if (this.current_area.resolution > 4096)
					{
						this.current_area.maxTextureSize = 4096;
						this.current_area.maxTextureSize_select = 7;
					}
					else
					{
						this.current_area.maxTextureSize = this.current_area.resolution;
						this.current_area.maxTextureSize_select = (int)(Mathf.Log((float)this.current_area.maxTextureSize, (float)2) - (float)5);
					}
				}
				GUI.changed = gui_changed_old;
				GUI.color = global_script.map.color;
				EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(324 + this.gui_y2 + num11), (float)200, (float)20), "Format", EditorStyles.boldLabel);
				GUI.color = Color.white;
				this.current_area.textureFormat = (TextureImporterFormat)EditorGUI.EnumPopup(new Rect((float)(this.guiWidth2 + 204), (float)(324 + this.gui_y2 + num11), (float)200, (float)20), this.current_area.textureFormat);
				GUI.color = global_script.map.color;
				if (this.terraincomposer)
				{
					EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(343 + this.gui_y2 + num11), (float)200, (float)20), "Export to TerrainComposer", EditorStyles.boldLabel);
					GUI.color = Color.white;
					this.current_area.export_to_terraincomposer = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 204), (float)(343 + this.gui_y2 + num11), (float)20, (float)20), this.current_area.export_to_terraincomposer);
					GUI.color = global_script.map.color;
					if (this.current_area.export_to_terraincomposer)
					{
						EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(362 + this.gui_y2 + num11), (float)200, (float)20), "Add Perlin to heightmap", EditorStyles.boldLabel);
						GUI.color = Color.white;
						this.current_area.filter_perlin = EditorGUI.Toggle(new Rect((float)(this.guiWidth2 + 204), (float)(362 + this.gui_y2 + num11), (float)20, (float)20), this.current_area.filter_perlin);
						GUI.color = global_script.map.color;
					}
				}
				if (!this.current_area.export_to_terraincomposer || !this.terraincomposer)
				{
					EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 19), (float)(300 + this.gui_y2 + num11 + num10), (float)200, (float)20), "Heightmap Curve", EditorStyles.boldLabel);
					GUI.color = Color.white;
					this.current_area.terrain_curve = EditorGUI.CurveField(new Rect((float)(this.guiWidth2 + 205), (float)(301 + this.gui_y2 + num11 + num10), (float)198, (float)17), this.current_area.terrain_curve);
					if (GUI.Button(new Rect((float)(this.guiWidth2 + 406), (float)(301 + this.gui_y2 + num11 + num10), (float)20, (float)17), new GUIContent("R", "Reset the heightmap curve.")))
					{
						this.current_area.terrain_curve = AnimationCurve.Linear((float)0, (float)0, (float)1, (float)1);
						this.current_area.terrain_curve.AddKey((float)1, (float)0);
						this.current_area.terrain_curve = this.current_area.set_curve_linear(this.current_area.terrain_curve);
					}
					GUI.color = global_script.map.color;
				}
				GUI.color = Color.white;
				if (!this.create_terrain_loop)
				{
					if (GUI.Button(new Rect((float)(this.guiWidth2 + 19), (float)(319 + this.gui_y2 + num11 + num10), (float)130, (float)37), new GUIContent("Create Terrain", "Create the terrains from the exported heightmap and images.")))
					{
						if (this.global_script.map.export_raw && !this.global_script.map.export_jpg && !this.global_script.map.export_png)
						{
							this.notify_text = "It is only possible to create terrains with Jpg (Recommended) or Png images. The raw is for photoshop editing";
							return;
						}
						this.save_global_settings();
						this.create_terrains_area();
					}
					if ((!this.current_area.export_to_terraincomposer || !this.terraincomposer) && this.current_area.terrain_done)
					{
						if (!this.generate)
						{
							if (GUI.Button(new Rect((float)(this.guiWidth2 + 204), (float)(319 + this.gui_y2 + num11 + num10), (float)130, (float)20), new GUIContent("Generate Heightmap", "Regenerate the heightmap of the terrain.")))
							{
								this.heightmap_count_terrain = 0;
								this.generate_manual = true;
								this.create_region = this.current_region;
								this.create_area = this.current_area;
								this.generate_begin();
								this.heightmap_y = (float)(this.heightmap_resolution - 1);
								this.generate = true;
							}
							if (GUI.Button(new Rect((float)(this.guiWidth2 + 339), (float)(319 + this.gui_y2 + num11 + num10), (float)65, (float)20), new GUIContent("Smooth", "Smoothen the terrain heightmap.")))
							{
								this.smooth_all_terrain(this.current_area.smooth_strength);
							}
							this.current_area.smooth_strength = EditorGUI.FloatField(new Rect((float)(this.guiWidth2 + 409), (float)(321 + this.gui_y2 + num11 + num10), (float)63, (float)17), this.current_area.smooth_strength);
						}
						else
						{
							if (GUI.Button(new Rect((float)(this.guiWidth2 + 203), (float)(319 + this.gui_y2 + num11 + num10), (float)130, (float)20), new GUIContent("Stop", "Stop generating the heightmap of the terrains.")))
							{
								this.generate = false;
								this.generate_manual = false;
								if (this.raw_file.fs != null)
								{
									this.raw_file.fs.Close();
									this.raw_file.fs.Dispose();
								}
							}
							GUI.color = Color.red;
							EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 337), (float)(319 + this.gui_y2 + num11 + num10), (float)130, (float)20), (this.create_area.tiles.x * this.create_area.tiles.y - this.heightmap_count_terrain).ToString(), EditorStyles.boldLabel);
						}
					}
				}
				else if (GUI.Button(new Rect((float)(this.guiWidth2 + 18), (float)(319 + this.gui_y2 + num11 + num10), (float)130, (float)36), new GUIContent("Stop", "Stop creating terrains.")))
				{
					this.create_terrain_loop = false;
					if (!this.global_script.map.export_heightmap_active && !this.global_script.map.export_image_active)
					{
						Application.runInBackground = false;
					}
					this.generate = false;
					if (this.raw_file.fs != null)
					{
						this.raw_file.fs.Close();
						this.raw_file.fs.Dispose();
					}
				}
				if (this.create_terrain_loop)
				{
					GUI.color = Color.red;
					EditorGUI.LabelField(new Rect((float)(this.guiWidth2 + 150), (float)(319 + this.gui_y2 + num11 + num10), (float)130, (float)36), (this.create_area.tiles.x * this.create_area.tiles.y - this.create_terrain_count).ToString());
				}
				GUI.color = global_script.map.color;
			}
			this.screen_rect = new Rect((float)0, (float)0, (float)this.guiWidth2, (float)this.gui_y);
			if (this.global_script.map_load || this.global_script.settings.myExt != null)
			{
			}
			if (this.global_script.map_load2 || this.global_script.settings.myExt2 != null)
			{
			}
			this.mouse_move = this.key.delta;
			if (this.key.button == 0 && this.key.clickCount == 2 && this.key.mousePosition.y > (float)20 && !this.current_area.resize && !this.check_in_rect())
			{
				this.stop_download();
				this.latlong_animate = this.latlong_mouse;
				this.animate_time_start = Time.realtimeSinceStartup;
				this.animate = true;
			}
			if (this.key.button == 0)
			{
				if (this.key.type == 0)
				{
					if (!this.check_in_rect())
					{
						this.map_scrolling = true;
					}
				}
				else if (this.key.type == EventType.MouseUp)
				{
					this.map_scrolling = false;
				}
				if (this.key.type == EventType.MouseDrag && (!this.check_in_rect() || this.map_scrolling) && this.map_scrolling && this.key.mousePosition.y > (float)0 && !this.current_area.resize)
				{
					this.animate = false;
					this.move_center(new Vector2(-this.mouse_move.x / this.global_script.map.mouse_sensivity, this.mouse_move.y / this.global_script.map.mouse_sensivity), true);
				}
			}
			if (this.key.type == EventType.ScrollWheel || this.key.type == EventType.KeyDown)
			{
				bool flag = false;
				if (this.key.delta.y > (float)0 || this.key.keyCode == KeyCode.Minus || this.key.keyCode == KeyCode.KeypadMinus)
				{
					if (this.global_script.map_zoom > 1)
					{
						if (this.zoom1 > (double)0)
						{
							this.zoom1 = (this.zoom1 - (double)1) / (double)2;
							if (this.zoom1 < (double)1)
							{
								this.zoom1 = (double)0;
							}
						}
						else if (this.zoom1 < (double)0)
						{
							this.zoom1_step /= (double)2;
							this.zoom1 += this.zoom1_step;
						}
						else
						{
							this.zoom1 = (double)-0.5f;
							this.zoom1_step = (double)-0.5f;
						}
						if (this.zoom2 > (double)0)
						{
							this.zoom2 = (this.zoom2 - (double)1) / (double)2;
							if (this.zoom2 < (double)1)
							{
								this.zoom2 = (double)0;
							}
						}
						else if (this.zoom2 < (double)0)
						{
							this.zoom2_step /= (double)2;
							this.zoom2 += this.zoom2_step;
						}
						else
						{
							this.zoom2 = (double)-0.5f;
							this.zoom2_step = (double)-0.5f;
						}
						if (this.zoom3 > (double)0)
						{
							this.zoom3 = (this.zoom3 - (double)1) / (double)2;
							if (this.zoom3 < (double)1)
							{
								this.zoom3 = (double)0;
							}
						}
						else if (this.zoom3 < (double)0)
						{
							this.zoom3_step /= (double)2;
							this.zoom3 += this.zoom3_step;
						}
						else
						{
							this.zoom3 = (double)-0.5f;
							this.zoom3_step = (double)-0.5f;
						}
						if (this.zoom4 > (double)0)
						{
							this.zoom4 = (this.zoom4 - (double)1) / (double)2;
							if (this.zoom4 < (double)1)
							{
								this.zoom4 = (double)0;
							}
						}
						else if (this.zoom4 < (double)0)
						{
							this.zoom4_step /= (double)2;
							this.zoom4 += this.zoom4_step;
						}
						else
						{
							this.zoom4 = (double)-0.5f;
							this.zoom4_step = (double)-0.5f;
						}
						this.convert_center();
						this.global_script.map_zoom = this.global_script.map_zoom - 1;
						flag = true;
						this.request_map_timer();
					}
				}
				else if ((this.key.delta.y < (float)0 || this.key.keyCode == KeyCode.Equals || this.key.keyCode == KeyCode.KeypadPlus) && this.global_script.map_zoom < 19)
				{
					if (this.zoom1 < (double)0)
					{
						this.zoom1 -= this.zoom1_step;
						this.zoom1_step *= (double)2;
						if (this.zoom1 > (double)-0.5f)
						{
							this.zoom1 = (double)0;
						}
					}
					else if (this.zoom1 > (double)0)
					{
						this.zoom1 = this.zoom1 * (double)2 + (double)1;
					}
					else
					{
						this.zoom1 = (double)1;
					}
					if (this.zoom2 < (double)0)
					{
						this.zoom2 -= this.zoom2_step;
						this.zoom2_step *= (double)2;
						if (this.zoom2 > (double)-0.5f)
						{
							this.zoom2 = (double)0;
						}
					}
					else if (this.zoom2 > (double)0)
					{
						this.zoom2 = this.zoom2 * (double)2 + (double)1;
					}
					else
					{
						this.zoom2 = (double)1;
					}
					if (this.zoom3 < (double)0)
					{
						this.zoom3 -= this.zoom3_step;
						this.zoom3_step *= (double)2;
						if (this.zoom3 > (double)-0.5f)
						{
							this.zoom3 = (double)0;
						}
					}
					else if (this.zoom3 > (double)0)
					{
						this.zoom3 = this.zoom3 * (double)2 + (double)1;
					}
					else
					{
						this.zoom3 = (double)1;
					}
					if (this.zoom4 < (double)0)
					{
						this.zoom4 -= this.zoom4_step;
						this.zoom4_step *= (double)2;
						if (this.zoom4 > (double)-0.5f)
						{
							this.zoom4 = (double)0;
						}
					}
					else if (this.zoom4 > (double)0)
					{
						this.zoom4 = this.zoom4 * (double)2 + (double)1;
					}
					else
					{
						this.zoom4 = (double)1;
					}
					this.convert_center();
					this.global_script.map_zoom = this.global_script.map_zoom + 1;
					flag = true;
					this.request_map_timer();
				}
				if (flag)
				{
					this.stop_download();
					this.button0 = true;
					this.time1 = Time.realtimeSinceStartup;
					this.zooming = true;
				}
			}
			if (this.global_script.map.preimage_edit.generate && this.global_script.map.preimage_edit.mode == 1)
			{
				float num12 = 0f;
				if (!this.global_script.map.preimage_edit.loop)
				{
					num12 = (float)1 - (float)this.global_script.map.preimage_edit.y1 * 1f / 768f;
				}
				else if (this.convert_texture)
				{
					num12 = (float)1 - (float)this.global_script.map.preimage_edit.y1 * 1f / (float)this.convert_texture.height;
				}
				GUI.color = new Color(num12, (float)1 - num12, (float)0, (float)2);
				if (this.global_script.map.preimage_edit.loop)
				{
					this.old_fontSize = GUI.skin.label.fontSize;
					this.old_fontStyle = GUI.skin.label.fontStyle;
					GUI.skin.label.fontSize = 17;
					GUI.skin.label.fontStyle = FontStyle.Bold;
					if (this.global_script.map.preimage_edit.loop_active)
					{
						GUI.Label(new Rect(this.position.width / (float)2 - (float)65, this.position.height / (float)2 + (float)10, (float)200, (float)25), "Generating " + (this.convert_area.tiles.x * this.convert_area.tiles.y - this.convert_area.preimage_count) + "...");
					}
					else
					{
						GUI.Label(new Rect(this.position.width / (float)2 - (float)52, this.position.height / (float)2 + (float)10, (float)200, (float)25), "Pause " + (this.convert_area.tiles.x * this.convert_area.tiles.y - this.convert_area.preimage_count) + "...");
					}
					GUI.skin.label.fontSize = this.old_fontSize;
					GUI.skin.label.fontStyle = this.old_fontStyle;
				}
				else
				{
					this.old_fontSize = GUI.skin.label.fontSize;
					this.old_fontStyle = GUI.skin.label.fontStyle;
					GUI.skin.label.fontSize = 17;
					GUI.skin.label.fontStyle = FontStyle.Bold;
					GUI.Label(new Rect(this.position.width / (float)2 + (float)350, this.position.height / (float)2 - (float)10, (float)200, (float)25), "Generating...");
					GUI.skin.label.fontSize = this.old_fontSize;
					GUI.skin.label.fontStyle = this.old_fontStyle;
				}
			}
			GUI.color = Color.white;
			if (this.notify_text.Length != 0)
			{
				if (this.notify_frame > 1)
				{
					this.ShowNotification(new GUIContent(this.notify_text));
					this.notify_text = string.Empty;
					this.notify_frame = 0;
				}
				this.notify_frame++;
			}
			if (this.global_script.map.export_heightmap_active || this.global_script.map.export_image_active)
			{
				this.Repaint();
			}
		}
	}

	public bool move_to_latlong(latlong_class latlong, float speed)
	{
		latlong_class latlong_class = this.global_script.pixel_to_latlong(new Vector2((float)0, (float)0), this.global_script.map_latlong_center, this.zoom);
		Vector2 vector = this.global_script.latlong_to_pixel(latlong, latlong_class, this.zoom, new Vector2(this.position.width, this.position.height));
		float num = vector.x - this.position.width / (float)2 - this.offmap.x;
		float num2 = -(vector.y - this.position.height / (float)2 + this.offmap.y);
		bool arg_11E_0;
		if (Mathf.Abs(num) < 0.01f && Mathf.Abs(num2) < 0.01f)
		{
			this.global_script.map_latlong_center = latlong;
			this.offmap = new Vector2((float)0, (float)0);
			this.request_map();
			this.Repaint();
			arg_11E_0 = true;
		}
		else
		{
			num /= (float)250 / speed;
			num2 /= (float)250 / speed;
			this.move_center(new Vector2(num, num2), false);
			arg_11E_0 = false;
		}
		return arg_11E_0;
	}

	public void move_center(Vector2 offset2, bool map)
	{
		this.offset = offset2;
		this.offmap += this.offset;
		if (this.zoom_pos1 != (double)0)
		{
			this.offmap1 += this.offset / (float)(this.zoom_pos1 + (double)1);
		}
		else
		{
			this.offmap1 += this.offset;
		}
		if (this.zoom_pos2 != (double)0)
		{
			this.offmap2 += this.offset / (float)(this.zoom_pos2 + (double)1);
		}
		else
		{
			this.offmap2 += this.offset;
		}
		if (this.zoom_pos3 != (double)0)
		{
			this.offmap3 += this.offset / (float)(this.zoom_pos3 + (double)1);
		}
		else
		{
			this.offmap3 += this.offset;
		}
		if (this.zoom_pos4 != (double)0)
		{
			this.offmap4 += this.offset / (float)(this.zoom_pos4 + (double)1);
		}
		else
		{
			this.offmap4 += this.offset;
		}
		if (map)
		{
			this.stop_download();
			this.request_map_timer();
		}
		this.Repaint();
	}

	public void convert_center()
	{
		this.global_script.map_latlong_center = this.global_script.pixel_to_latlong(new Vector2(this.offmap.x, -this.offmap.y), this.global_script.map_latlong_center, this.zoom);
		this.offmap = new Vector2((float)0, (float)0);
	}

	public void request_map_timer()
	{
		this.time1 = Time.realtimeSinceStartup;
		this.request1 = true;
		this.request2 = true;
		if (!this.global_script.map.button_image_editor)
		{
			this.request3 = true;
			this.request4 = true;
		}
		this.Repaint();
	}

	public void request_map()
	{
		if (this.global_script)
		{
			this.request_map1();
			this.request_map2();
			if (!this.global_script.map.button_image_editor)
			{
				this.request_map3();
				this.request_map4();
			}
			this.Repaint();
		}
	}

	public void reset_texture(Texture2D texture)
	{
		for (int y = 0; y < texture.height; y++)
		{
			for (int x = 0; x < texture.width; x++)
			{
                texture.SetPixel(x, y, new Color(0, 0, 0, 0));
            }
		}
        texture.Apply();
	}

	public void request_map1()
	{
		if (this.global_script.map.active)
		{
			this.stop_download_map1();
			this.request_load1 = true;
			this.global_script.map_load = false;
			this.global_script.map_latlong = this.global_script.pixel_to_latlong(new Vector2((float)-400, (float)0), this.global_script.map_latlong_center, (double)this.global_script.map_zoom);
			string text = "http://dev.virtualearth.net/REST/v1/Imagery/Map/" + this.global_script.map.type.ToString() + "/" + this.global_script.map_latlong.latitude + "," + this.global_script.map_latlong.longitude + "/" + this.global_script.map_zoom + "?&mapSize=800,800&key=" + this.global_script.map.bingKey[this.global_script.map.bingKey_selected].key;
            if (global_script.settings.myExt != null) global_script.settings.myExt.Dispose();
            this.global_script.settings.myExt = new WWW(text);
			this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls = this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls + 1;
		}
	}

	public void request_map2()
	{
		if (this.global_script.map.active)
		{
			this.stop_download_map2();
			this.request_load2 = true;
			this.global_script.map_load = false;
			this.global_script.map_latlong.longitude = this.global_script.pixel_to_latlong(new Vector2((float)400, (float)0), this.global_script.map_latlong_center, (double)this.global_script.map_zoom).longitude;
			string text = "http://dev.virtualearth.net/REST/v1/Imagery/Map/" + this.global_script.map.type.ToString() + "/" + this.global_script.map_latlong.latitude + "," + this.global_script.map_latlong.longitude + "/" + this.global_script.map_zoom + "?&mapSize=800,800&key=" + this.global_script.map.bingKey[this.global_script.map.bingKey_selected].key;
            if (global_script.settings.myExt2 != null) global_script.settings.myExt2.Dispose();
            this.global_script.settings.myExt2 = new WWW(text);
			this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls = this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls + 1;
		}
	}

	public void request_map3()
	{
		if (this.global_script.map.active)
		{
			if (this.global_script.map_zoom > 2)
			{
				this.stop_download_map3();
				this.request_load3 = true;
				this.global_script.map_load3 = false;
				string text = "http://dev.virtualearth.net/REST/v1/Imagery/Map/" + this.global_script.map.type.ToString() + "/" + this.global_script.map_latlong_center.latitude + "," + this.global_script.map_latlong_center.longitude + "/" + (this.global_script.map_zoom - 2) + "?&mapSize=800,800&key=" + this.global_script.map.bingKey[this.global_script.map.bingKey_selected].key;
                if (global_script.settings.myExt3 != null) global_script.settings.myExt3.Dispose();
                this.global_script.settings.myExt3 = new WWW(text);
				this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls = this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls + 1;
			}
		}
	}

	public void request_map4()
	{
		if (this.global_script.map.active)
		{
			if (this.global_script.map_zoom > 3)
			{
				this.stop_download_map4();
				this.request_load4 = true;
				this.global_script.map_load4 = false;
				string text = "http://dev.virtualearth.net/REST/v1/Imagery/Map/" + this.global_script.map.type.ToString() + "/" + this.global_script.map_latlong_center.latitude + "," + this.global_script.map_latlong_center.longitude + "/" + (this.global_script.map_zoom - 3) + "?&mapSize=800,800&key=" + this.global_script.map.bingKey[this.global_script.map.bingKey_selected].key;
                if (global_script.settings.myExt4 != null) global_script.settings.myExt4.Dispose();
                this.global_script.settings.myExt4 = new WWW(text);
				this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls = this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls + 1;
			}
		}
	}
    
    public void stop_download()
	{
		this.stop_download_map1();
		this.stop_download_map2();
		this.stop_download_map3();
		this.stop_download_map4();
	}

	public void stop_download_map1()
	{
		if (this.request_load1)
		{
			this.global_script.map_load = false;
			if (this.global_script.settings.myExt != null)
			{
				this.global_script.settings.myExt.Dispose();
				this.global_script.settings.myExt = null;
			}
		}
		this.request_load1 = false;
	}

	public void stop_download_map2()
	{
		if (this.request_load2)
		{
			this.global_script.map_load2 = false;
			if (this.global_script.settings.myExt2 != null)
			{
				this.global_script.settings.myExt2.Dispose();
				this.global_script.settings.myExt2 = null;
			}
		}
		this.request_load2 = false;
	}

	public void stop_download_map3()
	{
		if (this.request_load3)
		{
			this.global_script.map_load3 = false;
			if (this.global_script.settings.myExt3 != null)
			{
				this.global_script.settings.myExt3.Dispose();
				this.global_script.settings.myExt3 = null;
			}
		}
		this.request_load3 = false;
	}

	public void stop_download_map4()
	{
		if (this.request_load4)
		{
			this.global_script.map_load4 = false;
			if (this.global_script.settings.myExt4 != null)
			{
				this.global_script.settings.myExt4.Dispose();
				this.global_script.settings.myExt4 = null;
			}
		}
		this.request_load4 = false;
	}

	public void get_elevation_info(latlong_class latlong)
	{
        if (global_script.map.elExt_check != null) global_script.map.elExt_check.Dispose();
        this.global_script.map.elExt_check = new WWW("http://dev.virtualearth.net/REST/v1/Elevation/List?points=" + latlong.latitude.ToString() + "," + latlong.longitude.ToString() + "&heights=ellipsoid&key=" + this.global_script.map.bingKey[this.global_script.map.bingKey_selected].key);
		this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls = this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls + 1;
		this.global_script.map.elExt_check_loaded = false;
	}

	public void drawGUIBox(Rect rect, string text, Color backgroundColor, Color highlightColor, Color textColor)
	{
		GUI.color = new Color((float)1, (float)1, (float)1, backgroundColor.a);
		EditorGUI.DrawPreviewTexture(new Rect(rect.x, rect.y + (float)19, rect.width, rect.height - (float)19), this.global_script.tex2);
		GUI.color = new Color((float)1, (float)1, (float)1, highlightColor.a);
		EditorGUI.DrawPreviewTexture(new Rect(rect.x, rect.y, rect.width, (float)19), this.global_script.tex3);
		GUI.color = textColor;
		EditorGUI.LabelField(new Rect(rect.x, rect.y + (float)1, rect.width, (float)19), text, EditorStyles.boldLabel);
		this.gui_y = (int)((float)this.gui_y + (rect.height + (float)2));
		this.gui_height = 0;
	}

	public void Update()
	{
		if (this.global_script)
		{
			this.check_content_done();
			if (Time.realtimeSinceStartup > this.save_global_time + this.global_script.settings.save_global_timer * (float)60)
			{
				this.save_global_settings();
				this.save_global_time = Time.realtimeSinceStartup;
			}
			if (this.global_script.map.preimage_edit.generate)
			{
				if (this.global_script.map.preimage_edit.mode == 2)
				{
					this.convert_textures_raw(this.convert_area);
				}
				else
				{
					this.image_edit_apply();
				}
			}
			if (this.combine_generate)
			{
				this.combine_textures();
				this.Repaint();
			}
			if (this.slice_generate)
			{
				this.slice_textures();
				this.Repaint();
			}
			if (this.import_settings_call)
			{
				this.import_settings_call = false;
				if (this.import_jpg_call)
				{
					this.import_jpg_call = false;
					this.global_script.set_image_import_settings(this.import_jpg_path, false, this.import_image_area.textureFormat, TextureWrapMode.Clamp, this.import_image_area.resolution, this.import_image_area.mipmapEnabled, this.import_image_area.filterMode, this.import_image_area.anisoLevel, 127);
				}
				if (this.import_png_call)
				{
					this.import_png_call = false;
					this.global_script.set_image_import_settings(this.import_png_path, false, this.import_image_area.textureFormat, TextureWrapMode.Clamp, this.import_image_area.resolution, this.import_image_area.mipmapEnabled, this.import_image_area.filterMode, this.import_image_area.anisoLevel, 127);
				}
			}
			if (this.zooming)
			{
				this.zoom_pos = (double)Mathf.Lerp((float)this.zoom_pos, (float)this.zoom1, 0.1f);
				this.zoom_pos1 = (double)Mathf.Lerp((float)this.zoom_pos1, (float)this.zoom1, 0.1f);
				this.zoom_pos2 = (double)Mathf.Lerp((float)this.zoom_pos2, (float)this.zoom2, 0.1f);
				this.zoom_pos3 = (double)Mathf.Lerp((float)this.zoom_pos3, (float)this.zoom3, 0.1f);
				this.zoom_pos4 = (double)Mathf.Lerp((float)this.zoom_pos4, (float)this.zoom4, 0.1f);
                if (Mathf.Abs((float)(zoom_pos1 - zoom1)) < 0.001)
                {
                    zoom_pos = zoom1;
                    zoom_pos1 = zoom1;
                    zoom_pos2 = zoom2;
                    zoom_pos3 = zoom3;
                    zoom_pos4 = zoom4;
                    zooming = false;
                }
				this.Repaint();
			}
			if (this.animate && this.move_to_latlong(this.latlong_animate, (float)45))
			{
				this.animate = false;
			}
			if (this.create_terrain_loop && !this.generate)
			{
				this.create_terrain(this.terrain_region.area[0], this.terrain_region.area[0].terrains[0], Application.dataPath + "/Terrains", this.terrain_parent.transform);
				this.Repaint();
			}
			if (this.apply_import_settings)
			{
				tile_class tile_class = this.calc_terrain_tile(this.import_settings_count, this.terrain_region.area[0].tiles_select);
				if (tile_class == null)
				{
					return;
				}
				if (this.global_script.map.export_jpg)
				{
					string text = this.create_area.export_image_path.Replace(Application.dataPath, "Assets") + "/" + this.create_area.export_image_filename + "_x" + tile_class.x.ToString() + "_y" + tile_class.y.ToString() + ".jpg";
					if (!File.Exists(text))
					{
						this.notify_text = text + " doesn't exist! Make sure the image tiles are the same as the exported image tiles";
						Debug.Log(text + " doesn't exist! Make sure the image tiles are the same as the exported image tiles.");
					}
					else
					{
						this.global_script.set_image_import_settings(text, false, this.create_area.textureFormat, TextureWrapMode.Clamp, this.create_area.maxTextureSize, this.create_area.mipmapEnabled, this.create_area.filterMode, this.create_area.anisoLevel, 124);
					}
				}
				if (this.global_script.map.export_png)
				{
					string text = this.create_area.export_image_path.Replace(Application.dataPath, "Assets") + "/" + this.create_area.export_image_filename + "_x" + tile_class.x.ToString() + "_y" + tile_class.y.ToString() + ".png";
					if (!File.Exists(text))
					{
						this.notify_text = text + " doesn't exist! Make sure the image tiles are the same as the exported image tiles";
						Debug.Log(text + " doesn't exist! Make sure the image tiles are the same as the exported image tiles.");
					}
					else
					{
						this.global_script.set_image_import_settings(text, false, this.create_area.textureFormat, TextureWrapMode.Clamp, this.create_area.maxTextureSize, this.create_area.mipmapEnabled, this.create_area.filterMode, this.create_area.anisoLevel, 124);
					}
				}
				this.import_settings_count++;
				if (this.import_settings_count > this.create_area.tiles.x * this.create_area.tiles.y - 1)
				{
					this.apply_import_settings = false;
				}
				this.Repaint();
			}
			if (this.generate)
			{
				this.generate_heightmap2();
			}
			if (this.request1 && Time.realtimeSinceStartup - this.time1 > 1.5f)
			{
				this.request1 = false;
				this.convert_center();
				this.request_map1();
			}
			if (this.request2 && Time.realtimeSinceStartup - this.time1 > 1.7f)
			{
				this.request2 = false;
				this.convert_center();
				this.request_map2();
			}
			if (this.request3 && Time.realtimeSinceStartup - this.time1 > 1.9f)
			{
				this.request3 = false;
				this.convert_center();
				this.request_map3();
			}
			if (this.request4 && Time.realtimeSinceStartup - this.time1 > 2.1f)
			{
				this.request4 = false;
				this.convert_center();
				this.request_map4();
			}
			if (this.global_script.map.elExt_check != null && this.global_script.map.elExt_check.isDone && !this.global_script.map.elExt_check_loaded)
			{
				if (string.IsNullOrEmpty(this.global_script.map.elExt_check.error))
				{
					string text2 = this.global_script.map.elExt_check.text;
					string text3 = text2;
					int num = text2.IndexOf("zoomLevel");
					int num2 = 0;
					int num3 = 0;
					text2 = text2.Substring(num + 11);
					num = text2.IndexOf("}");
					text2 = text2.Substring(0, num);
					num3 = (int)short.Parse(text2);
					num = text3.IndexOf("elevations");
					text3 = text3.Substring(num + 13);
					num = text3.IndexOf("]");
					text3 = text3.Substring(0, num);
					num2 = (int)short.Parse(text3);
					if (this.global_script.map.elExt_check_assign)
					{
						if (this.requested_area != null)
						{
							this.requested_area.center_height = num2;
							this.requested_area.elevation_zoom = num3;
							if (this.requested_area.heightmap_zoom == 0)
							{
								this.requested_area.heightmap_zoom = this.requested_area.elevation_zoom;
							}
							this.calc_heightmap_settings(this.requested_area);
						}
						this.global_script.map.elExt_check_assign = false;
					}
					else
					{
						this.notify_text = "Zoom Level: " + num3 + "-> " + Mathf.Round((float)this.global_script.calc_latlong_area_resolution(this.latlong_mouse, (double)num3)) + " (m/p), Height: " + num2 + " (m)";
						this.Repaint();
					}
				}
				else
				{
                    // Debug.Log(this.global_script.map.elExt_check.error);
					this.Repaint();
				}
				this.global_script.map.elExt_check_loaded = true;
			}
			if (global_script.settings.myExt != null && global_script.settings.myExt.isDone && !global_script.map_load)
			{
				global_script.map_load = true;
				if (!global_script.map1)
				{
					global_script.map1 = new Texture2D(800, 800, TextureFormat.RGBA32, false, true);
					global_script.map1.wrapMode = TextureWrapMode.Clamp;
				}
				global_script.settings.myExt.LoadImageIntoTexture(global_script.map1);
				if (!global_script.map_load2)
				{
					global_script.map_combine = false;
				}
				if (!global_script.map0)
				{
					global_script.map0 = new Texture2D(1600, 768, TextureFormat.RGBA32, false, true);
				}
				pixels = global_script.map1.GetPixels(0, 32, 800, 768);
				global_script.map0.SetPixels(0, 0, 800, 768, pixels);
			}
			if (global_script.settings.myExt2 != null && global_script.settings.myExt2.isDone && !global_script.map_load2)
			{
				if (!global_script.map2)
				{
					global_script.map2 = new Texture2D(800, 800, TextureFormat.RGBA32, false, true);
					global_script.map2.wrapMode = TextureWrapMode.Clamp;
				}
				offmap2 = new Vector2((float)0, (float)0);
				zoom2 = (double)0;
				zoom_pos2 = (double)0;
				if (!global_script.map_load)
				{
					global_script.map_combine = false;
				}
				Repaint();
				global_script.map_load2 = true;
				global_script.settings.myExt2.LoadImageIntoTexture(global_script.map2);
				if (!global_script.map0)
				{
					global_script.map0 = new Texture2D(1600, 768, TextureFormat.RGBA32, false, true);
				}
				if (!global_script.map.button_image_editor)
				{
					pixels = global_script.map2.GetPixels(0, 32, 800, 768);
					global_script.map0.SetPixels(800, 0, 800, 768, pixels);
				}
			}
			if (global_script.map_load && !global_script.map_combine && (global_script.map_load2 || global_script.map.button_image_editor))
			{
				global_script.map0.Apply();
				global_script.map_combine = true;
				if (global_script.map.button_image_editor)
				{
					image_generate_begin();
				}
				global_script.map_zoom_old = global_script.map_zoom;
				offmap1 = new Vector2((float)0, (float)0);
				zoom1 = (double)0;
				zoom_pos1 = (double)0;
				Repaint();
			}
			if (global_script.settings.myExt3 != null && global_script.settings.myExt3.isDone && !global_script.map_load3)
			{
				if (!global_script.map3)
				{
					global_script.map3 = new Texture2D(800, 768, TextureFormat.RGBA32, false, true);
					global_script.map3.wrapMode = TextureWrapMode.Clamp;
				}
				global_script.settings.myExt3.LoadImageIntoTexture(global_script.map3);
				global_script.map_load3 = true;
				if (global_script.map3.width == 800 && global_script.map3.height == 800)
				{
					pixels = global_script.map3.GetPixels(0, 32, 800, 768);
					global_script.map3.Resize(800, 768);
					global_script.map3.SetPixels(0, 0, 800, 768, pixels);
					global_script.map3.Apply();
				}
				zoom3 = (double)0;
				zoom_pos3 = (double)0;
				offmap3 = new Vector2((float)0, (float)0);
				global_script.map_zoom3 = global_script.map_zoom;
				Repaint();
			}
			if (global_script.settings.myExt4 != null && global_script.settings.myExt4.isDone && !global_script.map_load4)
			{
				if (!global_script.map4)
				{
					global_script.map4 = new Texture2D(800, 768, TextureFormat.RGBA32, false, true);
					global_script.map4.wrapMode = TextureWrapMode.Clamp;
				}
				global_script.settings.myExt4.LoadImageIntoTexture(global_script.map4);
				global_script.map_load4 = true;
				if (global_script.map4.width == 800 && global_script.map4.height == 800)
				{
					pixels = global_script.map4.GetPixels(0, 32, 800, 768);
					global_script.map4.Resize(800, 768);
					global_script.map4.SetPixels(0, 0, 800, 768, pixels);
					global_script.map4.Apply();
				}
				offmap4 = new Vector2((float)0, (float)0);
				zoom_pos4 = (double)0;
				zoom4 = (double)0;
				Repaint();
			}
			if (this.global_script.map.export_heightmap_active)
			{
				if (this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls > 48000)
				{
					this.check_free_key();
				}
				if (this.global_script.map.export_heightmap_continue)
				{
					this.global_script.map.export_heightmap_timeEnd = Time.realtimeSinceStartup;
				}
				for (int i = 0; i < this.global_script.map.elExt.Count; i++)
				{
                    ext_class elExt = global_script.map.elExt[i];
                    
                    if (elExt.loaded && !this.global_script.map.export_heightmap.last_tile)
					{
                        if (this.global_script.map.export_heightmap_continue && Time.realtimeSinceStartup > elExt.startTime)
						{
							elExt.bres = new Vector2((float)32, (float)32);
							if (this.export_heightmap_area.export_heightmap_not_fit)
							{
								if (this.global_script.map.export_heightmap.tile.x == this.global_script.map.export_heightmap.tiles.x - 1)
								{
									elExt.bres.x = this.export_heightmap_area.export_heightmap_bres.x;
								}
								if (this.global_script.map.export_heightmap.tile.y == this.global_script.map.export_heightmap.tiles.y - 1)
								{
									elExt.bres.y = this.export_heightmap_area.export_heightmap_bres.y;
								}
							}
							elExt.latlong_area = this.global_script.calc_latlong_area_by_tile(this.global_script.map.export_heightmap_area.latlong1, this.global_script.map.export_heightmap.tile, (double)this.global_script.map.export_heightmap_zoom, 32, new Vector2(elExt.bres.x, elExt.bres.y), this.export_heightmap_area.heightmap_offset_e);
							elExt.tile.x = this.global_script.map.export_heightmap.tile.x;
							elExt.tile.y = this.global_script.map.export_heightmap.tile.y;
							elExt.url = "http://dev.virtualearth.net/REST/v1/Elevation/Bounds?bounds=" + elExt.latlong_area.latlong2.latitude.ToString() + "," + elExt.latlong_area.latlong1.longitude.ToString() + "," + elExt.latlong_area.latlong1.latitude.ToString() + "," + elExt.latlong_area.latlong2.longitude.ToString() + "&rows=" + elExt.bres.y.ToString() + "&cols=" + elExt.bres.x.ToString() + "&heights=ellipsoid&key=" + this.global_script.map.bingKey[this.global_script.map.bingKey_selected].key;
							this.pull_elevation(i);
							elExt.loaded = false;
							if (this.jump_export_heightmap_tile())
							{
								this.global_script.map.export_heightmap.last_tile = true;
							}
						}
					}
					else if (elExt.pull != null)
					{
						if (!string.IsNullOrEmpty(elExt.pull.error))
						{
                            string error = elExt.pull.error;
                            elExt.pull.Dispose();
                            pull_elevation(i);
                            elExt.error = 2;
                            if (!error.Contains("429")) {
                                Debug.Log(elExt.pull.error);
                                if (elExt.download_error++ > 24)
                                {
                                    this.ElevationConvertZero(i);
                                    elExt.loaded = true;
                                    elExt.download_error = 0;
                                }
                            }
						}
						if (Time.realtimeSinceStartup > elExt.startTime + (float)this.global_script.map.timeOut)
						{
							elExt.pull.Dispose();
							this.pull_elevation(i);
							elExt.download_error = 0;
						}
						if (elExt.pull.isDone)  
						{
							if (this.ElevationConvert(i))
							{
								elExt.loaded = true;
                                elExt.startTime = Time.realtimeSinceStartup + 0.1f;
							}
							elExt.download_error = 0;
						}
					}
				}
				if (this.global_script.map.export_heightmap.last_tile && this.check_elevation_pulls_done())
				{
					Debug.Log("Exporting heightmap Region: " + this.export_heightmap_region.name + " -> Area: " + this.export_heightmap_area.name + " done.");
					this.stop_elevation_pull(this.export_heightmap_region, this.export_heightmap_area);
				}
			}
			if (this.global_script.map.export_image_active)
			{
				if (this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls > 48)
				{
					this.check_free_key();
				}
				if (this.global_script.map.export_image_continue)
				{
					this.global_script.map.export_image_timeEnd = Time.realtimeSinceStartup;
				}
				for (int j = 0; j < this.global_script.map.texExt.Count; j++)
				{
                    ext_class texExt = global_script.map.texExt[j];

					if (texExt.converted && !this.global_script.map.export_image.last_tile)
					{
						if (this.global_script.map.export_image_continue)
						{
							tile_class tile_class2 = new tile_class();
							tile_class2.x = this.global_script.map.export_image.subtiles.x * this.global_script.map.export_image.tile.x + this.global_script.map.export_image.subtile.x;
							tile_class2.y = this.global_script.map.export_image.subtiles.y * this.global_script.map.export_image.tile.y + this.global_script.map.export_image.subtile.y;
							texExt.tile.x = this.global_script.map.export_image.tile.x;
							texExt.tile.y = this.global_script.map.export_image.tile.y;
							texExt.subtile.x = this.global_script.map.export_image.subtile.x;
							texExt.subtile.y = this.global_script.map.export_image.subtile.y;
							texExt.latlong_center = this.global_script.calc_latlong_center_by_tile(this.global_script.map.export_image_area.latlong1, this.global_script.map.export_image.tile, this.global_script.map.export_image.subtile, this.global_script.map.export_image.subtiles, (double)this.global_script.map.export_image_zoom, 512, this.export_image_area.image_offset_e);
							texExt.latlong_area = this.global_script.calc_latlong_area_by_tile(this.global_script.map.export_image_area.latlong1, tile_class2, (double)this.global_script.map.export_image_zoom, 512, new Vector2((float)512, (float)512), this.export_image_area.image_offset_e);
							texExt.url = "http://dev.virtualearth.net/REST/v1/Imagery/Map/" + this.global_script.map.type.ToString() + "/" + texExt.latlong_center.latitude + "," + texExt.latlong_center.longitude + "/" + this.global_script.map.export_image_zoom + "?&mapSize=512,544&key=" + this.global_script.map.bingKey[this.global_script.map.bingKey_selected].key;
							this.pull_image(j);
							texExt.loaded = false;
							if (this.jump_export_image_tile())
							{
								this.global_script.map.export_image.last_tile = true;
							}
						}
					}
					else if (texExt.pull != null && !texExt.converted)
					{
						if (!string.IsNullOrEmpty(texExt.pull.error))
						{
							texExt.pull.Dispose();
							texExt.pull = null;
							this.pull_image(j);
						}
						if (Time.realtimeSinceStartup > texExt.startTime + (float)this.global_script.map.timeOut)
						{
							texExt.pull.Dispose();
							texExt.pull = null;
							this.pull_image(j);
						}
						if (texExt.pull.isDone && this.texConvert(j) && texExt.error == 0)
						{
							texExt.loaded = true;
						}
					}
				}
			}
		}
	}

	public void pick_done()
	{
		this.latlong_area = this.global_script.calc_latlong_area_rounded(this.current_area.upper_left, this.latlong_mouse, (double)this.current_area.image_zoom, this.current_area.resolution, this.key.shift, 8);
		this.current_area.lower_right = this.latlong_area.latlong2;
		this.current_area.center = this.global_script.calc_latlong_center(this.current_area.upper_left, this.current_area.lower_right, this.zoom, new Vector2(this.position.width, this.position.height));
		this.requested_area = this.current_area;
		this.global_script.map.elExt_check_assign = true;
		this.get_elevation_info(this.current_area.center);
		this.current_area.select = 0;
		this.global_script.map.mode = 0;
	}

	public bool check_image_tile_pulls_done(int texExt_index)
	{
		int num = 0;
		int arg_F8_0;
		for (int i = 0; i < this.global_script.map.texExt.Count; i++)
		{
			if (this.global_script.map.texExt[i].tile.x == this.global_script.map.texExt[texExt_index].tile.x && this.global_script.map.texExt[i].tile.y == this.global_script.map.texExt[texExt_index].tile.y && this.global_script.map.texExt[i].loaded)
			{
				num++;
				if (num == this.global_script.map.export_image.subtiles_total)
				{
					arg_F8_0 = 1;
					return arg_F8_0 != 0;
				}
			}
		}
		arg_F8_0 = 0;
		return arg_F8_0 != 0;
	}

	public void pull_elevation(int index)
	{
        ext_class elExt = global_script.map.elExt[index];

		elExt.zero_error = 0;
		if (elExt.pull != null)
		{
			elExt.pull.Dispose();
		}
		elExt.pull = new WWW(elExt.url);
		elExt.startTime = Time.realtimeSinceStartup;
		this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls = this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls + 1;
	}

	public void pull_elevation_zerro(int index)
	{
        ext_class elExt = global_script.map.elExt[index];

        if (elExt.pull != null)
		{
			elExt.pull.Dispose();
		}
		elExt.pull = new WWW(elExt.url);
		elExt.startTime = Time.realtimeSinceStartup;
		this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls = this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls + 1;
	}

	public void pull_image(int index)
	{
        ext_class texExt = this.global_script.map.texExt[index];

        texExt.converted = false;
		texExt.zero_error = 0;
		if (texExt.pull != null)
		{
			texExt.pull.Dispose();
		}
		texExt.pull = new WWW(texExt.url);
		texExt.startTime = Time.realtimeSinceStartup;
		this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls = this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls + 1;
	}

	public bool check_elevation_pulls_done()
	{
		int arg_4D_0;
		for (int i = 0; i < this.global_script.map.elExt.Count; i++)
		{
			if (!this.global_script.map.elExt[i].loaded)
			{
				arg_4D_0 = 0;
				return arg_4D_0 != 0;
			}
		}
		arg_4D_0 = 1;
		return arg_4D_0 != 0;
	}

	public bool check_image_pulls_done()
	{
		int arg_4D_0;
		for (int i = 0; i < this.global_script.map.texExt.Count; i++)
		{
			if (!this.global_script.map.texExt[i].converted)
			{
				arg_4D_0 = 0;
				return arg_4D_0 != 0;
			}
		}
		arg_4D_0 = 1;
		return arg_4D_0 != 0;
	}

	public void check_export_heightmap_call()
	{
		for (int i = 0; i < this.global_script.map.region.Count; i++)
		{
			for (int j = 0; j < this.global_script.map.region[i].area.Count; j++)
			{
				if (this.global_script.map.region[i].area[j].export_heightmap_call)
				{
					this.global_script.map.region[i].area[j].export_heightmap_call = false;
					this.start_elevation_pull(this.global_script.map.region[i], this.global_script.map.region[i].area[j]);
					return;
				}
			}
		}
	}

	public void check_export_image_active()
	{
		for (int i = 0; i < this.global_script.map.region.Count; i++)
		{
			for (int j = 0; j < this.global_script.map.region[i].area.Count; j++)
			{
				if (this.global_script.map.region[i].area[j].export_image_call)
				{
					this.global_script.map.region[i].area[j].export_image_call = false;
					this.start_image_pull(this.global_script.map.region[i], this.global_script.map.region[i].area[j]);
					return;
				}
			}
		}
	}

	public void stop_all_elevation_pull()
	{
		for (int i = 0; i < this.global_script.map.region.Count; i++)
		{
			this.stop_elevation_pull_region(this.global_script.map.region[i]);
		}
	}

	public void stop_elevation_pull(map_region_class region1, map_area_class area1)
	{
		this.global_script.map.export_heightmap_active = false;
		area1.export_heightmap_active = false;
		if (!this.global_script.map.export_image_active)
		{
			Application.runInBackground = false;
		}
		if (fs != null)
		{
			this.fs.Close();
			this.fs.Dispose();
			this.fs = null;
		}
		AssetDatabase.Refresh();
		this.check_export_heightmap_call();
		this.check_export_image_active();
	}

	public void stop_elevation_pull_region(map_region_class region1)
	{
		int i = 0;
		for (i = 0; i < region1.area.Count; i++)
		{
			region1.area[i].export_heightmap_call = false;
		}
		for (i = 0; i < region1.area.Count; i++)
		{
			if (region1.area[i].export_heightmap_active)
			{
				this.stop_elevation_pull(region1, region1.area[i]);
			}
		}
	}

	public void stop_all_image_pull()
	{
		for (int i = 0; i < this.global_script.map.region.Count; i++)
		{
			this.stop_image_pull_region(this.global_script.map.region[i]);
		}
	}

	public void stop_image_pull_region(map_region_class region1)
	{
		int i = 0;
		for (i = 0; i < region1.area.Count; i++)
		{
			region1.area[i].export_image_call = false;
		}
		for (i = 0; i < region1.area.Count; i++)
		{
			if (region1.area[i].export_image_active)
			{
				this.stop_image_pull(region1, region1.area[i], false);
			}
		}
	}

	public void stop_image_pull(map_region_class region1, map_area_class area1, bool import_settings)
	{
		area1.export_image_active = false;
		this.global_script.map.export_image_active = false;
		if (area1.export_image_import_settings && import_settings)
		{
			this.start_image_import_settings(area1);
		}
		if (this.global_script.map.file_tex2 != null)
		{
			this.global_script.map.file_tex2.Close();
		}
		if (this.global_script.map.file_tex3 != null)
		{
			this.global_script.map.file_tex3.Close();
		}
		if (!this.global_script.map.export_heightmap_active)
		{
			Application.runInBackground = false;
		}
		AssetDatabase.Refresh();
		this.check_export_image_active();
		this.check_export_heightmap_call();
	}

	public void start_image_pull_region(map_region_class region1)
	{
		for (int i = 0; i < region1.area.Count; i++)
		{
			if (!region1.area[i].export_image_active && !region1.area[i].export_image_call)
			{
				this.start_image_pull(region1, region1.area[i]);
			}
		}
	}

	public void start_elevation_pull_region(map_region_class region1)
	{
		for (int i = 0; i < region1.area.Count; i++)
		{
			if (!region1.area[i].export_heightmap_active && !region1.area[i].export_heightmap_call)
			{
				this.start_elevation_pull(region1, region1.area[i]);
			}
		}
	}

	public void start_elevation_pull(map_region_class region1, map_area_class area1)
	{
		if (area1.export_heightmap_active)
		{
			this.stop_elevation_pull(region1, area1);
		}
		else if (area1.export_heightmap_call)
		{
			area1.export_heightmap_call = false;
		}
		else if (this.global_script.map.export_heightmap_active || this.global_script.map.export_image_active)
		{
			area1.export_heightmap_call = true;
		}
		else
		{
			Application.runInBackground = true;
			this.global_script.map.export_heightmap.tiles.x = (int)Mathf.Ceil(area1.heightmap_resolution.x / (float)32);
			this.global_script.map.export_heightmap.tiles.y = (int)Mathf.Ceil(area1.heightmap_resolution.y / (float)32);
			if ((float)this.global_script.map.export_heightmap.tiles.x != area1.heightmap_resolution.x / (float)32 || (float)this.global_script.map.export_heightmap.tiles.y != area1.heightmap_resolution.y / (float)32)
			{
				area1.export_heightmap_not_fit = true;
				area1.export_heightmap_bres.x = area1.heightmap_resolution.x - Mathf.Floor(area1.heightmap_resolution.x / (float)32) * (float)32;
				area1.export_heightmap_bres.y = area1.heightmap_resolution.y - Mathf.Floor(area1.heightmap_resolution.y / (float)32) * (float)32;
				if (area1.export_heightmap_bres.x == (float)0)
				{
					area1.export_heightmap_bres.x = (float)32;
				}
				if (area1.export_heightmap_bres.y == (float)0)
				{
					area1.export_heightmap_bres.y = (float)32;
				}
			}
			else
			{
				area1.export_heightmap_not_fit = false;
			}
			this.create_elExt();
			this.global_script.map.export_heightmap.last_tile = false;
			this.global_script.map.export_heightmap.tile.reset();
			this.global_script.map.export_heightmap_zoom = area1.heightmap_zoom;
			this.global_script.map.export_heightmap_area.latlong1 = area1.upper_left;
			this.global_script.map.export_heightmap_area.latlong2 = area1.lower_right;
			if (this.bytes == null)
			{
				this.bytes = new byte[2048];
			}
			else if (this.bytes.Length < 2048)
			{
				this.bytes = new byte[2048];
			}
			this.open_stream(area1.export_heightmap_path, area1.export_heightmap_filename + ".Raw");
			this.global_script.map.export_heightmap_timeStart = Time.realtimeSinceStartup;
			this.global_script.map.export_heightmap_timePause = Time.realtimeSinceStartup;
			this.global_script.map.export_heightmap_timeEnd = Time.realtimeSinceStartup;
			this.global_script.map.export_heightmap_active = true;
			area1.export_heightmap_active = true;
			this.export_heightmap_region = region1;
			this.export_heightmap_area = area1;
			if (area1.normalizeHeightmap)
			{
				string text = area1.export_heightmap_path + "/" + area1.export_heightmap_filename + "_N.Raw";
				if (File.Exists(text))
				{
					FileUtil.DeleteFileOrDirectory(text);
					Debug.Log("Deleting the old normalized heightmap: " + text);
				}
			}
			this.global_script.map.mode = 0;
		}
	}

	public void start_image_pull(map_region_class region1, map_area_class area1)
	{
		if (area1.export_image_active)
		{
			this.stop_image_pull(region1, area1, false);
		}
		else if (area1.export_image_call)
		{
			area1.export_image_call = false;
		}
		else if (this.global_script.map.export_image_active || this.global_script.map.export_heightmap_active)
		{
			area1.export_image_call = true;
		}
		else
		{
			Application.runInBackground = true;
			this.global_script.map.export_image.tiles = area1.tiles;
			this.global_script.map.export_image.subtiles.x = area1.resolution / 512;
			this.global_script.map.export_image.subtiles.y = area1.resolution / 512;
			this.global_script.map.export_image.subtiles_total = (int)Mathf.Pow((float)(area1.resolution / 512), (float)2);
			this.create_texExt();
			this.global_script.map.export_image.tile.x = this.current_area.start_tile.x;
			this.global_script.map.export_image.tile.y = this.current_area.start_tile.y;
			this.global_script.map.tex2_tile.x = this.current_area.start_tile.x;
			this.global_script.map.tex2_tile.y = this.current_area.start_tile.y;
			if (this.current_area.start_tile.x == this.current_area.tiles.x && this.current_area.start_tile.y == this.current_area.tiles.y)
			{
				this.global_script.map.export_image.last_tile = true;
			}
			else
			{
				this.global_script.map.export_image.last_tile = false;
			}
			this.global_script.map.export_tex2 = false;
			this.global_script.map.export_tex3 = false;
			this.global_script.map.export_image.subtile.reset();
			this.global_script.map.tex3_tile.reset();
			this.jump_export_tex3_tile();
			this.global_script.map.export_image.subtile_total = 0;
			this.global_script.map.export_image.subtile2_total = 0;
			this.global_script.map.export_tex3 = false;
			this.global_script.map.export_image_area.latlong1 = area1.upper_left;
			this.global_script.map.export_image_area.latlong2 = area1.lower_right;
			this.export_image_region = region1;
			this.export_image_area = area1;
			if (!this.global_script.map.export_raw)
			{
				if (!this.global_script.map.tex2)
				{
					this.global_script.map.tex2 = new Texture2D(area1.resolution, area1.resolution, TextureFormat.RGBA32, false, true);
				}
				else if (this.global_script.map.tex2.width != area1.resolution)
				{
					this.global_script.map.tex2.Resize(area1.resolution, area1.resolution);
					this.global_script.map.tex2.Apply();
				}
				if (!this.global_script.map.tex3)
				{
					this.global_script.map.tex3 = new Texture2D(area1.resolution, area1.resolution, TextureFormat.RGBA32, false, true);
				}
				else if (this.global_script.map.tex3.width != area1.resolution)
				{
					this.global_script.map.tex3.Resize(area1.resolution, area1.resolution);
					this.global_script.map.tex3.Apply();
				}
			}
			else
			{
				if (this.global_script.map.tex2)
				{
					// this.global_script.map.tex2.Resize(0, 0);
					// this.global_script.map.tex2.Apply();
				}
				if (this.global_script.map.tex3)
				{
					// this.global_script.map.tex3.Resize(0, 0);
					// this.global_script.map.tex3.Apply();
				}
				if (this.global_script.map.file_tex2 != null)
				{
					this.global_script.map.file_tex2.Close();
				}
				if (this.global_script.map.file_tex3 != null)
				{
					this.global_script.map.file_tex3.Close();
				}
			}
			this.global_script.map.export_image_zoom = area1.image_zoom;
			this.global_script.map.export_image_timeStart = Time.realtimeSinceStartup;
			this.global_script.map.export_image_timeEnd = Time.realtimeSinceStartup;
			this.global_script.map.export_image_timePause = Time.realtimeSinceStartup;
			this.global_script.map.export_image_active = true;
			area1.export_image_active = true;
			this.global_script.map.mode = 0;
		}
	}

	public bool jump_export_heightmap_tile()
	{
		this.global_script.map.export_heightmap.tile.x = this.global_script.map.export_heightmap.tile.x + 1;
		int arg_106_0;
		if (this.global_script.map.export_heightmap.tile.x >= this.global_script.map.export_heightmap.tiles.x)
		{
			this.global_script.map.export_heightmap.tile.x = 0;
			this.global_script.map.export_heightmap.tile.y = this.global_script.map.export_heightmap.tile.y + 1;
			if (this.global_script.map.export_heightmap.tile.y >= this.global_script.map.export_heightmap.tiles.y)
			{
				this.Repaint();
				arg_106_0 = 1;
				return arg_106_0 != 0;
			}
		}
		arg_106_0 = 0;
		return arg_106_0 != 0;
	}

	public bool jump_export_image_tile()
	{
		this.global_script.map.export_image.subtile.x = this.global_script.map.export_image.subtile.x + 1;
		int arg_21A_0;
		if (this.global_script.map.export_image.subtile.x >= this.global_script.map.export_image.subtiles.x)
		{
			this.global_script.map.export_image.subtile.x = 0;
			this.global_script.map.export_image.subtile.y = this.global_script.map.export_image.subtile.y + 1;
			if (this.global_script.map.export_image.subtile.y >= this.global_script.map.export_image.subtiles.y)
			{
				this.global_script.map.export_image.subtile.y = 0;
				this.global_script.map.export_image.tile.x = this.global_script.map.export_image.tile.x + 1;
				if (this.global_script.map.export_image.tile.x >= this.global_script.map.export_image.tiles.x)
				{
					this.global_script.map.export_image.tile.x = 0;
					this.global_script.map.export_image.tile.y = this.global_script.map.export_image.tile.y + 1;
					if (this.global_script.map.export_image.tile.y >= this.global_script.map.export_image.tiles.y)
					{
						this.Repaint();
						arg_21A_0 = 1;
						return arg_21A_0 != 0;
					}
				}
			}
		}
		arg_21A_0 = 0;
		return arg_21A_0 != 0;
	}

	public bool jump_export_tex_tile()
	{
		this.global_script.map.tex2_tile.x = this.global_script.map.tex2_tile.x + 1;
		int arg_DD_0;
		if (this.global_script.map.tex2_tile.x >= this.global_script.map.export_image.tiles.x)
		{
			this.global_script.map.tex2_tile.x = 0;
			this.global_script.map.tex2_tile.y = this.global_script.map.tex2_tile.y + 1;
			if (this.global_script.map.tex2_tile.y >= this.global_script.map.export_image.tiles.y)
			{
				arg_DD_0 = 1;
				return arg_DD_0 != 0;
			}
		}
		arg_DD_0 = 0;
		return arg_DD_0 != 0;
	}

	public bool jump_export_tex3_tile()
	{
		this.global_script.map.tex3_tile.x = this.global_script.map.tex3_tile.x + 1;
		int arg_DD_0;
		if (this.global_script.map.tex3_tile.x >= this.global_script.map.export_image.tiles.x)
		{
			this.global_script.map.tex3_tile.x = 0;
			this.global_script.map.tex3_tile.y = this.global_script.map.tex3_tile.y + 1;
			if (this.global_script.map.tex3_tile.y >= this.global_script.map.export_image.tiles.y)
			{
				arg_DD_0 = 1;
				return arg_DD_0 != 0;
			}
		}
		arg_DD_0 = 0;
		return arg_DD_0 != 0;
	}

    bool ElevationConvert(int elExt_index)
    {
        if (fs == null) { stop_elevation_pull_region(current_region); return false; }
        int index = global_script.map.elExt[elExt_index].pull.text.IndexOf("elevations");
        string substring1 = global_script.map.elExt[elExt_index].pull.text.Substring(index + 13);
        int index2 = substring1.IndexOf("]");

        substring1 = substring1.Substring(0, index2);

        String numberS = "";
        char charS;
        int number;
        int number_index = 0;
        int xx;
        int yy;
        int value_int;
        float height;
        byte byte_hi;
        byte byte_lo;
        int byteIndex = 0;
        int zerodata = 0;

        xx = global_script.map.elExt[elExt_index].tile.x * 32;
        yy = global_script.map.elExt[elExt_index].tile.y * 32;

        for (int i = 0; i < substring1.Length; ++i)
        {
            charS = substring1[i];

            if (charS != ',') numberS += charS;
            
            if (charS == ',' || i == substring1.Length - 1)
            {
                number = Int16.Parse(numberS);

                height = (number + 1000) * (65535.0f / 10000.0f);

                if (number == 0)
                {
                    ++zerodata;
                    if (zerodata > 80)
                    {
                        ++global_script.map.elExt[elExt_index].zero_error;

                        if (++global_script.map.elExt[elExt_index].zero_error < 3)
                        {
                            global_script.map.elExt[elExt_index].error = 1;
                            if (global_script.map.elExt[elExt_index].pull != null) global_script.map.elExt[elExt_index].pull.Dispose();
                            global_script.map.elExt[elExt_index].pull = new WWW(global_script.map.elExt[elExt_index].url);
                            ++global_script.map.bingKey[global_script.map.bingKey_selected].pulls;
                            return false;
                        }
                    }
                }

                value_int = (int)height;

                byte_hi = (byte)(value_int >> 8);
                byte_lo = (byte)(value_int - (byte_hi << 8));

                bytes[byteIndex++] = byte_lo;
                bytes[byteIndex++] = byte_hi;

                // Debug.Log(number);
                numberS = String.Empty;
                ++number_index;
            }

        }

        global_script.map.elExt[elExt_index].error = 0;

        for (int yb = 0; yb < global_script.map.elExt[elExt_index].bres.y; ++yb)
        {
            // fs.Position = ((yy+((global_script.map.elExt[elExt_index].bres.y-1)-yb))*(yy*export_heightmap_area.heightmap_resolution.x*2))+(xx*2);
            fs.Position = (int)((yy * export_heightmap_area.heightmap_resolution.x * 2) + (xx * 2) + (((global_script.map.elExt[elExt_index].bres.y - 1) - yb) * (export_heightmap_area.heightmap_resolution.x * 2)));
            fs.Write(bytes, (int)(yb * global_script.map.elExt[elExt_index].bres.x * 2), (int)(global_script.map.elExt[elExt_index].bres.x * 2));
        }

        return true;
    }

    bool ElevationConvertZero(int elExt_index)
    {
        if (fs == null) { stop_elevation_pull_region(current_region); return false; }
        
        int xx;
        int yy;
        int value_int;
        float height;
        byte byte_hi;
        byte byte_lo;
        int byteIndex = 0;
        
        xx = global_script.map.elExt[elExt_index].tile.x * 32;
        yy = global_script.map.elExt[elExt_index].tile.y * 32;

        for (int i = 0; i < 1024; ++i)
		{
            height = 1000 * (65535.0f / 10000.0f);

            value_int = (int)height;

            byte_hi = (byte)(value_int >> 8);
            byte_lo = (byte)(value_int - (byte_hi << 8));

            bytes[byteIndex++] = byte_lo;
            bytes[byteIndex++] = byte_hi;
        }

        global_script.map.elExt[elExt_index].error = 0;

        for (int yb = 0; yb < global_script.map.elExt[elExt_index].bres.y; ++yb)
		{
            fs.Position = (int)((yy * export_heightmap_area.heightmap_resolution.x * 2) + (xx * 2) + (((global_script.map.elExt[elExt_index].bres.y - 1) - yb) * (export_heightmap_area.heightmap_resolution.x * 2)));
            fs.Write(bytes, (int)(yb * global_script.map.elExt[elExt_index].bres.x * 2), (int)(global_script.map.elExt[elExt_index].bres.x * 2));
        }
        // Debug.Log("numbers in string: "+number_index);
        // Debug.Log(global_script.map.elExt[elExt_index].bres.x+","+global_script.map.elExt[elExt_index].bres.y);
        return true;
    }

    public bool texConvert(int index)
	{
		tile_class tile_class = new tile_class();

        ext_class texExt = global_script.map.texExt[index];

        int arg_1150_0;
		if ((texExt.tile.x == this.global_script.map.tex2_tile.x && texExt.tile.y == this.global_script.map.tex2_tile.y) || this.export_image_area.resolution == 512)
		{
			if (!this.global_script.map.tex1)
			{
				this.global_script.map.tex1 = new Texture2D(512, 512, TextureFormat.RGBA32, false, true);
			}
			texExt.pull.LoadImageIntoTexture(this.global_script.map.tex1);
			this.pixels = this.global_script.map.tex1.GetPixels(0, 32, 512, 512);
			tile_class.x = texExt.tile.x * this.global_script.map.export_image.subtiles.x + texExt.subtile.x;
			tile_class.y = texExt.tile.y * this.global_script.map.export_image.subtiles.y + texExt.subtile.y;
			if (this.check_image_error(index))
			{
				texExt.zero_error = texExt.zero_error + 1;
				if (texExt.zero_error < 5)
				{
					if (global_script.map.texExt[index].pull != null) global_script.map.texExt[index].pull.Dispose();

                    texExt.pull = new WWW(texExt.url);
					texExt.startTime = Time.realtimeSinceStartup;
					this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls = this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls + 1;
					arg_1150_0 = 0;
					return arg_1150_0 != 0;
				}
			}
			if (!this.global_script.map.export_raw)
			{
				this.global_script.map.tex2.SetPixels(texExt.subtile.x * 512, (this.global_script.map.export_image.subtiles.y - 1 - texExt.subtile.y) * 512, 512, 512, this.pixels);
			}
			else
			{
				if (!this.global_script.map.export_tex2)
				{
					if (this.global_script.map.export_raw)
					{
						this.create_raw_files(this.export_image_area.export_image_path, index, 2);
					}
					this.global_script.map.export_tex2 = true;
				}
				if (!this.export_texture_to_raw(this.global_script.map.file_tex2, new Vector2((float)(texExt.subtile.x * 512), (float)((this.global_script.map.export_image.subtiles.y - 1 - texExt.subtile.y) * 512))))
				{
					arg_1150_0 = 1;
					return arg_1150_0 != 0;
				}
			}
			texExt.converted = true;
			this.global_script.map.export_image.subtile_total = this.global_script.map.export_image.subtile_total + 1;
			if (this.global_script.map.export_image.subtile_total == this.global_script.map.export_image.subtiles_total || this.export_image_area.resolution == 512)
			{
				string text = null;
				if (!this.global_script.map.export_raw)
				{
					if (this.export_image_area.resolution == 512)
					{
						text = this.export_image_area.export_image_filename + "_x" + texExt.tile.x + "_y" + (this.global_script.map.export_image.tiles.y - 1 - texExt.tile.y);
					}
					else
					{
						text = this.export_image_area.export_image_filename + "_x" + this.global_script.map.tex2_tile.x + "_y" + (this.global_script.map.export_image.tiles.y - 1 - this.global_script.map.tex2_tile.y);
					}
				}
				if (this.export_image_area.preimage_export_active && !this.export_image_area.preimage_save_new)
				{
					this.global_script.map.preimage_edit.y1 = 0;
					this.global_script.map.preimage_edit.x1 = 0;
                    //! global_script.map.preimage_edit.convert_texture(global_script.map.tex2, global_script.map.tex2, global_script.map.tex2.width, global_script.map.tex2.height, false);
                }
				if (this.export_image_area.export_image_world_file)
				{
					latlong_area_class latlong_area_class = this.global_script.calc_latlong_area_by_tile2(this.global_script.map.export_image_area.latlong1, texExt.tile, (double)this.global_script.map.export_image_zoom, this.export_image_area.resolution, new Vector2((float)this.export_image_area.resolution, (float)this.export_image_area.resolution));
					double num = (latlong_area_class.latlong2.longitude - latlong_area_class.latlong1.longitude) / (double)this.export_image_area.resolution;
					double num2 = (latlong_area_class.latlong2.latitude - latlong_area_class.latlong1.latitude) / (double)this.export_image_area.resolution;
					StreamWriter streamWriter = new StreamWriter(this.export_image_area.export_image_path + "/" + text + ".jgw");
					streamWriter.WriteLine(num.ToString());
					streamWriter.WriteLine("0");
					streamWriter.WriteLine("0");
					streamWriter.WriteLine(num2.ToString());
					streamWriter.WriteLine(latlong_area_class.latlong1.longitude);
					streamWriter.WriteLine(latlong_area_class.latlong1.latitude);
					streamWriter.Close();
				}
				this.jump_export_tex_tile();
				this.jump_export_tex3_tile();
				if (this.global_script.map.track_tile)
				{
					this.export_image_area.start_tile.x = this.global_script.map.tex2_tile.x;
					this.export_image_area.start_tile.y = this.global_script.map.tex2_tile.y;
				}
				if (this.global_script.map.export_jpg)
				{
					this.export_texture_as_jpg(this.export_image_area.export_image_path + "/" + text + ".jpg", this.global_script.map.tex2, this.global_script.map.export_jpg_quality);
				}
				if (this.global_script.map.export_png)
				{
					this.export_texture_to_file(this.export_image_area.export_image_path, text, this.global_script.map.tex2);
				}
				if (this.export_image_area.image_stop_one)
				{
					this.stop_image_pull(this.export_image_region, this.export_image_area, true);
				}
				if (this.global_script.map.export_tex3)
				{
					this.global_script.map.export_image.subtile_total = this.global_script.map.export_image.subtile2_total;
					this.global_script.map.export_image.subtile2_total = 0;
					this.global_script.map.export_tex3 = false;
					if (!this.global_script.map.export_raw)
					{
						Texture2D tex = this.global_script.map.tex2;
						this.global_script.map.tex2 = this.global_script.map.tex3;
						this.global_script.map.tex3 = tex;
					}
					else
					{
						this.global_script.map.file_tex2.Close();
						FileStream file_tex = this.global_script.map.file_tex2;
						this.global_script.map.file_tex2 = this.global_script.map.file_tex3;
						this.global_script.map.file_tex3 = file_tex;
					}
					this.global_script.map.tex_swapped = true;
				}
				else
				{
					if (this.global_script.map.export_image.last_tile && this.check_image_pulls_done())
					{
						Debug.Log("Exporting image Region: " + this.export_image_region.name + " -> Area: " + this.export_image_area.name + " done.");
						if (this.global_script.map.track_tile)
						{
							this.export_image_area.start_tile.x = 0;
							this.export_image_area.start_tile.y = 0;
						}
						this.stop_image_pull(this.export_image_region, this.export_image_area, true);
					}
					this.global_script.map.export_image.subtile_total = 0;
					if (this.global_script.map.export_raw)
					{
						this.global_script.map.file_tex2.Close();
					}
					this.global_script.map.export_tex2 = false;
				}
			}
			arg_1150_0 = 1;
		}
		else if (texExt.tile.x == this.global_script.map.tex3_tile.x && texExt.tile.y == this.global_script.map.tex3_tile.y)
		{
			if (this.global_script.map.export_image.subtile2_total < this.global_script.map.export_image.subtiles_total - 1)
			{
				if (!this.global_script.map.export_tex3 && this.global_script.map.export_raw)
				{
					this.create_raw_files(this.export_image_area.export_image_path, index, 1);
				}
				texExt.pull.LoadImageIntoTexture(this.global_script.map.tex1);
				this.pixels = this.global_script.map.tex1.GetPixels(0, 32, 512, 512);
				tile_class.x = texExt.tile.x * this.global_script.map.export_image.subtiles.x + texExt.subtile.x;
				tile_class.y = texExt.tile.y * this.global_script.map.export_image.subtiles.y + texExt.subtile.y;
				if (this.check_image_error(index))
				{
					texExt.zero_error = texExt.zero_error + 1;
					if ((texExt.zero_error = texExt.zero_error + 1) < 5)
					{
						if (global_script.map.texExt[index].pull != null) global_script.map.texExt[index].pull.Dispose();
                        texExt.pull = new WWW(texExt.url);
						texExt.startTime = Time.realtimeSinceStartup;
						this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls = this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls + 1;
						arg_1150_0 = 0;
						return arg_1150_0 != 0;
					}
				}
				if (!this.global_script.map.export_raw)
				{
					this.global_script.map.tex3.SetPixels(texExt.subtile.x * 512, (this.global_script.map.export_image.subtiles.y - 1 - texExt.subtile.y) * 512, 512, 512, this.pixels);
				}
				else if (!this.export_texture_to_raw(this.global_script.map.file_tex3, new Vector2((float)(texExt.subtile.x * 512), (float)((this.global_script.map.export_image.subtiles.y - 1 - texExt.subtile.y) * 512))))
				{
					arg_1150_0 = 1;
					return arg_1150_0 != 0;
				}
				texExt.converted = true;
				this.global_script.map.export_image.subtile2_total = this.global_script.map.export_image.subtile2_total + 1;
				this.global_script.map.export_tex3 = true;
				arg_1150_0 = 1;
			}
			else
			{
				arg_1150_0 = 0;
			}
		}
		else
		{
			arg_1150_0 = 0;
		}
		return arg_1150_0 != 0;
	}

	public bool check_image_error(int texExt_index)
	{
		int num = 0;
		int i = 0;
		int j = 0;
		Color errorColor = this.global_script.map.errorColor;
		int arg_10B_0;
		for (i = 0; i < 480; i += 4)
		{
			for (j = 0; j < 512; j += 4)
			{
				if (this.pixels[i * 512 + j].r == errorColor.r && this.pixels[i * 512 + j].g == errorColor.g && this.pixels[i * 512 + j].b == errorColor.b)
				{
					num++;
					if (num == 5)
					{
						this.global_script.map.texExt[texExt_index].error = 1;
						arg_10B_0 = 1;
						return arg_10B_0 != 0;
					}
				}
			}
		}
		this.global_script.map.texExt[texExt_index].error = 0;
		arg_10B_0 = 0;
		return arg_10B_0 != 0;
	}

	public void create_elExt()
	{
        List<ext_class> elExt = global_script.map.elExt;
		elExt.Clear();
		for (int i = 0; i < global_script.map.export_elExt; i++)
		{
			elExt.Add(new ext_class());
            elExt[i].startTime = 0;
			elExt[i].loaded = true;
		}
	}

	public void create_texExt()
	{
        List<ext_class> texExt = global_script.map.texExt;
		texExt.Clear();
		for (int i = 0; i < global_script.map.export_texExt; i++)
		{
			texExt.Add(new ext_class());
			texExt[i].startTime = 0;
			texExt[i].loaded = true;
			texExt[i].converted = true;
		}
	}

	public void open_stream(string path, string fileName)
	{
		this.fs = new FileStream(path + "/" + fileName, FileMode.Create);
	}

	public void calc_heightmap_settings(map_area_class area)
	{
		area.heightmap_scale = this.global_script.calc_latlong_area_resolution(area.center, (double)area.heightmap_zoom);
		area.heightmap_resolution.x = Mathf.Round((float)(area.size.x / area.heightmap_scale));
		area.heightmap_resolution.y = Mathf.Round((float)(area.size.y / area.heightmap_scale));
	}

	public void calc_terrain_heightmap_resolution()
	{
		this.current_area.terrain_heightmap_resolution = (int)(this.current_area.heightmap_resolution.x / (float)this.current_area.tiles.x);
		if (this.current_area.terrain_heightmap_resolution < 33)
		{
			this.current_area.terrain_heightmap_resolution = 33;
			this.current_area.terrain_heightmap_resolution_select = 0;
		}
		else if (this.current_area.terrain_heightmap_resolution < 65)
		{
			this.current_area.terrain_heightmap_resolution = 65;
			this.current_area.terrain_heightmap_resolution_select = 1;
		}
		else if (this.current_area.terrain_heightmap_resolution < 129)
		{
			this.current_area.terrain_heightmap_resolution = 129;
			this.current_area.terrain_heightmap_resolution_select = 2;
		}
		else if (this.current_area.terrain_heightmap_resolution < 257)
		{
			this.current_area.terrain_heightmap_resolution = 257;
			this.current_area.terrain_heightmap_resolution_select = 3;
		}
		else if (this.current_area.terrain_heightmap_resolution < 513)
		{
			this.current_area.terrain_heightmap_resolution = 513;
			this.current_area.terrain_heightmap_resolution_select = 4;
		}
		else if (this.current_area.terrain_heightmap_resolution < 1025)
		{
			this.current_area.terrain_heightmap_resolution = 1025;
			this.current_area.terrain_heightmap_resolution_select = 5;
		}
		else if (this.current_area.terrain_heightmap_resolution < 2049)
		{
			this.current_area.terrain_heightmap_resolution = 2049;
			this.current_area.terrain_heightmap_resolution_select = 6;
		}
		else if (this.current_area.terrain_heightmap_resolution < 4097)
		{
			this.current_area.terrain_heightmap_resolution = 4097;
			this.current_area.terrain_heightmap_resolution_select = 7;
		}
	}

	public string calc_24_hours()
	{
		int num = 0;
		int num2 = DateTime.Now.Day - this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls_startDay;
		if (num2 > 0)
		{
			num = num2 * 24 - this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls_startHour + DateTime.Now.Hour;
		}
		else
		{
			num += DateTime.Now.Hour - this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls_startHour;
		}
		int num3;
		if (this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls_startMinute > DateTime.Now.Minute)
		{
			num--;
			num3 = 60 - (this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls_startMinute - DateTime.Now.Minute);
		}
		else
		{
			num3 = DateTime.Now.Minute - this.global_script.map.bingKey[this.global_script.map.bingKey_selected].pulls_startMinute;
		}
		num = 23 - num;
		num3 = 60 - num3;
		if (num3 == 60)
		{
			num++;
			num3 = 0;
		}
		if (num < 0)
		{
			this.global_script.map.bingKey[this.global_script.map.bingKey_selected].reset();
		}
		return num.ToString() + ":" + num3.ToString("D2");
	}

	public void export_texture_as_jpg(string file, Texture2D texture, int quality)
	{
		JPGEncoder_class jPGEncoder_class = new JPGEncoder_class(texture, (float)quality);
		while (!jPGEncoder_class.isDone)
		{
		}
		File.WriteAllBytes(file, jPGEncoder_class.GetBytes());
	}

	public void export_texture_to_file(string path, string file, Texture2D export_texture)
	{
		byte[] array = export_texture.EncodeToPNG();
		File.WriteAllBytes(path + "/" + file + ".png", array);
	}

	public void create_raw_files(string path, int texExt_index, int mode)
	{
		if (this.export_image_area.resolution == 512)
		{
			this.global_script.map.file_tex2 = new FileStream(path + "/" + this.export_image_area.export_image_filename + "_x" + this.global_script.map.texExt[texExt_index].tile.x + "_y" + this.global_script.map.texExt[texExt_index].tile.y + ".raw", FileMode.Create);
		}
		else
		{
			if (mode == 0 || mode == 2)
			{
				this.global_script.map.file_tex2 = new FileStream(path + "/" + this.export_image_area.export_image_filename + "_x" + this.global_script.map.tex2_tile.x + "_y" + this.global_script.map.tex2_tile.y + ".raw", FileMode.Create);
			}
			if (mode == 0 || mode == 1)
			{
				this.global_script.map.file_tex3 = new FileStream(path + "/" + this.export_image_area.export_image_filename + "_x" + this.global_script.map.tex3_tile.x + "_y" + this.global_script.map.tex3_tile.y + ".raw", FileMode.Create);
			}
		}
	}

	public bool export_texture_to_raw(FileStream file_tex, Vector2 offset)
	{
		int i = 0;
		int j = 0;
		int num = this.export_image_area.resolution * 3;
		byte[] array = new byte[1536];
		bool arg_13C_0;
		if (file_tex == null)
		{
			Debug.Log("Image exporting is interupted, please start again.");
			this.stop_all_image_pull();
			arg_13C_0 = false;
		}
		else
		{
			file_tex.Position = (long)((float)num * ((float)(this.export_image_area.resolution - 512) - offset.y) + offset.x * (float)3);
			for (i = 511; i >= 0; i--)
			{
				for (j = 0; j < 512; j++)
				{
					array[j * 3] = (byte)(this.pixels[i * 512 + j].r * (float)255);
					array[j * 3 + 1] = (byte)(this.pixels[i * 512 + j].g * (float)255);
					array[j * 3 + 2] = (byte)(this.pixels[i * 512 + j].b * (float)255);
				}
				file_tex.Write(array, 0, 1536);
				file_tex.Seek((long)(num - 1536), SeekOrigin.Current);
			}
			arg_13C_0 = true;
		}
		return arg_13C_0;
	}

	public void combine_textures_begin(map_area_class area1, string path, string file)
	{
		if (this.combine_export_file != null)
		{
			this.combine_export_file.Close();
		}
		if (this.combine_import_file != null)
		{
			this.combine_import_file.Close();
		}
		this.combine_area = area1;
		this.combine_width = (ulong)(area1.resolution * 3 * area1.tiles.x);
		this.combine_height = (ulong)((long)this.combine_width * (long)area1.resolution);
		this.combine_length = (ulong)(area1.resolution * area1.resolution * 3 * (area1.tiles.x * area1.tiles.y));
		this.combine_import_path = area1.export_image_path + "/";
		if (this.combine_export_file != null)
		{
			this.combine_export_file.Close();
		}
		this.combine_export_file = new FileStream(path + "/" + file + "_combined.raw", FileMode.Create);
		this.combine_export_file.SetLength((long)this.combine_length);
		this.combine_call = false;
		this.combine_byte = new byte[area1.resolution * 3];
		this.combine_y = 0;
		this.combine_x = 0;
		this.combine_y1 = 0;
		this.combine_generate = true;
		Application.runInBackground = true;
	}

	public void combine_textures()
	{
		int i = 0;
		int j = 0;
		int k = 0;
		this.combine_time = Time.realtimeSinceStartup;
		for (i = this.combine_y; i < this.combine_area.tiles.y; i++)
		{
			for (j = this.combine_x; j < this.combine_area.tiles.x; j++)
			{
				if (!this.combine_call)
				{
					if (this.combine_import_file != null)
					{
						this.combine_import_file.Close();
					}
					this.combine_import_filename = this.combine_area.export_image_filename + "_x" + j + "_y" + i;
					if (!File.Exists(this.combine_import_path + this.combine_import_filename + ".raw"))
					{
						Debug.Log(this.combine_import_path + this.combine_import_filename + ".raw" + " does not exist");
						this.combine_generate = false;
						this.combine_export_file.Close();
						return;
					}
					this.combine_import_file = new FileStream(this.combine_import_path + this.combine_import_filename + ".raw", FileMode.Open);
					this.combine_export_file.Seek((long)this.combine_height * (long)i + (long)(this.combine_area.resolution * 3 * j), SeekOrigin.Begin);
				}
				for (k = this.combine_y1; k < this.combine_area.resolution; k++)
				{
					this.combine_import_file.Read(this.combine_byte, 0, this.combine_area.resolution * 3);
					this.combine_export_file.Write(this.combine_byte, 0, this.combine_area.resolution * 3);
					this.combine_export_file.Seek((long)this.combine_width - (long)(this.combine_area.resolution * 3), SeekOrigin.Current);
					if (Time.realtimeSinceStartup - this.combine_time > 1f / (float)this.global_script.target_frame)
					{
						this.combine_call = true;
						this.combine_y1 = k + 1;
						this.combine_y = i;
						this.combine_x = j;
						return;
					}
				}
				this.combine_call = false;
				this.combine_y1 = 0;
			}
			this.combine_x = 0;
		}
		this.combine_export_file.Close();
		this.combine_generate = false;
	}

	public void slice_textures_begin(map_area_class area1, string path, string file)
	{
		this.combine_area = area1;
		this.combine_export_path = area1.export_image_path + "/";
		this.combine_byte = new byte[area1.resolution * 3];
		this.combine_width = (ulong)(area1.resolution * 3 * area1.tiles.x);
		this.combine_height = (ulong)((long)this.combine_width * (long)area1.resolution);
		this.combine_length = (ulong)(area1.resolution * area1.resolution * 3 * (area1.tiles.x * area1.tiles.y));
        if (!current_area.preimage_save_new)
        {
            combine_import_file = new FileStream(path + "/" + file + "_combined2.raw", FileMode.Open);
        }
        else
        {
            combine_import_file = new FileStream(current_area.preimage_path + "/" + current_area.preimage_filename + ".raw", FileMode.Open);
        }
        this.combine_pixels = new Color[area1.resolution];
        if (!global_script.map.tex2)
        {
            global_script.map.tex2 = new Texture2D(area1.resolution, area1.resolution, TextureFormat.RGBA32, false, true);
        }
        else if (global_script.map.tex2.width != area1.resolution)
        {
            global_script.map.tex2.Resize(area1.resolution, area1.resolution);
            global_script.map.tex2.Apply();
        }
        this.combine_call = false;
		this.combine_y = 0;
		this.combine_x = 0;
		this.combine_y1 = 0;
		this.slice_generate = true;
		Application.runInBackground = true;
	}

	public void slice_textures()
	{
		int i = 0;
		int j = 0;
		int k = 0;
		int l = 0;
		this.combine_time = Time.realtimeSinceStartup;
		for (i = this.combine_y; i < this.combine_area.tiles.y; i++)
		{
			for (j = this.combine_x; j < this.combine_area.tiles.x; j++)
			{
				if (!this.combine_call)
				{
					this.combine_export_filename = this.combine_area.export_image_filename + "_x" + j + "_y" + (this.combine_area.tiles.y - 1 - i);
					this.combine_import_file.Seek((long)this.combine_height * (long)i + (long)(this.combine_area.resolution * 3 * j), SeekOrigin.Begin);
				}
				for (k = this.combine_y1; k < this.combine_area.resolution; k++)
				{
					this.combine_import_file.Read(this.combine_byte, 0, this.combine_area.resolution * 3);
					for (l = 0; l < this.combine_area.resolution; l++)
					{
						this.combine_pixels[l] = new Color((float)this.combine_byte[l * 3] * 1f / (float)255, (float)this.combine_byte[l * 3 + 1] * 1f / (float)255, (float)this.combine_byte[l * 3 + 2] * 1f / (float)255);
					}
					this.global_script.map.tex2.SetPixels(0, this.combine_area.resolution - k - 1, this.combine_area.resolution, 1, this.combine_pixels);
					this.combine_import_file.Seek((long)this.combine_width - (long)(this.combine_area.resolution * 3), SeekOrigin.Current);
					if (Time.realtimeSinceStartup - this.combine_time > 1f / (float)this.global_script.target_frame)
					{
						this.combine_call = true;
						this.combine_y1 = k + 1;
						this.combine_y = i;
						this.combine_x = j;
						return;
					}
				}
				this.combine_y1 = 0;
				this.combine_call = false;
				this.export_texture_as_jpg(this.combine_export_path + this.combine_export_filename + ".jpg", this.global_script.map.tex2, this.global_script.map.export_jpg_quality);
			}
			this.combine_x = 0;
		}
		this.combine_import_file.Close();
		this.slice_generate = false;
		AssetDatabase.Refresh();
	}

	public void keyHelp()
	{
		if (this.global_script.map.key_edit)
		{
			this.gui_y2 = (int)((float)this.gui_y2 + ((float)80 + (float)this.global_script.map.bingKey.Count * 19.9f));
		}
		GUI.color = this.global_script.map.backgroundColor;
		this.help_rect = new Rect((float)359, (float)(62 + this.gui_y2), (float)450, (float)100);
		EditorGUI.DrawPreviewTexture(this.help_rect, this.global_script.tex2);
		GUI.color = Color.red;
		EditorGUI.LabelField(new Rect(guiWidth3, (float)(65 + this.gui_y2), (float)200, (float)20), "Refresh Map", EditorStyles.boldLabel);
		EditorGUI.LabelField(new Rect((float)548, (float)(65 + this.gui_y2), (float)250, (float)20), "Keyboard F5", EditorStyles.boldLabel);
		EditorGUI.LabelField(new Rect(guiWidth3, (float)(85 + this.gui_y2), (float)200, (float)20), "Navigate Around", EditorStyles.boldLabel);
		EditorGUI.LabelField(new Rect((float)548, (float)(85 + this.gui_y2), (float)250, (float)20), "Hold left mouse button and drag", EditorStyles.boldLabel);
		EditorGUI.LabelField(new Rect(guiWidth3, (float)(104 + this.gui_y2), (float)200, (float)20), "Goto position", EditorStyles.boldLabel);
		EditorGUI.LabelField(new Rect((float)548, (float)(104 + this.gui_y2), (float)250, (float)20), "Double click left mouse button", EditorStyles.boldLabel);
		EditorGUI.LabelField(new Rect(guiWidth3, (float)(123 + this.gui_y2), (float)200, (float)20), "Zoom", EditorStyles.boldLabel);
		EditorGUI.LabelField(new Rect((float)548, (float)(123 + this.gui_y2), (float)200, (float)20), "Mouse scroll wheel", EditorStyles.boldLabel);
		EditorGUI.LabelField(new Rect(guiWidth3, (float)(142 + this.gui_y2), (float)200, (float)20), "Elevation Info", EditorStyles.boldLabel);
		EditorGUI.LabelField(new Rect((float)548, (float)(142 + this.gui_y2), (float)200, (float)20), "Right mouse button", EditorStyles.boldLabel);
		GUI.color = Color.white;
	}

	public void texture_fill(Texture2D texture, Color color, bool apply)
	{
		int width = texture.width;
		int height = texture.height;
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				texture.SetPixel(j, i, color);
			}
		}
		if (apply)
		{
			texture.Apply();
		}
	}

	public string sec_to_timeMin(float seconds, bool display_seconds)
	{
		int num = (int)(seconds / (float)60);
		seconds -= (float)(num * 60);
		string arg_B2_0;
		if (num == 0)
		{
			arg_B2_0 = seconds.ToString("F2");
		}
		else
		{
			int num2 = (int)seconds;
			seconds -= (float)num2;
			int num3 = (int)(seconds * (float)100);
			arg_B2_0 = ((!display_seconds) ? (num.ToString() + ":" + num2.ToString("D2")) : (num.ToString() + ":" + num2.ToString("D2") + "." + num3.ToString("D2")));
		}
		return arg_B2_0;
	}

	public void check_free_key()
	{
		for (int i = 0; i < this.global_script.map.bingKey.Count; i++)
		{
			if (this.global_script.map.bingKey[i].pulls < 48000)
			{
				this.global_script.map.bingKey_selected = i;
				break;
			}
		}
	}

	public GameObject create_worldcomposer_parent()
	{
		GameObject gameObject = new GameObject();
		gameObject.name = "_WorldComposer" ;
		gameObject.transform.position = new Vector3((float)0, (float)0, (float)0);
		return gameObject;
	}

	public void parent_terraincomposer_children()
	{
		GameObject gameObject = GameObject.Find("global_settings");
		if (gameObject)
		{
			if (!this.terraincomposer)
			{
				GameObject gameObject2 = GameObject.Find("_WorldComposer");
				if (!gameObject2)
				{
					gameObject2 = this.create_worldcomposer_parent();
				}
				gameObject.transform.parent = gameObject2.transform;
			}
			else
			{
				GameObject gameObject2 = GameObject.Find("_TerrainComposer");
				gameObject.transform.parent = gameObject2.transform;
				GameObject gameObject3 = GameObject.Find("_WorldComposer");
				if (gameObject3)
				{
					GameObject.DestroyImmediate(gameObject3);
				}
			}
		}
	}

	public void load_global_settings() 
	{
        string text = this.install_path + "/Templates/global_settings.prefab";

		if (!File.Exists(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Templates/global_settings.prefab"))
		{
			if (!File.Exists(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Templates/global_settings 1.prefab"))
			{
				FileUtil.CopyFileOrDirectory(this.install_path + "/Templates/global_settings 2.prefab", this.install_path + "/Templates/global_settings.prefab");
			}
			else
			{
				FileUtil.CopyFileOrDirectory(this.install_path + "/Templates/global_settings 1.prefab", this.install_path + "/Templates/global_settings.prefab");
			}
		}
		else
		{
			this.Global_Settings_Scene = (GameObject)AssetDatabase.LoadAssetAtPath(text, typeof(GameObject));
			if (this.Global_Settings_Scene)
			{
				this.global_script = (global_settings_tc)this.Global_Settings_Scene.GetComponent(typeof(global_settings_tc));
				this.Repaint();
			}
			else
			{
				AssetDatabase.Refresh();
			}
		}
	}

	public void add_terrainArea(int index)
	{
		this.terrain_region.add_area(index);
		this.add_terrain(this.terrain_region.area[index], 0, 0, this.terrain_region.area[0]);
		this.auto_search(this.terrain_region.area[index].auto_search);
		this.auto_search(this.terrain_region.area[index].auto_name);
	}

	public void create_terrains_area()
	{
		if (this.terraincomposer && this.current_area.export_to_terraincomposer)
		{
			EditorWindow window = EditorWindow.GetWindow(Type.GetType("TerrainComposer"));
			window.titleContent = new GUIContent("TerrainComp.");
		}
		Application.runInBackground = true;
		this.create_region = this.current_region;
		this.create_area = this.current_area;
		this.create_area.terrain_done = false;
		this.terrain_region.area[0].terrains.Clear();
		this.terrain_parent = new GameObject();
		this.terrain_parent.name = this.create_region.name;
		if (this.terrain_region.area.Count == 0)
		{
			this.add_terrainArea(0);
		}
		if (this.terrain_region.area[0].terrains.Count == 0)
		{
			this.add_terrain(this.terrain_region.area[0], 0, 0, this.terrain_region.area[0]);
		}
		this.terrain_region.area[0].tiles_select.x = this.create_area.tiles.x;
		this.terrain_region.area[0].tiles_select.y = this.create_area.tiles.y;
		this.terrain_region.area[0].tiles_select_total = this.create_area.tiles.x * this.create_area.tiles.y;
		if (this.terrain_region.area[0].tiles_select_total == 0)
		{
			this.notify_text = "The area is not created. Use the 'Pick' button to create an area";
			GameObject.DestroyImmediate(this.terrain_parent);
		}
		else
		{
			if (!Directory.Exists(this.current_area.export_terrain_path))
			{
				string text = this.current_area.export_terrain_path.Replace(Application.dataPath, "Assets");
				int num = text.LastIndexOf("/");
				string text2 = text.Substring(num + 1);
				text = text.Replace("/" + text2, string.Empty);
				AssetDatabase.CreateFolder(text, text2);
			}
			if (current_area.normalizeHeightmap)
			{
				string text3 = current_area.export_heightmap_path + "/" + current_area.export_heightmap_filename;
				if (!File.Exists(text3 + "_N.Raw"))
				{
					current_area.normalizedHeight = NormalizeHeightmap(current_area.heightmap_resolution, text3 + ".Raw");
				}
			}
			this.terrain_region.area[0].auto_name.format = "_x%x_y%y";
			this.terrain_size.x = Mathf.Round((float)(this.create_area.size.x / (double)this.create_area.tiles.x));
			if (this.create_area.normalizeHeightmap)
			{
				this.terrain_size.y = this.create_area.normalizedHeight;
			}
			else
			{
				this.terrain_size.y = 10000;
			}
			this.terrain_size.z = Mathf.Round((float)(this.create_area.size.y / (double)this.create_area.tiles.y));
			this.create_terrain_count = 0;
			this.create_terrain_loop = true;
			this.generate_begin();
		}
	}

	public void create_terrain(terrain_area_class terrainArea1, terrain_class2 preterrain, string terrain_path, Transform terrain_parent)
	{
		int num = 0;
		int i = 0;
		int num3 = 0;
		int num4 = terrainArea1.tiles_select_total - num3;
		for (i = this.create_terrain_count; i < num4; i++)
		{
			if (terrainArea1.terrains.Count <= i || !terrainArea1.terrains[i].terrain)
			{
				GameObject gameObject = new GameObject();
				Terrain terrain = (Terrain)gameObject.AddComponent(typeof(Terrain));
				TerrainCollider terrainCollider = (TerrainCollider)gameObject.AddComponent(typeof(TerrainCollider));
				num = i + num3;
				tile_class tile_class = this.calc_terrain_tile(num, terrainArea1.tiles_select);
				string text = terrainArea1.auto_name.get_name(tile_class.x, tile_class.y, num);
				string text2 = this.create_area.export_terrain_path;
				text2 = "Assets" + text2.Replace(Application.dataPath, string.Empty);
				text2 += "/" + this.create_area.terrain_scene_name + text + ".asset";
				terrain.terrainData = new TerrainData();
				gameObject.AddComponent(typeof(TerrainDetail));
				terrain.terrainData.heightmapResolution = this.heightmap_resolution;
				terrain.terrainData.baseMapResolution = preterrain.basemap_resolution;
				terrain.terrainData.alphamapResolution = preterrain.splatmap_resolution;
				terrain.terrainData.SetDetailResolution(preterrain.detail_resolution, preterrain.detail_resolution_per_patch);
				terrain.terrainData.size = this.terrain_size * this.create_area.terrain_scale;
				gameObject.isStatic = true;
				if (terrain_parent)
				{
					gameObject.transform.parent = terrain_parent;
				}
				terrain.name = this.create_area.terrain_scene_name + text;
				AssetDatabase.CreateAsset(terrain.terrainData, text2);
				terrainCollider.terrainData = terrain.terrainData;
                if (terrainArea1.terrains.Count - 1 < i + num3)
                {
                    if (terrainArea1.copy_settings)
                    {
                        // Debug.Log("Copy!!!"+terrain_index);
                        if (num > 0) { add_terrain(terrainArea1, terrainArea1.terrains.Count, terrainArea1.copy_terrain, terrainArea1); } else { add_terrain(terrainArea1, terrainArea1.terrains.Count, -1, terrainArea1); }
                    }
                    else
                    {
                        add_terrain(terrainArea1, terrainArea1.terrains.Count, -1, terrainArea1);
                    }
                }
                gameObject.transform.position = new Vector3(-preterrain.size.x / (float)2, -1000, -preterrain.size.z / (float)2);
				terrainArea1.terrains[num].terrain = terrain;
				this.terrain_parameters(terrainArea1.terrains[num]);
				terrainArea1.terrains[num].tile_x = tile_class.x;
				terrainArea1.terrains[num].tile_z = tile_class.y;
				terrainArea1.terrains[num].prearea.max();
				terrainArea1.terrains[num].foldout = false;
				terrainArea1.terrains[num].terrain.heightmapPixelError = (float)5;
				this.fit_terrain_tile(this.terrain_region.area[0], this.terrain_region.area[0].terrains[this.create_terrain_count], true);
				if (this.create_area.do_image)
				{
					this.assign_terrain_splat_alpha(terrainArea1.terrains[num], true);
					this.SetTerrainAreaSplatTextures(this.terrain_region.area[0], num);
				}
				this.create_area.terrain_done = true;
				if (this.create_area.do_heightmap && (!this.terraincomposer || !this.create_area.export_to_terraincomposer))
				{
					this.heightmap_y = (float)(this.heightmap_resolution - 1);
					this.generate = true;
				}
				this.create_terrain_count++;
				return;
			}
		}
		terrainArea1.tiles.x = terrainArea1.tiles_select.x;
		terrainArea1.tiles.y = terrainArea1.tiles.y - 1 - terrainArea1.tiles_select.y;
		terrainArea1.tiles_total = terrainArea1.tiles_select_total;
		terrainArea1.size.x = terrainArea1.terrains[0].size.x * (float)terrainArea1.tiles.x;
		terrainArea1.size.z = terrainArea1.terrains[0].size.x * (float)terrainArea1.tiles.y;
		terrainArea1.size.y = terrainArea1.terrains[0].size.y;
		AssetDatabase.Refresh();
		this.terrains_neighbor(terrainArea1);
		this.terrains_neighbor_script(terrainArea1, 1);
		this.create_terrain_loop = false;
        if (create_area.do_heightmap && (!create_area.export_to_terraincomposer || !terraincomposer))
        {
            heights = new float[0, 0];
            generate = false;
            if (raw_file.fs != null) { raw_file.fs.Close(); raw_file.fs.Dispose(); }
        }
        if (!global_script.map.export_heightmap_active && !global_script.map.export_image_active) { Application.runInBackground = false; }
        this.create_splat_count = 0;
		if (this.create_area.do_heightmap && (!this.create_area.export_to_terraincomposer || !this.terraincomposer))
		{
			this.heights = (float[,])Array.CreateInstance(typeof(float), new int[2]);
			this.generate = false;
			if (this.raw_file.fs != null)
			{
				this.raw_file.fs.Close();
				this.raw_file.fs.Dispose();
			}
		}
		if (this.create_area.auto_import_settings_apply)
		{
			this.start_image_import_settings(this.create_area);
			return;
		}
	}

	public void start_image_import_settings(map_area_class area1)
	{
		area1.maxTextureSize = (int)Mathf.Pow((float)2, (float)(area1.maxTextureSize_select + 5));
		this.create_area = area1;
		this.terrain_region.area[0].tiles_select.x = this.create_area.tiles.x;
		this.terrain_region.area[0].tiles_select.y = this.create_area.tiles.y;
		this.import_settings_count = 0;
		this.apply_import_settings = true;
	}

	public void clear_terrains()
	{
		for (int i = 0; i < this.terrain_region.area[0].terrains.Count; i++)
		{
			this.terrain_region.area[0].terrains[i].terrain = null;
		}
		this.terrain_region.area[0].terrains.Clear();
	}

	public void SetTerrainAreaSplatTextures(terrain_area_class terrainArea1, int terrainIndex)
	{
		string text = null;
		tile_class tile_class = this.calc_terrain_tile(terrainIndex, terrainArea1.tiles_select);
		if (this.global_script.map.export_jpg)
		{
			text = this.create_area.export_image_path.Replace(Application.dataPath, "Assets") + "/" + this.create_area.export_image_filename + "_x" + tile_class.x.ToString() + "_y" + tile_class.y.ToString() + ".jpg";
		}
		else if (this.global_script.map.export_png)
		{
			text = this.create_area.export_image_path.Replace(Application.dataPath, "Assets") + "/" + this.create_area.export_image_filename + "_x" + tile_class.x.ToString() + "_y" + tile_class.y.ToString() + ".png";
		}
		if (!File.Exists(text))
		{
			this.notify_text = text + " doesn't exist! Make sure the image tiles are the same as the exported image tiles";
			Debug.Log(text + " doesn't exist! Make sure the image tiles are the same as the exported image tiles.");
		}
		else
		{
			Type type = TC.GetType(typeof(MonoBehaviour), "ReliefTerrain");
			if (type == null)
			{
				terrainArea1.terrains[terrainIndex].add_splatprototype(0);
				terrainArea1.terrains[terrainIndex].splatPrototypes[0].tileSize = new Vector2(terrainArea1.terrains[terrainIndex].terrain.terrainData.size.x, terrainArea1.terrains[terrainIndex].terrain.terrainData.size.z);
                terrainArea1.terrains[terrainIndex].splatPrototypes[0].texture = (Texture2D)AssetDatabase.LoadAssetAtPath(text, typeof(Texture2D));
				if (!terrainArea1.terrains[terrainIndex].splatPrototypes[0].texture)
				{
					Debug.Log(text);
				}
				this.terrain_splat_textures(terrainArea1.terrains[terrainIndex]);
			}
			else
			{
				for (int i = 0; i < 8; i++)
				{
					terrainArea1.terrains[terrainIndex].add_splatprototype(0);
				}
				terrainArea1.terrains[terrainIndex].splatPrototypes[0].texture = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Dirt.psd", typeof(Texture2D));
				terrainArea1.terrains[terrainIndex].splatPrototypes[1].texture = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Forest3.psd", typeof(Texture2D));
				terrainArea1.terrains[terrainIndex].splatPrototypes[2].texture = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Forest2.psd", typeof(Texture2D));
				terrainArea1.terrains[terrainIndex].splatPrototypes[3].texture = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Grass.psd", typeof(Texture2D));
				terrainArea1.terrains[terrainIndex].splatPrototypes[4].texture = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Forest1.psd", typeof(Texture2D));
				terrainArea1.terrains[terrainIndex].splatPrototypes[5].texture = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/GrassRock.psd", typeof(Texture2D));
				terrainArea1.terrains[terrainIndex].splatPrototypes[6].texture = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Cliff.psd", typeof(Texture2D));
				terrainArea1.terrains[terrainIndex].splatPrototypes[7].texture = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Rock1.psd", typeof(Texture2D));
				this.terrain_splat_textures(terrainArea1.terrains[terrainIndex]);
				if (type != null)
				{
					terrainArea1.terrains[terrainIndex].rtp_script = terrainArea1.terrains[terrainIndex].terrain.gameObject.AddComponent(type);
                }

                Component rtpScript = terrainArea1.terrains[terrainIndex].rtp_script;
                
                if (rtpScript != null)
				{
                    FieldInfo colorGlobalField = type.GetField("ColorGlobal");
                    colorGlobalField.SetValue(rtpScript, (Texture2D)AssetDatabase.LoadAssetAtPath(text, typeof(Texture2D)));
                    
                    FieldInfo globalSettingsHolderField = type.GetField("globalSettingsHolder");
                    object globalSettingsHolder = globalSettingsHolderField.GetValue(rtpScript);
                    Type globalSettingsHolderType = globalSettingsHolder.GetType();
                    
                    Texture2D[] texBumps = new Texture2D[8];

                    texBumps[0] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Dirt_NRM.png", typeof(Texture2D));
                    texBumps[1] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Forest3_NRM.png", typeof(Texture2D));
                    texBumps[2] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Forest2_NRM.png", typeof(Texture2D));
                    texBumps[3] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Grass_NRM.png", typeof(Texture2D));
                    texBumps[4] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Forest1_NRM.png", typeof(Texture2D));
                    texBumps[5] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/GrassRock_NRM.png", typeof(Texture2D));
                    texBumps[6] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Cliff_NRM.png", typeof(Texture2D));
                    texBumps[7] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Rock1_NRM.png", typeof(Texture2D));

                    globalSettingsHolderType.GetField("Bumps").SetValue(globalSettingsHolder, texBumps);
                                        
                    Texture2D[] texHeights = new Texture2D[8];

                    texHeights[0] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Dirt_DISP.png", typeof(Texture2D));
                    texHeights[1] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Forest3_DISP.png", typeof(Texture2D));
                    texHeights[2] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Forest2_DISP.png", typeof(Texture2D));
                    texHeights[3] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Grass_DISP.png", typeof(Texture2D));
                    texHeights[4] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Forest1_DISP.png", typeof(Texture2D));
                    texHeights[5] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/GrassRock_DISP.png", typeof(Texture2D));
                    texHeights[6] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Cliff_DISP.png", typeof(Texture2D));
                    texHeights[7] = (Texture2D)AssetDatabase.LoadAssetAtPath(this.install_path + "/Templates/Textures/Rock1_DISP.png", typeof(Texture2D));

                    globalSettingsHolderType.GetField("Heights").SetValue(globalSettingsHolder, texHeights);

                    globalSettingsHolderType.GetField("GlobalColorMapBlendValues").SetValue(globalSettingsHolder, Vector3.one);
                    globalSettingsHolderType.GetField("_GlobalColorMapNearMIP").SetValue(globalSettingsHolder, 1);
                    globalSettingsHolderType.GetField("ReliefTransform").SetValue(globalSettingsHolder, new Vector4((terrain_size.x * create_area.terrain_scale) / 22, (terrain_size.z * create_area.terrain_scale) / 22, 0, 0));
                    globalSettingsHolderType.GetField("distance_start").SetValue(globalSettingsHolder, 0);
                    globalSettingsHolderType.GetField("distance_start_bumpglobal").SetValue(globalSettingsHolder, 0);
                    globalSettingsHolderType.GetField("rtp_perlin_start_val").SetValue(globalSettingsHolder, 1);
                    globalSettingsHolderType.GetField("distance_transition_bumpglobal").SetValue(globalSettingsHolder, 300);

                    CreateRTPCombinedTextures(terrainArea1.terrains[terrainIndex], globalSettingsHolderType, globalSettingsHolder);

                    globalSettingsHolderType.GetMethod("RefreshAll").Invoke(globalSettingsHolder, null);
                }
			}
			this.create_splat_count++;
		}
	}

	public void terrain_splat_textures(terrain_class2 preterrain1)
	{
		if (preterrain1.terrain)
		{
			List<SplatPrototype> list = new List<SplatPrototype>();
			int num = -1;
			for (int i = 0; i < preterrain1.splatPrototypes.Count; i++)
			{
				if (preterrain1.splatPrototypes[i].texture)
				{
					list.Add(new SplatPrototype());
					num++;
					list[num].texture = preterrain1.splatPrototypes[i].texture;
					list[num].tileSize = preterrain1.splatPrototypes[i].tileSize;
					list[num].tileOffset = preterrain1.splatPrototypes[i].tileOffset;
				}
			}
			preterrain1.terrain.terrainData.splatPrototypes = list.ToArray();
		}
	}

	public tile_class calc_terrain_tile(int terrain_index, tile_class tiles)
	{
		tile_class arg_5F_0;
		if (tiles.x == 0 || tiles.y == 0)
		{
			this.apply_import_settings = false;
			this.create_terrain_loop = false;
			this.notify_text = "The Area is not created. Use the 'Pick' button to create an area";
			arg_5F_0 = null;
		}
		else
		{
			tile_class tile_class = new tile_class();
			tile_class.y = terrain_index / tiles.x;
			tile_class.x = terrain_index - tile_class.y * tiles.x;
			arg_5F_0 = tile_class;
		}
		return arg_5F_0;
	}

	public tile_class calc_terrain_tile2(int terrain_index, tile_class tiles)
	{
		tile_class tile_class = new tile_class();
		tile_class.y = terrain_index / tiles.x;
		tile_class.x = terrain_index - tile_class.y * tiles.x;
		return tile_class;
	}

	public int calc_terrain_index_old(tile_class tile, tile_class tiles)
	{
		return tile.x * tiles.y + tile.y;
	}

    void assign_terrain_splat_alpha(terrain_class2 preterrain1, bool update_asset)
    {
        if (preterrain1.terrain)
        {
            if (!preterrain1.terrain.terrainData) { return; }
            if (preterrain1.splatPrototypes.Count < 1) { return; }

            if (update_asset) { update_terrain_asset(preterrain1); }

            string path = AssetDatabase.GetAssetPath(preterrain1.terrain.terrainData);
            
            object[] objects = AssetDatabase.LoadAllAssetsAtPath(path);

            preterrain1.splat_alpha = new Texture2D[objects.Length - 1];

            for (int i = 0; i < objects.Length; ++i)
			{
                if (objects[i].GetType() == typeof(Texture2D))
                {
                    String numbers_only = Regex.Replace(((Texture)objects[i]).name, "[^0-9]", "");
                    int index = Convert.ToInt32(numbers_only);

                    preterrain1.splat_alpha[index] = (Texture2D)objects[i];
                }
            }
        }
    }

    public byte[] process_out(byte[] bytes)
	{
		for (int i = 0; i < bytes.Length; i++)
		{
			bytes[i] = (byte)(255 - (int)bytes[i]);
		}
		return bytes;
	}

	public void assign_all_terrain_splat_alpha(terrain_area_class terrainArea1, bool update_asset)
	{
		for (int i = 0; i < terrainArea1.terrains.Count; i++)
		{
			this.assign_terrain_splat_alpha(terrainArea1.terrains[i], update_asset);
		}
	}

	public void add_terrain(terrain_area_class terrainArea1, int terrain_number, int copy, terrain_area_class terrainArea2)
	{
		terrainArea1.terrains.Insert(terrain_number, new terrain_class2());
		if (copy > -1 && copy < terrainArea2.terrains.Count)
		{
			terrainArea1.terrains[terrain_number].terrain = null;
		}
		terrainArea1.terrains[terrain_number].index = terrain_number;
		terrainArea1.set_terrain_text();
	}

	public void terrain_parameters(terrain_class2 preterrain1)
	{
		preterrain1.terrain.heightmapPixelError = preterrain1.heightmapPixelError;
		preterrain1.terrain.heightmapMaximumLOD = preterrain1.heightmapMaximumLOD;
		preterrain1.terrain.basemapDistance = preterrain1.basemapDistance;
		preterrain1.terrain.castShadows = preterrain1.castShadows;
		preterrain1.terrain.treeDistance = preterrain1.treeDistance;
		preterrain1.terrain.detailObjectDistance = preterrain1.detailObjectDistance;
		preterrain1.terrain.detailObjectDensity = preterrain1.detailObjectDensity;
		preterrain1.terrain.treeBillboardDistance = preterrain1.treeBillboardDistance;
		preterrain1.terrain.treeCrossFadeLength = preterrain1.treeCrossFadeLength;
		preterrain1.terrain.treeMaximumFullLODCount = preterrain1.treeMaximumFullLODCount;
		preterrain1.terrain.castShadows = preterrain1.castShadows;
		preterrain1.terrain.terrainData.wavingGrassSpeed = preterrain1.wavingGrassSpeed;
		preterrain1.terrain.terrainData.wavingGrassAmount = preterrain1.wavingGrassAmount;
		preterrain1.terrain.terrainData.wavingGrassStrength = preterrain1.wavingGrassStrength;
		preterrain1.terrain.terrainData.wavingGrassTint = preterrain1.wavingGrassTint;
	}

	public void terrains_neighbor(terrain_area_class terrainArea1)
	{
		int num = 0;
		for (int i = 0; i < terrainArea1.terrains.Count; i++)
		{
			if (terrainArea1.terrains[i].terrain)
			{
				num = this.search_tile(terrainArea1, terrainArea1.terrains[i].tile_x - 1, terrainArea1.terrains[i].tile_z);
				if (num != -1)
				{
					terrainArea1.terrains[i].neighbor.left = num;
				}
				else
				{
					terrainArea1.terrains[i].neighbor.left = -1;
				}
				num = this.search_tile(terrainArea1, terrainArea1.terrains[i].tile_x, terrainArea1.terrains[i].tile_z - 1);
				if (num != -1)
				{
					terrainArea1.terrains[i].neighbor.bottom = num;
				}
				else
				{
					terrainArea1.terrains[i].neighbor.bottom = -1;
				}
				num = this.search_tile(terrainArea1, terrainArea1.terrains[i].tile_x + 1, terrainArea1.terrains[i].tile_z);
				if (num != -1)
				{
					terrainArea1.terrains[i].neighbor.right = num;
				}
				else
				{
					terrainArea1.terrains[i].neighbor.right = -1;
				}
				num = this.search_tile(terrainArea1, terrainArea1.terrains[i].tile_x, terrainArea1.terrains[i].tile_z + 1);
				if (num != -1)
				{
					terrainArea1.terrains[i].neighbor.top = num;
				}
				else
				{
					terrainArea1.terrains[i].neighbor.top = -1;
				}
				num = this.search_tile(terrainArea1, terrainArea1.terrains[i].tile_x + 1, terrainArea1.terrains[i].tile_z + 1);
				if (num != -1)
				{
					terrainArea1.terrains[i].neighbor.bottom_right = num;
				}
				else
				{
					terrainArea1.terrains[i].neighbor.bottom_right = -1;
				}
				num = this.search_tile(terrainArea1, terrainArea1.terrains[i].tile_x - 1, terrainArea1.terrains[i].tile_z + 1);
				if (num != -1)
				{
					terrainArea1.terrains[i].neighbor.bottom_left = num;
				}
				else
				{
					terrainArea1.terrains[i].neighbor.bottom_left = -1;
				}
				num = this.search_tile(terrainArea1, terrainArea1.terrains[i].tile_x + 1, terrainArea1.terrains[i].tile_z - 1);
				if (num != -1)
				{
					terrainArea1.terrains[i].neighbor.top_right = num;
				}
				else
				{
					terrainArea1.terrains[i].neighbor.top_right = -1;
				}
				num = this.search_tile(terrainArea1, terrainArea1.terrains[i].tile_x - 1, terrainArea1.terrains[i].tile_z - 1);
				if (num != -1)
				{
					terrainArea1.terrains[i].neighbor.top_left = num;
				}
				else
				{
					terrainArea1.terrains[i].neighbor.top_left = -1;
				}
				terrainArea1.terrains[i].neighbor.self = i;
				terrainArea1.terrains[i].index = i;
			}
		}
	}

	public void center_terrain_position(terrain_area_class terrainArea1, terrain_class2 preterrain1)
	{
		if (preterrain1.terrain)
		{
			if (preterrain1.terrain.terrainData)
			{
				Vector3 vector = new Vector3(-preterrain1.terrain.terrainData.size.x / (float)2, (float)0, -preterrain1.terrain.terrainData.size.z / (float)2) + terrainArea1.center;
				if (preterrain1.terrain.transform.position != vector)
				{
					preterrain1.terrain.transform.position = vector;
				}
			}
		}
	}

	public int calc_terrain_index(tile_class tile, tile_class tiles)
	{
		return tile.x + tile.y * (tiles.x - 1);
	}

	Vector3 get_terrainArea_center(terrain_area_class terrainArea1,bool include_position)
	{
		if (!terrainArea1.terrains[0].terrain) {return Vector3.zero;}

        Vector2 pos, size;
        
		size.x = terrainArea1.tiles_select.x*terrainArea1.terrains[0].terrain.terrainData.size.x;
		size.y = terrainArea1.tiles_select.y*terrainArea1.terrains[0].terrain.terrainData.size.z;
		
		size /= 2;
		pos.x = size.x;
		pos.y = size.y;
		
		if (include_position)
		{
            int leftBottom = calc_terrain_index(new tile_class(0, terrainArea1.tiles.y), terrainArea1.tiles);

            // Debug.Log("left: "+leftBottom);

            pos.x = size.x+terrainArea1.terrains[leftBottom].terrain.transform.position.x;
			pos.y = size.y+terrainArea1.terrains[leftBottom].terrain.transform.position.z;
		}
		
		return new Vector3(pos.x,terrainArea1.terrains[0].terrain.transform.position.y,pos.y);
	}

	public int fit_terrain_tiles(terrain_area_class terrainArea1, terrain_class2 preterrain1, bool refit)
	{
		int arg_1BC_0;
		if (terrainArea1.terrains.Count < 2)
		{
			if (terrainArea1.terrains.Count == 1)
			{
				this.center_terrain_position(terrainArea1, terrainArea1.terrains[0]);
			}
			arg_1BC_0 = 1;
		}
		else
		{
			Vector3 position = default(Vector3);
			Vector3 vector = default(Vector3);
			vector = this.get_terrainArea_center(terrainArea1, false);
			for (int i = 0; i < terrainArea1.terrains.Count; i++)
			{
				if (terrainArea1.terrains[i].terrain)
				{
					position.x = (float)terrainArea1.terrains[i].tile_x * terrainArea1.terrains[i].terrain.terrainData.size.x + terrainArea1.center.x - vector.x;
					position.y = terrainArea1.center.y;
					position.z = (float)(terrainArea1.terrains[i].tile_z + 1) * -terrainArea1.terrains[i].terrain.terrainData.size.z + terrainArea1.center.z + vector.z;
					terrainArea1.terrains[i].rect = new Rect(position.x, position.z, this.terrain_size.x, this.terrain_size.z);
					if (refit)
					{
						terrainArea1.terrains[i].terrain.transform.position = position;
					}
				}
			}
			this.terrains_neighbor(terrainArea1);
			this.terrains_neighbor_script(terrainArea1, 1);
			arg_1BC_0 = 1;
		}
		return arg_1BC_0;
	}

	public int fit_terrain_tile(terrain_area_class terrainArea1, terrain_class2 preterrain1, bool refit)
	{
		Vector3 position = default(Vector3);
		Vector3 vector = default(Vector3);
		vector = this.get_terrainArea_center(terrainArea1, false);
		position.x = (float)preterrain1.tile_x * preterrain1.terrain.terrainData.size.x + terrainArea1.center.x - vector.x;
        if (current_area.normalizeHeightmap) position.y = 0; else position.y = -1000;
		position.z = (float)preterrain1.tile_z * preterrain1.terrain.terrainData.size.z + terrainArea1.center.z - vector.z;
		preterrain1.rect = new Rect(position.x, position.z, this.terrain_size.x, this.terrain_size.z);
		if (refit)
		{
			preterrain1.terrain.transform.position = position;
		}
		return 1;
	}

	public void terrains_neighbor_script(terrain_area_class terrainArea1, int mode)
	{
        for (int i = 0; i < terrainArea1.terrains.Count; ++i)
		{
            if (terrainArea1.terrains[i].terrain)
            {
                TerrainNeighbors terrainNeighbors = (TerrainNeighbors)terrainArea1.terrains[i].terrain.GetComponent(typeof(TerrainNeighbors));

                if (mode == 1)
                {
                    if (terrainNeighbors == null) { terrainNeighbors = (TerrainNeighbors)terrainArea1.terrains[i].terrain.gameObject.AddComponent(typeof(TerrainNeighbors)); }

                    int terrain_number = terrainArea1.terrains[i].neighbor.left;
                    if (terrain_number != -1) { terrainNeighbors.left = terrainArea1.terrains[terrain_number].terrain; } else { terrainNeighbors.left = null; }

                    terrain_number = terrainArea1.terrains[i].neighbor.top;
                    if (terrain_number != -1) { terrainNeighbors.top = terrainArea1.terrains[terrain_number].terrain; } else { terrainNeighbors.top = null; }

                    terrain_number = terrainArea1.terrains[i].neighbor.right;
                    if (terrain_number != -1) { terrainNeighbors.right = terrainArea1.terrains[terrain_number].terrain; } else { terrainNeighbors.right = null; }

                    terrain_number = terrainArea1.terrains[i].neighbor.bottom;
                    if (terrain_number != -1) { terrainNeighbors.bottom = terrainArea1.terrains[terrain_number].terrain; } else { terrainNeighbors.bottom = null; }
                }
                if (mode == -1)
                {
                    if (terrainNeighbors)
                    {
                        DestroyImmediate(terrainNeighbors);
                    }
                }
            }
        }
    }

	public int search_tile(terrain_area_class terrainArea1, int tile_x, int tile_z)
	{
		int arg_91_0;
		if (tile_x > terrainArea1.tiles_select.x - 1 || tile_x < 0)
		{
			arg_91_0 = -1;
		}
		else if (tile_z > terrainArea1.tiles_select.y - 1 || tile_z < 0)
		{
			arg_91_0 = -1;
		}
		else
		{
			for (int i = 0; i < terrainArea1.terrains.Count; i++)
			{
				if (terrainArea1.terrains[i].tile_x == tile_x && terrainArea1.terrains[i].tile_z == tile_z)
				{
					arg_91_0 = i;
					return arg_91_0;
				}
			}
			arg_91_0 = -1;
		}
		return arg_91_0;
	}

	public void update_terrain_asset(terrain_class2 preterrain)
	{
		if (preterrain.terrain)
		{
			string assetPath = AssetDatabase.GetAssetPath(preterrain.terrain.terrainData);
			AssetDatabase.ImportAsset(assetPath);
		}
	}

	public void auto_search(auto_search_class auto_search)
	{
		int select_index = auto_search.select_index;
		if (!this.global_script)
		{
			this.load_global_settings();
		}
		auto_search.format = this.global_script.auto_search_list[select_index].format;
		auto_search.digits = this.global_script.auto_search_list[select_index].digits;
		auto_search.start_x = this.global_script.auto_search_list[select_index].start_x;
		auto_search.start_y = this.global_script.auto_search_list[select_index].start_y;
		auto_search.start_n = this.global_script.auto_search_list[select_index].start_n;
		auto_search.output_format = this.global_script.auto_search_list[select_index].output_format;
	}

	public void terrains_heightmap_resolution()
	{
		for (int i = 0; i < this.terrain_region.area[0].terrains.Count; i++)
		{
		}
	}

	public void generate_begin()
	{
		this.heightmap_resolution = this.create_area.terrain_heightmap_resolution;
		if (this.heightmap_resolution < 33)
		{
			this.heightmap_resolution = 33;
		}
		else if (this.heightmap_resolution > 33 && this.heightmap_resolution < 65)
		{
			this.heightmap_resolution = 65;
		}
		else if (this.heightmap_resolution > 65 && this.heightmap_resolution < 129)
		{
			this.heightmap_resolution = 129;
		}
		else if (this.heightmap_resolution > 129 && this.heightmap_resolution < 257)
		{
			this.heightmap_resolution = 257;
		}
		else if (this.heightmap_resolution > 257 && this.heightmap_resolution < 513)
		{
			this.heightmap_resolution = 513;
		}
		else if (this.heightmap_resolution > 513 && this.heightmap_resolution < 1025)
		{
			this.heightmap_resolution = 1025;
		}
		else if (this.heightmap_resolution > 1025 && this.heightmap_resolution < 2049)
		{
			this.heightmap_resolution = 2049;
		}
		else if (this.heightmap_resolution > 2049)
		{
			this.heightmap_resolution = 4097;
		}
		if ((this.create_area.do_heightmap && (!this.terraincomposer || !this.create_area.export_to_terraincomposer)) || this.generate_manual)
		{
			this.heights = (float[,])Array.CreateInstance(typeof(float), new int[]
			{
				this.heightmap_resolution,
				this.heightmap_resolution
			});
			this.raw_file.file = this.create_area.export_heightmap_path + "/" + this.create_area.export_heightmap_filename;
			if (this.create_area.normalizeHeightmap)
			{
				this.raw_file.file = this.raw_file.file + "_N";
			}
			this.raw_file.file = this.raw_file.file + ".raw";
			if (!this.load_raw_file())
			{
				this.create_terrain_loop = false;
				if (!this.global_script.map.export_heightmap_active && !this.global_script.map.export_image_active)
				{
					Application.runInBackground = false;
				}
				this.notify_text = "Heightmap File: " + this.raw_file.file + " does not exist.";
			}
			this.raw_auto_scale();
			this.heightmap_count_terrain = 0;
			this.heightmap_break_x_value = 0;
		}
	}

	public int generate_heightmap2()
	{
		this.frames = (float)1 / (Time.realtimeSinceStartup - this.auto_speed_time);
		this.auto_speed_time = Time.realtimeSinceStartup;
		int arg_31F_0;
		if (this.terrain_region.area[0].terrains.Count == 0)
		{
			this.generate = false;
			this.create_area.terrain_done = false;
			this.Repaint();
		}
		else
		{
			if (this.terrain_region.area[0].terrains[this.heightmap_count_terrain].terrain)
			{
				this.heightmap_res_y = this.heightmap_y;
				while (this.heightmap_res_y >= this.heightmap_res_y - (float)this.generate_speed)
				{
					if (this.heightmap_res_y < (float)0)
					{
						if (this.generate)
						{
							this.terrain_apply(this.terrain_region.area[0].terrains[this.heightmap_count_terrain]);
							for (int i = 0; i < this.heightmap_resolution; i++)
							{
								for (int j = 0; j < this.heightmap_resolution; j++)
								{
									this.heights[i, j] = (float)0;
								}
							}
							this.generate = false;
						}
						if (!this.generate)
						{
							this.heightmap_count_terrain++;
							if (!this.generate_manual)
							{
								arg_31F_0 = 2;
								return arg_31F_0;
							}
							if (this.heightmap_count_terrain < this.terrain_region.area[0].terrains.Count)
							{
								this.generate = true;
								this.heightmap_res_y = (float)(this.heightmap_resolution - 1);
								this.heightmap_y = (float)(this.heightmap_resolution - 1);
								this.heightmap_break_x_value = 0;
								this.Repaint();
								arg_31F_0 = 2;
								return arg_31F_0;
							}
							this.generate_manual = false;
							this.raw_file.fs.Close();
							this.raw_file.fs.Dispose();
							this.raw_file.loaded = false;
							this.Repaint();
							arg_31F_0 = 2;
							return arg_31F_0;
						}
						else
						{
							this.heightmap_res_y = (float)(this.heightmap_resolution - 1);
							this.heightmap_y = (float)(this.heightmap_resolution - 1);
							this.heightmap_break_x_value = 0;
						}
					}
					this.heightmap_res_x = (float)this.heightmap_break_x_value;
					while (this.heightmap_res_x < (float)this.heightmap_resolution)
					{
						this.heights[(int)this.heightmap_res_y, (int)this.heightmap_res_x] = this.create_area.terrain_curve.Evaluate(this.calc_raw_value(new Vector2(this.heightmap_res_x, (float)(this.heightmap_resolution - 1) - this.heightmap_res_y), this.create_area.heightmap_offset_e));
						this.heightmap_res_x += (float)1;
					}
					this.heightmap_break_x_value = 0;
					this.heightmap_res_y -= (float)1;
				}
				this.heightmap_y -= (float)(this.generate_speed + 1);
				arg_31F_0 = 1;
				return arg_31F_0;
			}
			this.notify_text = "Terrains are not complete anymore, please recreate the terrains";
			this.generate = false;
			this.create_area.terrain_done = false;
			this.Repaint();
		}
		arg_31F_0 = 0;
		return arg_31F_0;
	}

	public void terrain_apply(terrain_class2 preterrain1)
	{
		preterrain1.terrain.terrainData.SetHeights(0, 0, this.heights);
	}

	public void raw_auto_scale()
	{
		this.conversion_step.x = (float)((this.heightmap_resolution - 1) * this.terrain_region.area[0].tiles_select.x) / (this.raw_file.resolution.x - (float)1);
		this.conversion_step.y = (float)((this.heightmap_resolution - 1) * this.terrain_region.area[0].tiles_select.y) / (this.raw_file.resolution.y - (float)1);
	}

	public float calc_raw_value(Vector2 pos, Vector2 offset)
	{
		float num = (float)0;
		float num2 = (float)0;
		float num3 = 0f;
		float num4 = 0f;
		num3 = (float)(this.terrain_region.area[0].terrains[this.heightmap_count_terrain].tile_x * (this.heightmap_resolution - 1));
		num4 = (float)((this.terrain_region.area[0].tiles_select.y - this.terrain_region.area[0].terrains[this.heightmap_count_terrain].tile_z - 1) * (this.heightmap_resolution - 1));
		pos.x = (pos.x + num3) / this.conversion_step.x + num;
		pos.y = (pos.y + num4) / this.conversion_step.y + num2;
		this.h_local_x = (int)pos.x;
		this.h_local_y = (int)pos.y;
		float arg_1F0_0;
		if ((float)this.h_local_x > this.raw_file.resolution.x - (float)1 || this.h_local_x < 0)
		{
			arg_1F0_0 = (float)0;
		}
		else if ((float)this.h_local_y > this.raw_file.resolution.y - (float)1 || this.h_local_y < 0)
		{
			arg_1F0_0 = (float)0;
		}
		else
		{
			ulong num5 = (ulong)((float)this.h_local_y * (this.raw_file.resolution.x * (float)2) + (float)(this.h_local_x * 2));
			this.raw_file.fs.Position = (long)num5;
			byte b = (byte)this.raw_file.fs.ReadByte();
			byte b2 = (byte)this.raw_file.fs.ReadByte();
			arg_1F0_0 = ((float)b * this.raw_file.product1 + (float)b2 * this.raw_file.product2) / 65535f;
		}
		return arg_1F0_0;
	}

	public bool load_raw_file()
	{
		bool arg_198_0;
		if (!File.Exists(this.raw_file.file))
		{
			arg_198_0 = false;
		}
		else
		{
			this.raw_file.fs = new FileStream(this.raw_file.file, FileMode.Open);
			if (!this.create_region.area[this.create_region.area_select].import_heightmap)
			{
				this.raw_file.resolution.x = this.create_region.area[this.create_region.area_select].heightmap_resolution.x;
				this.raw_file.resolution.y = this.create_region.area[this.create_region.area_select].heightmap_resolution.y;
			}
			else
			{
				this.raw_file.resolution.x = this.create_region.area[this.create_region.area_select].converter_resolution.x;
				this.raw_file.resolution.y = this.create_region.area[this.create_region.area_select].converter_resolution.y;
			}
			if (this.raw_file.mode == raw_mode_enum.Mac)
			{
				this.raw_file.product1 = 256f;
				this.raw_file.product2 = 1f;
			}
			else
			{
				this.raw_file.product1 = 1f;
				this.raw_file.product2 = 256f;
			}
			this.raw_file.loaded = true;
			arg_198_0 = true;
		}
		return arg_198_0;
	}

	public void add_area(map_region_class region1, int index, string name)
	{
		region1.area.Add(new map_area_class(name, index));
		index = region1.area.Count - 1;
		map_area_class map_area_class = region1.area[index];
		map_area_class.center = this.global_script.map_latlong_center;
		region1.area_select = region1.area.Count - 1;
		region1.make_area_popup();
		map_area_class.export_heightmap_path = Application.dataPath;
		map_area_class.export_image_path = map_area_class.export_heightmap_path;
		map_area_class.export_terrain_path = map_area_class.export_heightmap_path + "/Terrains";
		map_area_class.export_heightmap_filename = map_area_class.name;
		map_area_class.export_image_filename = map_area_class.name;
		map_area_class.terrain_scene_name = "_" + map_area_class.name;
		map_area_class.terrain_scene_name = map_area_class.name;
	}

	public void set_terrain_default(map_area_class area1)
	{
		area1.export_image_import_settings = true;
		area1.export_terrain_path = area1.export_heightmap_path + "/Terrains";
		area1.export_to_terraincomposer = true;
		area1.terrain_scene_name = "_" + area1.name;
		area1.terrain_scene_name = area1.name;
		area1.do_heightmap = true;
		area1.do_image = true;
		area1.mipmapEnabled = true;
		area1.filterMode = FilterMode.Trilinear;
		area1.anisoLevel = 9;
		area1.maxTextureSize_select = 6;
		area1.auto_import_settings_apply = true;

        #if UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4
        area1.textureFormat = TextureImporterFormat.AutomaticCompressed;
        #endif
    }

	public void init_paths()
	{
		if (this.global_script)
		{
			map_area_class map_area_class = this.global_script.map.region[this.global_script.map.region_select].area[this.global_script.map.region[this.global_script.map.region_select].area_select];
			if (map_area_class.export_heightmap_path.Length == 0)
			{
				map_area_class.export_heightmap_path = Application.dataPath;
			}
			if (map_area_class.export_image_path.Length == 0)
			{
				map_area_class.export_image_path = Application.dataPath;
			}
			if (map_area_class.export_terrain_path.Length == 0)
			{
				map_area_class.export_terrain_path = Application.dataPath + "/Terrains";
			}
			if (!string.IsNullOrEmpty(map_area_class.preimage_path))
			{
				if (map_area_class.preimage_path.Length == 0)
				{
					if (!map_area_class.preimage_path_changed)
					{
						map_area_class.preimage_path = map_area_class.export_image_path;
					}
					else
					{
						map_area_class.preimage_path = Application.dataPath;
					}
				}
			}
			else
			{
				map_area_class.preimage_path = Application.dataPath;
			}
		}
	}

	public void copy_texture_to_buffer(buffer_class buffer, Texture2D texture, int x, int y, int width, int height)
	{
		this.pixels = texture.GetPixels(x, y, width, height);
		if (buffer.bytes != null)
		{
			if (buffer.bytes.Length != this.pixels.Length * 3)
			{
				buffer.bytes = new byte[this.pixels.Length * 3];
			}
		}
		else
		{
			buffer.bytes = new byte[this.pixels.Length * 3];
		}
		for (int i = 0; i < this.pixels.Length; i++)
		{
			buffer.bytes[i * 3] = (byte)(this.pixels[i][0] * (float)255);
			buffer.bytes[i * 3 + 1] = (byte)(this.pixels[i][1] * (float)255);
			buffer.bytes[i * 3 + 2] = (byte)(this.pixels[i][2] * (float)255);
		}
	}

	public void copy_buffer_to_texture(buffer_class buffer)
	{
		if (this.pixels == null)
		{
			this.pixels = new Color[buffer.bytes.Length / 3];
		}
		else if (this.pixels.Length != buffer.bytes.Length / 3)
		{
			this.pixels = new Color[buffer.bytes.Length / 3];
		}
		for (int i = 0; i < this.pixels.Length; i++)
		{
			this.pixels[i][0] = (float)buffer.bytes[i * 3] * 1f / (float)255;
			this.pixels[i][1] = (float)buffer.bytes[i * 3 + 1] * 1f / (float)255;
			this.pixels[i][2] = (float)buffer.bytes[i * 3 + 2] * 1f / (float)255;
		}
	}

	public void image_map2()
	{
		if (!this.global_script.map2)
		{
			this.global_script.map2 = new Texture2D(800, 800, TextureFormat.RGBA32, false, true);
		}
		this.pixels = this.global_script.map2.GetPixels(0, 32, 800, 768);
		this.global_script.map0.SetPixels(800, 0, 800, 768, this.pixels);
		this.global_script.map0.Apply();
	}

	public void image_generate_begin()
	{
		if (!this.global_script.map.preimage_edit.generate || this.global_script.map.preimage_edit.mode != 2)
		{
			if (!this.global_script.map.preimage_edit.generate)
			{
				this.global_script.map.preimage_edit.y1 = 0;
				this.global_script.map.preimage_edit.x1 = 0;
				this.global_script.map.preimage_edit.mode = 1;
				this.global_script.map.preimage_edit.generate = true;
				this.global_script.map.preimage_edit.repeat = 0;
				int num = this.global_script.map.preimage_edit.radiusSelect;
				if (num > 740)
				{
					num = 740;
				}
				this.global_script.map.preimage_edit.radius = num;
				this.global_script.map.preimage_edit.first = true;
				this.global_script.map.preimage_edit.resolution = new Vector2((float)800, (float)768);
				this.global_script.map.preimage_edit.inputBuffer.resolution = new Vector2((float)800, (float)768);
				this.global_script.map.preimage_edit.inputBuffer.size = new Vector2((float)800, (float)768);
				this.global_script.map.preimage_edit.inputBuffer.radius = -20;
				this.global_script.map.preimage_edit.inputBuffer.init();
				this.global_script.map.preimage_edit.tile.x = 0;
				this.global_script.map.preimage_edit.tile.y = 0;
				this.global_script.map.preimage_edit.inputBuffer.getRects(this.global_script.map.preimage_edit.tile);
				if (this.global_script.map.preimage_edit.inputBuffer.file != null)
				{
					this.global_script.map.preimage_edit.inputBuffer.file.Close();
				}
				this.global_script.map.preimage_edit.outputBuffer.resolution = this.global_script.map.preimage_edit.inputBuffer.resolution;
				this.global_script.map.preimage_edit.outputBuffer.size = this.global_script.map.preimage_edit.inputBuffer.size;
				this.global_script.map.preimage_edit.outputBuffer.radius = this.global_script.map.preimage_edit.inputBuffer.radius;
				this.global_script.map.preimage_edit.outputBuffer.init();
				this.global_script.map.preimage_edit.tile.x = 0;
				this.global_script.map.preimage_edit.tile.y = 0;
				this.global_script.map.preimage_edit.outputBuffer.getRects(this.global_script.map.preimage_edit.tile);
				this.copy_texture_to_buffer(this.global_script.map.preimage_edit.inputBuffer, this.global_script.map1, 0, 32, 800, 768);
				this.global_script.map.preimage_edit.outputBuffer.clear_bytes();
			}
			else
			{
				this.global_script.map.preimage_edit.generate_call = true;
			}
		}
	}

	public void image_edit_apply()
	{
		if (!this.global_script.map0)
		{
			this.global_script.map0 = new Texture2D(1600, 768, TextureFormat.RGBA32, false, true);
		}
		this.global_script.map.preimage_edit.convert_texture_raw(true);
		if (!this.global_script.map.preimage_edit.generate)
		{
			this.copy_buffer_to_texture(this.global_script.map.preimage_edit.outputBuffer);
			this.global_script.map0.SetPixels(800, 0, 800, 768, this.pixels);
			this.global_script.map0.Apply();
			if (this.global_script.map.preimage_edit.generate_call)
			{
				this.global_script.map.preimage_edit.regen = false;
				this.global_script.map.preimage_edit.border = false;
				this.image_generate_begin();
				this.global_script.map.preimage_edit.generate_call = false;
			}
			else if (this.global_script.map.preimage_edit.regen)
			{
				this.global_script.map.preimage_edit.inputBuffer.copy_bytes(this.global_script.map.preimage_edit.outputBuffer.bytes, this.global_script.map.preimage_edit.inputBuffer.bytes);
				this.global_script.map.preimage_edit.y1 = 0;
				this.global_script.map.preimage_edit.x1 = 0;
				this.global_script.map.preimage_edit.generate = true;
				this.global_script.map.preimage_edit.first = false;
				this.global_script.map.preimage_edit.regen = false;
				this.global_script.map.preimage_edit.radius = this.global_script.map.preimage_edit.radius - 25;
				this.global_script.map.preimage_edit.repeat = this.global_script.map.preimage_edit.repeat + 1;
			}
		}
		this.Repaint();
	}

	public bool convert_textures_begin(map_area_class area1)
	{
        String path1 = current_area.export_image_path + "/" + current_area.export_image_filename + "_combined.raw";

        if (!File.Exists(path1))
        {
            notify_text = path1 + " doesn't exist! Export images as Raw in 'Image Export', after that use the 'Combine' button to combine them.";
            Debug.Log(path1 + " doesn't exist! Export images as Raw in 'Image Export', after that use the 'Combine' button to combine them.");
            return false;
        }

        global_script.map.preimage_edit.time_start = Time.realtimeSinceStartup;

        String path2;

        if (!current_area.preimage_save_new)
        {
            path2 = current_area.export_image_path + "/" + current_area.export_image_filename + "_combined2.raw";
        }
        else
        {
            path2 = current_area.preimage_path + "/" + current_area.preimage_filename + "_combined2.raw";
        }

        global_script.map.preimage_edit.first = true;
        global_script.map.preimage_edit.resolution = new Vector2(2048, 2048);

        //global_script.map.preimage_edit.outputRaw = new FileStream(current_area.export_image_path+"/"+current_area.export_image_filename+"_combined2.raw",FileMode.Create);

        global_script.map.preimage_edit.radius = global_script.map.preimage_edit.radiusSelect;

        global_script.map.preimage_edit.inputBuffer.resolution = new Vector2(current_area.resolution * current_area.tiles.x, current_area.resolution * current_area.tiles.y);
        //global_script.map.preimage_edit.inputBuffer.resolution = Vector2(8192,8192);
        global_script.map.preimage_edit.inputBuffer.size = new Vector2(2048, 2048);
        global_script.map.preimage_edit.inputBuffer.radius = global_script.map.preimage_edit.radius;

        global_script.map.preimage_edit.inputBuffer.init();
        global_script.map.preimage_edit.tile.x = 0;
        global_script.map.preimage_edit.tile.y = 0;
        global_script.map.preimage_edit.inputBuffer.getRects(global_script.map.preimage_edit.tile);

        if (global_script.map.preimage_edit.inputBuffer.file != null) { global_script.map.preimage_edit.inputBuffer.file.Close(); }
        global_script.map.preimage_edit.inputBuffer.file = new FileStream(path1, FileMode.Open);
        global_script.map.preimage_edit.inputBuffer.read();

        // global_script.map.preimage_edit.outputBuffer.resolution = Vector2(current_area.resolution*current_area.tiles.x,current_area.resolution*current_area.tiles.y);

        global_script.map.preimage_edit.outputBuffer.resolution = global_script.map.preimage_edit.inputBuffer.resolution;
        global_script.map.preimage_edit.outputBuffer.size = global_script.map.preimage_edit.inputBuffer.size;
        global_script.map.preimage_edit.outputBuffer.radius = global_script.map.preimage_edit.radius;

        global_script.map.preimage_edit.outputBuffer.init();
        global_script.map.preimage_edit.tile.x = 0;
        global_script.map.preimage_edit.tile.y = 0;
        global_script.map.preimage_edit.outputBuffer.getRects(global_script.map.preimage_edit.tile);
        global_script.map.preimage_edit.outputBuffer.clear_bytes();
        if (global_script.map.preimage_edit.outputBuffer.file != null) { global_script.map.preimage_edit.outputBuffer.file.Close(); }
        global_script.map.preimage_edit.outputBuffer.file = new FileStream(path2, FileMode.Create);

        // global_script.map.preimage_edit.outputBuffer.copy_bytes(global_script.map.preimage_edit.inputBuffer.bytes,global_script.map.preimage_edit.outputBuffer.bytes);
        // global_script.map.preimage_edit.outputBuffer.write();

        // if (global_script.map.preimage_edit.inputBuffer.file) {global_script.map.preimage_edit.inputBuffer.file.Close();}
        // if (global_script.map.preimage_edit.outputBuffer.file) {global_script.map.preimage_edit.outputBuffer.file.Close();}
        //}
        //else {
        //global_script.map.preimage_edit.outputRaw = new FileStream(current_area.export_image_path+"/"+current_area.export_image_filename+"_combined2.raw",FileMode.Open);
        //}
        global_script.map.preimage_edit.generate = true;
        global_script.map.preimage_edit.y1 = 0;
        global_script.map.preimage_edit.x1 = 0;
        global_script.map.preimage_edit.repeat = 0;
        global_script.map.preimage_edit.mode = 2;
        return true;
    }

	public void convert_textures_raw(map_area_class area1)
	{
		this.global_script.map.preimage_edit.convert_texture_raw(true);
		if (!this.global_script.map.preimage_edit.generate)
		{
			this.global_script.map.preimage_edit.outputBuffer.write();
			this.global_script.map.preimage_edit.tile.x = this.global_script.map.preimage_edit.tile.x + 1;
			if (this.global_script.map.preimage_edit.tile.x > this.global_script.map.preimage_edit.inputBuffer.tiles.x - 1)
			{
				this.global_script.map.preimage_edit.tile.x = 0;
				this.global_script.map.preimage_edit.tile.y = this.global_script.map.preimage_edit.tile.y + 1;
				if (this.global_script.map.preimage_edit.tile.y > this.global_script.map.preimage_edit.inputBuffer.tiles.y - 1)
				{
					if (!this.global_script.map.preimage_edit.regen)
					{
						if (this.global_script.map.preimage_edit.inputBuffer.file != null)
						{
							this.global_script.map.preimage_edit.inputBuffer.file.Close();
						}
						if (this.global_script.map.preimage_edit.outputBuffer.file != null)
						{
							this.global_script.map.preimage_edit.outputBuffer.file.Close();
						}
						return;
					}
					this.global_script.map.preimage_edit.inputBuffer.file = this.global_script.map.preimage_edit.outputBuffer.file;
					this.global_script.map.preimage_edit.tile.x = 0;
					this.global_script.map.preimage_edit.tile.y = 0;
					this.global_script.map.preimage_edit.first = false;
					this.global_script.map.preimage_edit.regen = false;
					this.global_script.map.preimage_edit.radius = this.global_script.map.preimage_edit.radius - 25;
					this.global_script.map.preimage_edit.repeat = this.global_script.map.preimage_edit.repeat + 1;
				}
			}
			this.global_script.map.preimage_edit.inputBuffer.getRects(this.global_script.map.preimage_edit.tile);
			this.global_script.map.preimage_edit.outputBuffer.getRects(this.global_script.map.preimage_edit.tile);
			this.global_script.map.preimage_edit.outputBuffer.clear_bytes();
			this.global_script.map.preimage_edit.inputBuffer.read();
			this.global_script.map.preimage_edit.generate = true;
			this.global_script.map.preimage_edit.y1 = (int)this.global_script.map.preimage_edit.inputBuffer.offset.y;
		}
		this.Repaint();
	}

	public void load_convert_texture(map_area_class area1)
	{
		this.convert_tile.y = area1.preimage_count / area1.tiles.x;
		this.convert_tile.x = area1.preimage_count - this.convert_tile.y * area1.tiles.x;
		string text = area1.export_image_filename + "_x" + this.convert_tile.x + "_y" + this.convert_tile.y;
		string text2 = area1.export_image_path + "/";
		if (this.global_script.map.export_jpg)
		{
			if (File.Exists(text2 + text + ".jpg"))
			{
				this.global_script.set_image_import_settings(text2.Replace(Application.dataPath, "Assets") + text + ".jpg", true, TextureImporterFormat.RGB24, TextureWrapMode.Clamp, this.convert_area.resolution, this.convert_area.mipmapEnabled, this.convert_area.filterMode, this.convert_area.anisoLevel, 3);
				this.convert_texture = (Texture2D)AssetDatabase.LoadAssetAtPath(text2.Replace(Application.dataPath, "Assets") + text + ".jpg", typeof(Texture2D));
			}
			else
			{
				this.notify_text = text2 + text + ".jpg doesn't exist! Make sure the image tiles are the same as the exported image tiles";
				Debug.Log(text2 + text + ".jpg doesn't exist! Make sure the image tiles are the same as the exported image tiles.");
			}
		}
		else if (this.global_script.map.export_png)
		{
			if (File.Exists(text2 + text + ".png"))
			{
				this.global_script.set_image_import_settings(text2.Replace(Application.dataPath, "Assets") + text + ".png", true, TextureImporterFormat.RGB24, TextureWrapMode.Clamp, this.convert_area.resolution, this.convert_area.mipmapEnabled, this.convert_area.filterMode, this.convert_area.anisoLevel, 3);
				this.convert_texture = (Texture2D)AssetDatabase.LoadAssetAtPath(text2.Replace(Application.dataPath, "Assets") + text + ".png", typeof(Texture2D));
			}
			else
			{
				this.notify_text = text2 + text + ".png doesn't exist! Make sure the image tiles are the same as the exported image tiles";
				Debug.Log(text2 + text + ".png doesn't exist! Make sure the image tiles are the same as the exported image tiles.");
			}
		}
	}

	public void save_convert_texture(map_area_class area1)
	{
		string text;
		string text2;
		if (area1.preimage_save_new)
		{
			text = area1.preimage_filename + "_x" + this.convert_tile.x + "_y" + this.convert_tile.y;
			text2 = area1.preimage_path;
		}
		else
		{
			text = area1.export_image_filename + "_x" + this.convert_tile.x + "_y" + this.convert_tile.y;
			text2 = area1.export_image_path;
		}
		if (this.global_script.map.export_jpg)
		{
			this.export_texture_as_jpg(text2 + "/" + text + ".jpg", this.convert_texture, this.global_script.map.export_jpg_quality);
			string text3 = area1.export_image_filename + "_x" + this.convert_tile.x + "_y" + this.convert_tile.y;
			string export_image_path = area1.export_image_path;
			this.global_script.set_image_import_settings(export_image_path.Replace(Application.dataPath, "Assets") + "/" + text3 + ".jpg", false, area1.textureFormat, TextureWrapMode.Clamp, area1.resolution, area1.mipmapEnabled, area1.filterMode, area1.anisoLevel, 127);
			if (this.global_script.map.preimage_edit.import_settings)
			{
				this.import_image_area = area1;
				this.import_jpg_path = text2.Replace(Application.dataPath, "Assets") + "/" + text + ".jpg";
				this.import_settings_call = true;
				this.import_jpg_call = true;
			}
		}
		if (this.global_script.map.export_png)
		{
			this.export_texture_to_file(text2, text, this.convert_texture);
			string text3 = area1.export_image_filename + "_x" + this.convert_tile.x + "_y" + this.convert_tile.y;
			string export_image_path = area1.export_image_path;
			this.global_script.set_image_import_settings(export_image_path.Replace(Application.dataPath, "Assets") + "/" + text3 + ".png", false, area1.textureFormat, TextureWrapMode.Clamp, area1.resolution, area1.mipmapEnabled, area1.filterMode, area1.anisoLevel, 127);
			if (this.global_script.map.preimage_edit.import_settings)
			{
				this.import_image_area = area1;
				this.import_png_path = text2.Replace(Application.dataPath, "Assets") + "/" + text + ".png";
				this.import_settings_call = true;
				this.import_png_call = true;
			}
		}
	}

	public void check_content_done()
	{
		if (this.global_script)
		{
			if (this.global_script.settings.wc_loading > 0)
			{
				if (this.global_script.settings.wc_contents == null)
				{
					this.global_script.settings.wc_loading = 0;
				}
				else
				{
					int num = this.read_check();
					if (this.global_script.settings.wc_loading == 1)
					{
						if (this.global_script.settings.wc_contents.isDone)
						{
							this.global_script.settings.wc_loading = 0;
							float num2 = 0f;
							float num3 = 0f;
							num3 = this.read_version();
							this.write_checked(DateTime.Now.Day.ToString());
							if (float.TryParse(this.global_script.settings.wc_contents.text, out num2))
							{
								this.global_script.settings.new_version = num2;
								this.global_script.settings.old_version = num3;
								if (num2 > num3)
								{
									this.global_script.map.button_update = true;
									this.notify_text = "A new WorldComposer update is available";
									if (num == 0)
									{
										this.global_script.settings.update_version = true;
									}
									else if (num == 1)
									{
										this.global_script.settings.update_display = true;
										this.global_script.settings.update_version = true;
									}
									else if (num > 1)
									{
										this.global_script.settings.update_version = true;
										this.content_version();
									}
								}
								else
								{
									this.global_script.settings.update_version = false;
								}
							}
						}
					}
					else if (this.global_script.settings.wc_loading == 2)
					{
						if (this.global_script.settings.wc_contents.isDone)
						{
							this.global_script.settings.wc_loading = 0;
							this.global_script.settings.update_version2 = true;
							this.global_script.settings.update_version = false;
							File.WriteAllBytes(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/WorldComposer.unitypackage", this.global_script.settings.wc_contents.bytes);
							if (num < 3)
							{
								this.global_script.settings.update_display = true;
							}
							else if (num == 3)
							{
								this.global_script.settings.update_display = true;
								this.import_contents(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/WorldComposer.unitypackage", false);
							}
							else if (num == 4)
							{
								this.import_contents(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/WorldComposer.unitypackage", false);
							}
						}
					}
					else if (this.global_script.settings.wc_loading == 3)
					{
						if (this.global_script.settings.new_version == this.read_version())
						{
							AssetDatabase.Refresh();
							this.global_script.settings.wc_loading = 4;
						}
						else if (EditorApplication.timeSinceStartup > (double)(this.global_script.settings.time_out + (float)60))
						{
							this.global_script.settings.wc_loading = 0;
							Debug.Log("Time out with importing WorldComposer update...");
						}
					}
					else if (this.global_script.settings.wc_loading == 4)
					{
						Debug.Log("Updated WorldComposer version " + this.global_script.settings.old_version + " to version " + this.read_version().ToString("F3"));
						this.notify_text = "Updated WorldComposer version " + this.global_script.settings.old_version + " to version " + this.read_version().ToString("F3");
						this.global_script.settings.wc_loading = 0;
					}
				}
			}
		}
	}

	public float read_version()
	{
		StreamReader streamReader = File.OpenText(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/version.txt");
		string s = streamReader.ReadLine();
		streamReader.Close();
		float result = 0f;
		float.TryParse(s, out result);
		return result;
	}

	public void write_check(string text)
	{
		StreamWriter streamWriter = new StreamWriter(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/check.txt");
		streamWriter.WriteLine(text);
		streamWriter.Close();
	}

	public int read_check()
	{
		if (!File.Exists(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/check.txt"))
		{
			this.write_check("1");
		}
		StreamReader streamReader = File.OpenText(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/check.txt");
		string s = streamReader.ReadLine();
		streamReader.Close();
		int result = 0;
		int.TryParse(s, out result);
		return result;
	}

	public void write_checked(string text)
	{
		StreamWriter streamWriter = new StreamWriter(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/last_checked.txt");
		streamWriter.WriteLine(text);
		streamWriter.Close();
	}

	public float read_checked()
	{
		if (!File.Exists(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/last_checked.txt"))
		{
			this.write_checked("-1");
		}
		StreamReader streamReader = File.OpenText(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/Update/WorldComposer/last_checked.txt");
		string s = streamReader.ReadLine();
		streamReader.Close();
		float result = 0f;
		float.TryParse(s, out result);
		return result;
	}

	public void content_startup()
	{
		if (this.read_checked() != (float)DateTime.Now.Day && this.read_check() > 0)
		{
			this.check_content_version();
		}
	}

	public void content_version()
	{
		Encoding unicode = Encoding.Unicode;
		if (global_script.settings.wc_contents != null)
		{
			this.global_script.settings.wc_contents.Dispose();
		}
		this.global_script.settings.wc_contents = new WWW(unicode.GetString(this.process_out(File.ReadAllBytes(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/templates/content4.dat"))));
		this.global_script.settings.wc_loading = 2;
	}

	public void check_content_version()
	{
		Encoding unicode = Encoding.Unicode;
		if (this.global_script)
		{
			if (global_script.settings.wc_contents != null)
			{
				this.global_script.settings.wc_contents.Dispose();
			}
			this.global_script.settings.wc_contents = new WWW(unicode.GetString(this.process_out(File.ReadAllBytes(Application.dataPath + this.install_path.Replace("Assets", string.Empty) + "/templates/content3.dat"))));
			this.global_script.settings.wc_loading = 1;
		}
	}

	public void import_contents(string path, bool window)
	{
		FileInfo fileInfo = new FileInfo(Application.dataPath + "/tc_build/build.txt");
		if (fileInfo.Exists)
		{
			Debug.Log("Updating canceled because of development version");
		}
		else
		{
			AssetDatabase.Refresh();
			AssetDatabase.ImportPackage(path, window);
			this.Repaint();
		}
		this.global_script.settings.update_version2 = false;
		this.global_script.settings.time_out = (float)EditorApplication.timeSinceStartup;
		this.global_script.settings.wc_loading = 3;
	}

	public void asc_convert_to_raw(string import_path, string export_path)
	{
        // var ttt1: float = Time.realtimeSinceStartup;
        Vector2 minMax = GetAscMinMax(import_path, export_path);
        float deltaHeight = minMax.y - minMax.x;
        Debug.Log("Height range = " + deltaHeight);
        // return;
        // if (current_area.converter_height == 0) {current_area.converter_height = 9000;}

        String text;
        StreamReader file;
        FileStream export_file;
        int no_data;
        float height;
        char s;
        byte byte_hi;
        byte byte_lo;
        int value_int;
        Vector2 resolution;

        file = new StreamReader(import_path);
        export_file = new FileStream(export_path, FileMode.Create);

        text = file.ReadLine();
        text = text.Replace("ncols", String.Empty);
        resolution.x = Int16.Parse(text);
        // Debug.Log(resolution.x);

        text = file.ReadLine();
        text = text.Replace("nrows", String.Empty);
        resolution.y = Int16.Parse(text);

        // Debug.Log(resolution.y);
        Debug.Log("Heightmap resolution X:" + resolution.x + " Y:" + resolution.y);

        current_area.converter_resolution = resolution;

        text = file.ReadLine();
        // Debug.Log(text);
        text = file.ReadLine();
        // Debug.Log(text);
        text = file.ReadLine();
        // Debug.Log(text);

        text = file.ReadLine();
        text = text.Replace("nodata_value", String.Empty);
        text = text.Replace("NODATA_value", String.Empty);
        no_data = Int16.Parse(text);
        // Debug.Log(text);

        text = String.Empty;

        do
        {
            s = (char)file.Read();
            if (s == 32)
            {
                text = text.Replace(",", ".");
                Single.TryParse(text, out height);
                if (height == no_data) { height = 0; }
                else
                {
                    height = (height - minMax.x) * (65535.0f / deltaHeight);
                }
                value_int = (int)height;

                byte_hi = (byte)(value_int >> 8);
                byte_lo = (byte)(value_int - (byte_hi << 8));

                export_file.WriteByte(byte_lo);
                export_file.WriteByte(byte_hi);

                text = String.Empty;
            }
            text += s;
        }
        while (!file.EndOfStream);

        file.Close();
        export_file.Close();

        Debug.Log("Converted " + import_path + " -> " + export_path);
        notify_text = "Converted " + import_path + " -> " + export_path;
    }

	public Vector2 GetAscMinMax(string import_path, string export_path)
	{
        String text;
        StreamReader file;
        int no_data;
        float height;
        char s;
        Vector2 resolution;
        float min = 99999999999;
        float max = -99999999999;

        file = new StreamReader(import_path);

        text = file.ReadLine();
        text = text.Replace("ncols", String.Empty);
        resolution.x = Int16.Parse(text);

        text = file.ReadLine();
        text = text.Replace("nrows", String.Empty);
        resolution.y = Int16.Parse(text);

        current_area.converter_resolution = resolution;

        text = file.ReadLine();
        text = file.ReadLine();
        text = file.ReadLine();

        text = file.ReadLine();
        text = text.Replace("nodata_value", String.Empty);
        text = text.Replace("NODATA_value", String.Empty);
        no_data = Int16.Parse(text);

        text = String.Empty;

        do
        {
            s = (char)file.Read();
            if (s == 32)
            {
                text = text.Replace(",", ".");
                Single.TryParse(text, out height);
                if (height == no_data) { height = 0; }
                else
                {
                    if (height > max) max = height;
                    else if (height < min) min = height;
                }
                text = String.Empty;
            }
            text += s;
        }
        while (!file.EndOfStream);

        file.Close();
        Debug.Log("Minimum height = " + min + " Maximum height = " + max);

        return new Vector2(min, max);
    }

	public bool check_in_rect()
	{
		return (this.map_parameters_rect.Contains(this.key.mousePosition) && this.global_script.map.button_parameters) || (this.regions_rect.Contains(this.key.mousePosition) && this.global_script.map.button_region) || (this.areas_rect.Contains(this.key.mousePosition) && this.global_script.map.button_region) || (this.heightmap_export_rect.Contains(this.key.mousePosition) && this.global_script.map.button_heightmap_export) || (this.image_export_rect.Contains(this.key.mousePosition) && this.global_script.map.button_image_export) || (this.image_editor_rect.Contains(this.key.mousePosition) && this.global_script.map.button_image_editor) || (this.converter_rect.Contains(this.key.mousePosition) && this.global_script.map.button_converter) || (this.settings_rect.Contains(this.key.mousePosition) && this.global_script.map.button_settings) || (this.create_terrain_rect.Contains(this.key.mousePosition) && this.global_script.map.button_create_terrain) || (this.update_rect.Contains(this.key.mousePosition) && this.global_script.map.button_update);
	}

	public void create_info_window()
	{
        if (info_window) { info_window.Close(); return; }
        info_window = (Info_tc)EditorWindow.GetWindow(typeof(Info_tc));
        info_window.global_script = global_script;

        info_window.backgroundColor = new Color(0, 0, 0, 0.5f);

        info_window.text = String.Empty;
        StreamReader sr = File.OpenText(Application.dataPath + install_path.Replace("Assets", "") + "/WorldComposer Release Notes.txt");

        info_window.update_height = 0;
        sr.ReadLine();
        sr.ReadLine();
        sr.ReadLine();

        do
        {
            info_window.text += sr.ReadLine() + "\n";
            info_window.update_height += 13;
        }
        while (!sr.EndOfStream);
        sr.Close();

        info_window.update_height += 13;
        info_window.minSize = new Vector2(1024, 512);
#if UNITY_3_4 || UNITY_3_5 || UNITY_4_0 || UNITY_4_01 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_5_0
		info_window.title = "Release Notes";
#else
        info_window.titleContent = new GUIContent("Release Notes");
#endif
        info_window.parent = this;
    }

	public void smooth_terrain(terrain_class2 preterrain1, float strength)
	{
		if (preterrain1.terrain)
		{
			int heightmapResolution = preterrain1.terrain.terrainData.heightmapResolution ;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = (float)1;
			float num7 = (float)1;
			this.heights = preterrain1.terrain.terrainData.GetHeights(0, 0, heightmapResolution, heightmapResolution);
			for (int i = 0; i < 1; i++)
			{
				for (int j = 0; j < heightmapResolution; j++)
				{
					for (int k = 1; k < heightmapResolution - 1; k++)
					{
						num3 = this.heights[k - 1, j];
						num = this.heights[k, j];
						num4 = this.heights[k + 1, j];
						num2 = num - (num3 + num4) / (float)2;
						num2 *= (float)1 - strength * num6 * num7;
						num5 = num2 + (num3 + num4) / (float)2;
						this.heights[k, j] = num5;
					}
				}
				for (int j = 1; j < heightmapResolution - 1; j++)
				{
					for (int k = 0; k < heightmapResolution; k++)
					{
						num3 = this.heights[k, j - 1];
						num = this.heights[k, j];
						num4 = this.heights[k, j + 1];
						num2 = num - (num3 + num4) / (float)2;
						num2 *= (float)1 - strength * num6 * num7;
						num5 = num2 + (num3 + num4) / (float)2;
						this.heights[k, j] = num5;
					}
				}
			}
			preterrain1.terrain.terrainData.SetHeights(0, 0, this.heights);
			if (preterrain1.color_terrain[0] < 1.5f)
			{
				preterrain1.color_terrain += new Color(0.5f, 0.5f, (float)1, 0.5f);
			}
		}
	}

	public void smooth_all_terrain(float strength)
	{
		for (int i = 0; i < this.terrain_region.area[0].terrains.Count; i++)
		{
			this.smooth_terrain(this.terrain_region.area[0].terrains[i], strength);
		}
		this.heights = (float[,])Array.CreateInstance(typeof(float), new int[2]);
	}

	public void save_global_settings()
	{
		if (this.global_script)
		{
			EditorUtility.SetDirty(this.global_script);
			AssetDatabase.SaveAssets();
		}
	}

    public void CreateRTPCombinedTextures(terrain_class2 preterrain1, Type globalSettingsHolderType, object globalSettingsHolder)
    {
        globalSettingsHolderType.GetMethod("RefreshAll").Invoke(globalSettingsHolder, null);

        bool heightTexturesCreated = true;

        bool normalTexturesCreated = (bool)globalSettingsHolderType.GetMethod("PrepareNormals").Invoke(globalSettingsHolder, null);

        if (!normalTexturesCreated)
        {
            notify_text = "RTP needs the Normal Textures to be readable and they have to be the same size, pleace adjust this in the image import settings";
            return;
        }

        int layerCount = (int)globalSettingsHolderType.GetField("numLayers").GetValue(globalSettingsHolder);
        Texture2D[] texHeights = (Texture2D[])globalSettingsHolderType.GetField("Heights").GetValue(globalSettingsHolder);

        Texture2D texHeightmap0 = RTPMethods.PrepareHeights(0, layerCount, texHeights);
        if (texHeightmap0 != null) {
            globalSettingsHolderType.GetField("HeightMap").SetValue(globalSettingsHolder, texHeightmap0);

            if (layerCount > 4)
            {
                Texture2D texHeightmap2 = RTPMethods.PrepareHeights(4, layerCount, texHeights);
                if (texHeightmap2 != null)
                {
                    globalSettingsHolderType.GetField("HeightMap2").SetValue(globalSettingsHolder, texHeightmap2);
                    if (layerCount > 8)
                    {
                        Texture2D texHeightmap3 = RTPMethods.PrepareHeights(8, layerCount, texHeights);
                        if (texHeightmap3 != null) globalSettingsHolderType.GetField("HeightMap3").SetValue(globalSettingsHolder, texHeightmap3);
                        else heightTexturesCreated = false;
                    }
                }
                else heightTexturesCreated = false;
            }
        }
        else heightTexturesCreated = false;
        
        if (!heightTexturesCreated)
        {
            notify_text = "RTP needs the Height Textures to be readable and they have to be the same size, pleace adjust this in the image import settings";
            return;
        }
    }

    public void load_button_textures()
	{
		this.button_settings = (Texture)AssetDatabase.LoadAssetAtPath(this.install_path + "/Buttons/button_settings.png", typeof(Texture));
		this.button_help = (Texture)AssetDatabase.LoadAssetAtPath(this.install_path + "/Buttons/button_help.png", typeof(Texture));
		this.button_heightmap = (Texture)AssetDatabase.LoadAssetAtPath(this.install_path + "/Buttons/button_heightmap.png", typeof(Texture));
		this.button_update = (Texture)AssetDatabase.LoadAssetAtPath(this.install_path + "/Buttons/button_update.png", typeof(Texture));
		this.button_terrain = (Texture)AssetDatabase.LoadAssetAtPath(this.install_path + "/Buttons/button_terrain.png", typeof(Texture));
		this.button_map = (Texture)AssetDatabase.LoadAssetAtPath(this.install_path + "/Buttons/button_map.png", typeof(Texture));
		this.button_region = (Texture)AssetDatabase.LoadAssetAtPath(this.install_path + "/Buttons/button_region.png", typeof(Texture));
		this.button_edit = (Texture)AssetDatabase.LoadAssetAtPath(this.install_path + "/Buttons/button_edit.png", typeof(Texture));
		this.button_image = (Texture)AssetDatabase.LoadAssetAtPath(this.install_path + "/Buttons/button_splatmap.png", typeof(Texture));
		this.button_converter = (Texture)AssetDatabase.LoadAssetAtPath(this.install_path + "/Buttons/button_convert.png", typeof(Texture));
	}

	public void reexports()
	{
		this.stop_all_elevation_pull();
		this.stop_all_image_pull();
	}

	public bool check_area_resize()
	{
		bool arg_5F_0;
		if (!this.area_rounded)
		{
			if (this.notify_text.Length != 0)
			{
				this.notify_text += "\n\n";
			}
			this.notify_text += "The tiles are not fitting in the Area. Please resize the area";
			this.global_script.map.mode = 2;
			arg_5F_0 = true;
		}
		else
		{
			arg_5F_0 = false;
		}
		return arg_5F_0;
	}

	public void SnapArea(latlong_class latlong1, latlong_class latlong2, float snapValue)
	{
		double latitude = latlong1.latitude;
		double longitude = latlong1.longitude;
		double num = (latlong2.latitude - latlong1.latitude) / (double)3;
		double num2 = (latlong2.longitude - latlong1.longitude) / (double)3;
		latlong1.latitude = (double)Mathf.Round((float)(latlong1.latitude / num)) * num;
		latlong1.longitude = (double)Mathf.Round((float)(latlong1.longitude / num2)) * num2;
		latlong2.latitude += latlong1.latitude - latitude;
		latlong2.longitude += latlong1.longitude - longitude;
	}

    float NormalizeHeightmap(Vector2 resolution, String file)
    {
        int bufferSize = 2048;
        byte[] bytes = new byte[bufferSize];
        byte[] bytes2 = new byte[bufferSize];
        FileStream fr;
        FileStream fw;
        float minHeight = 99999999;
        float maxHeight = -99999999;
        int length;
        float height;
        float heightRange;
        int i;
        int value_int;
        byte byte_hi;
        byte byte_lo;

        if (!File.Exists(file))
        {
            notify_text = "The heightmap file doesn't exist, please export it by clicking the 'Export Heightmap' button in the 'Heightmap Export' tab.";
            Debug.Log("The heightmap file doesn't exist, please export it by clicking the 'Export Heightmap' button in the 'Heightmap Export' tab.");
        }

        fr = new FileStream(file, FileMode.Open);

        do
        {
            length = fr.Read(bytes, 0, bufferSize);
            for (i = 0; i < length; i += 2)
            {
                height = (bytes[i + 1] * 255) + bytes[i];
                if (height > maxHeight) maxHeight = height;
                else if (height < minHeight) minHeight = height;
            }
        }
        while (length != 0);

        fr.Position = 0;
        fw = new FileStream(file.Replace(".Raw", "_N.Raw"), FileMode.Create);
        heightRange = maxHeight - minHeight;

        do
        {
            length = fr.Read(bytes, 0, bufferSize);
            for (i = 0; i < length; i += 2)
            {
                height = (bytes[i + 1] * 255) + bytes[i];
                height = ((height - minHeight) / heightRange) * 65535;

                value_int = (int)height;

                byte_hi = (byte)(value_int >> 8);
                byte_lo = (byte)(value_int - (byte_hi << 8));

                bytes2[i] = byte_lo;
                bytes2[i + 1] = byte_hi;
            }
            fw.Write(bytes2, 0, (int)length);
        }
        while (length != 0);

        fr.Close();
        fw.Close();

        Debug.Log("Exported normalized heightmap " + file.Replace(".Raw", "_N.Raw"));
        Debug.Log("Minimum height: " + GetRawHeight(minHeight) + " Maximum height: " + GetRawHeight(maxHeight));
        Debug.Log("Height of the terrain with real world scale: " + (GetRawHeight(heightRange) + 1000));
        return (GetRawHeight(heightRange) + 1000);
    }

    public float GetRawHeight(float height)
	{
		return height / 6.5535f - (float)1000;
	}
}
