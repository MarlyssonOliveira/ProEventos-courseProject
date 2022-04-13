import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { EventoService } from '../../services/evento.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Evento } from '../../models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;

  public eventos : Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public larguraImg: number = 150;
  public margemImg: number = 2;
  public exibirImagem: boolean = false;
  private filtroListado!: string;

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) {}

  public get filtroLista(): string{
    return this.filtroListado;
  }

  public set filtroLista(texto : string){
    this.filtroListado = texto;
    this.eventosFiltrados = this.filtroListado ? this.filtrarEventos(this.filtroListado): this.eventos;
  }

  ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos(): void{
    this.eventoService.getEventos().subscribe({
        next: (eventos: Evento[]) => {
          this.eventos = eventos;
          this.eventosFiltrados = this.eventos
        },
        error: (error: any) => {
          this.spinner.hide(),
          this.toastr.error('Erro ao Carregar os Eventos', 'Erro!')
          console.log(error)
        },
        complete: () => this.spinner.hide()
      });
  }

  public filtrarEventos(filtrarPor : string): Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.toastr.success('O Evento foi deletado com sucesso!', 'Deletado');
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
