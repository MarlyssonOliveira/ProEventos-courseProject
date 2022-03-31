import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos : any = [];
  public eventosFiltrados: any = [];
  larguraImg: number = 150;
  margemImg: number = 2;
  mostrar: boolean = false;
  private _filtroLista!: string;

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(texto : string){
    this._filtroLista = texto;
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this._filtroLista): this.eventos;
  }

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void{
    this.http.get("https://localhost:5001/api/Eventos").subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log()
    );
  }

  private filtrarEventos(filtrarPor : string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

}
