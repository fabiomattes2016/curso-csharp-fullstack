import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css'],
})
export class EventosComponent implements OnInit {
  _filtroLista: string;

  get filtroLista(): string {
    return this._filtroLista;
  }

  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista
      ? this.filtrarEventos(this.filtroLista)
      : this.eventos;
  }

  eventosFiltrados: any = [];
  eventos: any = [];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  iconImagem = 'fa-eye';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  alternarImage() {
    this.mostrarImagem = !this.mostrarImagem;

    if (this.mostrarImagem) this.iconImagem = 'fa-eye-slash';
    else this.iconImagem = 'fa-eye';
  }

  getEventos() {
    const url = 'http://localhost:5000/api/v1/eventos';
    this.http.get(url).subscribe(
      (response) => {
        this.eventos = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
